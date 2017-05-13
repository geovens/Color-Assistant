using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Ink;

namespace gInk
{
	public class TestMessageFilter : IMessageFilter
	{
		public Root Root;

		public TestMessageFilter(Root root)
		{
			Root = root;
		}

		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == 0x0312)
			{
				//Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
				//int modifier = (int)m.LParam & 0xFFFF;       // The modifier of the hotkey that was pressed.
				//int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

				if (Root.FormCollection == null && Root.FormDisplay == null)
					Root.StartInk();
				else if (Root.Docked)
					Root.UnDock();
			}
			return false;
		}
	}

	public class Root
	{
		// options
		public bool Hotkey_Control, Hotkey_Alt, Hotkey_Shift, Hotkey_Win;
		public int Hotkey;
		public bool WhiteTrayIcon;

		public bool Docked = false;
		public bool InPick = false;

		public int UponButtonsUpdate = 0;
        public bool UponBalloonSnap = false;

		private NotifyIcon trayIcon;
		private ContextMenu trayMenu;
		public FormCollection FormCollection;
		public FormDisplay FormDisplay;
		public FormButtonHitter FormButtonHitter;

		public Root()
		{
			SetDefaultConfig();
			ReadOptions("pens.ini");
			ReadOptions("config.ini");

			trayMenu = new ContextMenu();
			trayMenu.MenuItems.Add("About", OnAbout);
			trayMenu.MenuItems.Add("Pen Configurations", OnPenSetting);
			trayMenu.MenuItems.Add("Options", OnOptions);
			trayMenu.MenuItems.Add("-");
			trayMenu.MenuItems.Add("Exit", OnExit);

            Size size = SystemInformation.SmallIconSize;
            trayIcon = new NotifyIcon();
			trayIcon.Text = "gInk";
			if (WhiteTrayIcon)
				trayIcon.Icon = new Icon(gInk.Properties.Resources.icon_white, size);
			else
				trayIcon.Icon = new Icon(gInk.Properties.Resources.icon_red, size);
			trayIcon.ContextMenu = trayMenu;
			trayIcon.Visible = true;
			trayIcon.MouseClick += TrayIcon_Click;


            int modifier = 0;
			if (Hotkey_Control) modifier |= 0x2;
			if (Hotkey_Alt) modifier |= 0x1;
			if (Hotkey_Shift) modifier |= 0x4;
			if (Hotkey_Win) modifier |= 0x8;
			if (modifier != 0)
				RegisterHotKey(IntPtr.Zero, 0, modifier, Hotkey);

			TestMessageFilter mf = new TestMessageFilter(this);
			Application.AddMessageFilter(mf);

			FormCollection = null;
			FormDisplay = null;
		}

        private void TrayIcon_Click(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (FormDisplay == null && FormCollection == null)
				{
					ReadOptions("pens.ini");
					ReadOptions("config.ini");
					StartInk();
				}
				else if (Docked)
					UnDock();
			}
		}

		public void StartInk()
		{
			if (FormDisplay != null || FormCollection != null)
				return;

			//Docked = false;
			FormDisplay = new FormDisplay(this);
			FormCollection = new FormCollection(this);
			FormButtonHitter = new FormButtonHitter(this);

			FormDisplay.Show();
			FormCollection.Show();
			FormDisplay.DrawButtons(true);
		}
		public void StopInk()
		{
			FormCollection.Close();
			FormDisplay.Close();
			FormButtonHitter.Close();
			//FormCollection.Dispose();
			//FormDisplay.Dispose();
			GC.Collect();
			FormCollection = null;
			FormDisplay = null;
		}

		public void Dock()
		{
			if (FormDisplay == null || FormCollection == null)
				return;

			Docked = true;
			FormCollection.btDock.Image = FormCollection.image_dockback;
			UponButtonsUpdate |= 0x2;
		}

		public void UnDock()
		{
			if (FormDisplay == null || FormCollection == null)
				return;

			Docked = false;
			FormCollection.btDock.Image = FormCollection.image_dock;
			UponButtonsUpdate |= 0x2;
		}

		public void Pick(int x, int y)
		{
			InPick = true;
			FormDisplay.PickColor(x, y);
		}

		public void UnPick()
		{
			InPick = false;
			FormDisplay.ClearCanvus();
			FormDisplay.UpdateFormDisplay(true);
		}

		public void SetDefaultConfig()
		{
			Hotkey_Control = true;
			Hotkey_Alt = true;
			Hotkey_Shift = false;
			Hotkey_Win = false;
			Hotkey = 'G';

			WhiteTrayIcon = false;
		}

		public void ReadOptions(string file)
		{
			if (!File.Exists(file))
			{
				return;
			}

			FileStream fini = new FileStream(file, FileMode.Open);
			StreamReader srini = new StreamReader(fini);
			string sLine = "";
			string sName = "", sPara = "";
			while (sLine != null)
			{
				sLine = srini.ReadLine();
				if
				(
					sLine != null &&
					sLine != "" &&
					sLine.Substring(0, 1) != "-" &&
					sLine.Substring(0, 1) != "%" &&
					sLine.Substring(0, 1) != "'" &&
					sLine.Substring(0, 1) != "/" &&
					sLine.Substring(0, 1) != "!" &&
					sLine.Substring(0, 1) != "[" &&
					sLine.Substring(0, 1) != "#" &&
					sLine.Contains("=") &&
					!sLine.Substring(sLine.IndexOf("=") + 1).Contains("=")
				)
				{
					sName = sLine.Substring(0, sLine.IndexOf("="));
					sName = sName.Trim();
					sName = sName.ToUpper();
					sPara = sLine.Substring(sLine.IndexOf("=") + 1);
					sPara = sPara.Trim();

					int o;
					switch (sName)
					{
						case "HOTKEY":
							sPara = sPara.ToUpper();
							if (sPara.Contains("CONTROL"))
								Hotkey_Control = true;
							else
								Hotkey_Control = false;
							if (sPara.Contains("ALT"))
								Hotkey_Alt = true;
							else
								Hotkey_Alt = false;
							if (sPara.Contains("SHIFT"))
								Hotkey_Shift = true;
							else
								Hotkey_Shift = false;
							if (sPara.Contains("WIN"))
								Hotkey_Win = true;
							else
								Hotkey_Win = false;
							if (sPara.Length > 0)
								Hotkey = sPara.Substring(sPara.Length - 1).ToCharArray()[0];
							break;
						case "WHITETRAYICON":
							sPara = sPara.ToUpper();
							if (sPara.Contains("TRUE"))
								WhiteTrayIcon = true;
							else
								WhiteTrayIcon = false;
							break;
					}
				}
			}
			fini.Close();
		}

		private void OnAbout(object sender, EventArgs e)
		{
			FormAbout FormAbout = new FormAbout();
			FormAbout.Show();
		}

		private void OnPenSetting(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("notepad.exe", "pens.ini");
		}

		private void OnOptions(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("notepad.exe", "config.ini");
		}

		private void OnExit(object sender, EventArgs e)
		{
			int modifier = 0;
			if (Hotkey_Control) modifier |= 0x2;
			if (Hotkey_Alt) modifier |= 0x1;
			if (Hotkey_Shift) modifier |= 0x4;
			if (Hotkey_Win) modifier |= 0x8;
			if (modifier != 0)
				UnregisterHotKey(IntPtr.Zero, 0);

			trayIcon.Dispose();
			Application.Exit();
		}

		[DllImport("user32.dll")]
		private static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
		[DllImport("user32.dll")]
		private static extern int UnregisterHotKey(IntPtr hwnd, int id);
	}
}

