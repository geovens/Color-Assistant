using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
//using System.Windows.Input;
using Microsoft.Ink;

namespace gInk
{
	public partial class FormCollection : Form
	{
		public Root Root;

		public Bitmap image_exit;
		public Bitmap image_dock, image_dockback;
		public Bitmap image_thnarrow, image_thnarrow_act, image_thmiddle, image_thmiddle_act, image_thwide, image_thwide_act;

		public int ButtonsEntering = 0;  // -1 = exiting
		public int gpButtonsLeft, gpButtonsTop;

		public FormCollection(Root root)
		{
			Root = root;
			InitializeComponent();

			this.Left = SystemInformation.VirtualScreen.Left;
			this.Top = SystemInformation.VirtualScreen.Top;
			int targetbottom = 0;
			foreach (Screen screen in Screen.AllScreens)
			{
				if (screen.WorkingArea.Bottom > targetbottom)
					targetbottom = screen.WorkingArea.Bottom;
			}
			int virwidth = SystemInformation.VirtualScreen.Width;
			this.Width = virwidth;
			this.Height = targetbottom - this.Top;
			this.DoubleBuffered = true;

			gpButtonsLeft = Screen.PrimaryScreen.WorkingArea.Right - gpButtons.Width + (Screen.PrimaryScreen.WorkingArea.Left - SystemInformation.VirtualScreen.Left);
			gpButtonsTop = Screen.PrimaryScreen.WorkingArea.Bottom - gpButtons.Height - 10 + (Screen.PrimaryScreen.WorkingArea.Top - SystemInformation.VirtualScreen.Top);
			gpButtons.Left = gpButtonsLeft + gpButtons.Width;
			gpButtons.Top = gpButtonsTop;


			image_exit = new Bitmap(btStop.Width, btStop.Height);
			Graphics g = Graphics.FromImage(image_exit);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(global::gInk.Properties.Resources.exit, 0, 0, btStop.Width, btStop.Height);
			btStop.Image = image_exit;
			image_dock = new Bitmap(btDock.Width, btDock.Height);
			g = Graphics.FromImage(image_dock);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(global::gInk.Properties.Resources.dock, 0, 0, btDock.Width, btDock.Height);
			image_dockback = new Bitmap(btDock.Width, btDock.Height);
			g = Graphics.FromImage(image_dockback);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(global::gInk.Properties.Resources.dockback, 0, 0, btDock.Width, btDock.Height);
			if (Root.Docked)
				btDock.Image = image_dockback;
			else
				btDock.Image = image_dock;


			image_thnarrow = new Bitmap(btTHwide.Width, btTHwide.Height);
			g = Graphics.FromImage(image_thnarrow);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(global::gInk.Properties.Resources.thnarrow, 0, 0, btTHwide.Width, btTHwide.Height);
			image_thnarrow_act = new Bitmap(btTHwide.Width, btTHwide.Height);
			g = Graphics.FromImage(image_thnarrow_act);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(global::gInk.Properties.Resources.thnarrow_act, 0, 0, btTHwide.Width, btTHwide.Height);
			btTHnarrow.Image = image_thnarrow_act;

			image_thmiddle = new Bitmap(btTHwide.Width, btTHwide.Height);
			g = Graphics.FromImage(image_thmiddle);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(global::gInk.Properties.Resources.thmiddle, 0, 0, btTHwide.Width, btTHwide.Height);
			image_thmiddle_act = new Bitmap(btTHwide.Width, btTHwide.Height);
			g = Graphics.FromImage(image_thmiddle_act);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(global::gInk.Properties.Resources.thmiddle_act, 0, 0, btTHwide.Width, btTHwide.Height);
			btTHmiddle.Image = image_thmiddle_act;

			image_thwide = new Bitmap(btTHwide.Width, btTHwide.Height);
			g = Graphics.FromImage(image_thwide);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(global::gInk.Properties.Resources.thwide, 0, 0, btTHwide.Width, btTHwide.Height);
			image_thwide_act = new Bitmap(btTHwide.Width, btTHwide.Height);
			g = Graphics.FromImage(image_thwide_act);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(global::gInk.Properties.Resources.thwide_act, 0, 0, btTHwide.Width, btTHwide.Height);
			btTHwide.Image = image_thwide_act;

			LastTickTime = DateTime.Parse("1987-01-01");
			tiSlide.Enabled = true;

			SelectThreshold(Root.CDThresholdIndex);

			ToTransparent();
			ToTopMost();
		}


		public void ToTransparent()
		{
			UInt32 dwExStyle = GetWindowLong(this.Handle, -20);
			SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000);
			SetLayeredWindowAttributes(this.Handle, 0x00FFFFFF, 1, 0x2);	
		}

		public void ToTopMost()
		{
			SetWindowPos(this.Handle, (IntPtr)(-1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0020);
		}

		public void ToThrough()
		{
			UInt32 dwExStyle = GetWindowLong(this.Handle, -20);
			//SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000);
			//SetWindowPos(this.Handle, (IntPtr)0, 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0004 | 0x0010 | 0x0020);
			//SetLayeredWindowAttributes(this.Handle, 0x00FFFFFF, 1, 0x2);
			SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000 | 0x00000020);
			//SetWindowPos(this.Handle, (IntPtr)(1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0010 | 0x0020);
		}

		public void ToUnThrough()
		{
			UInt32 dwExStyle = GetWindowLong(this.Handle, -20);
			//SetWindowLong(this.Handle, -20, (uint)(dwExStyle & ~0x00080000 & ~0x0020));
			SetWindowLong(this.Handle, -20, (uint)(dwExStyle & ~0x0020));
			//SetWindowPos(this.Handle, (IntPtr)(-2), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0010 | 0x0020);

			//dwExStyle = GetWindowLong(this.Handle, -20);
			//SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000);
			//SetLayeredWindowAttributes(this.Handle, 0x00FFFFFF, 1, 0x2);
			//SetWindowPos(this.Handle, (IntPtr)(-1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0020);
		}


		public void RetreatAndExit()
		{
			ToThrough();
			LastTickTime = DateTime.Now;
			ButtonsEntering = -1;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void FormCollection_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Root.Pick(e.X, e.Y);
		}

		private void FormCollection_MouseUp(object sender, MouseEventArgs e)
		{
			Root.UnPick();
		}

		public void btDock_Click(object sender, EventArgs e)
		{
			LastTickTime = DateTime.Now;
			if (!Root.Docked)
			{
				Root.Dock();
			}
			else
			{
				Root.UnDock();
			}
		}

		public void btTH_Click(object sender, EventArgs e)
		{
			if (sender == btTHnarrow)
				SelectThreshold(1);
			else if (sender == btTHmiddle)
				SelectThreshold(2);
			else if (sender == btTHwide)
				SelectThreshold(3);
		}

		public void SelectThreshold(int index)
		{
			Root.CDThresholdIndex = index;
			if (index == 1)
			{
				Root.CDThreshold = 10;
				btTHnarrow.Image = image_thnarrow_act;
				btTHmiddle.Image = image_thmiddle;
				btTHwide.Image = image_thwide;
			}
			else if (index == 2)
			{
				Root.CDThreshold = 30;
				btTHnarrow.Image = image_thnarrow;
				btTHmiddle.Image = image_thmiddle_act;
				btTHwide.Image = image_thwide;
			}
			else if (index == 3)
			{
				Root.CDThreshold = 60;
				btTHnarrow.Image = image_thnarrow;
				btTHmiddle.Image = image_thmiddle;
				btTHwide.Image = image_thwide_act;
			}

			Root.UponButtonsUpdate |= 0x2;
		}

		public void btStop_Click(object sender, EventArgs e)
		{
			RetreatAndExit();
		}

		DateTime LastTickTime;
		short LastZStatus = 0;
		short LastYStatus = 0;
		private void tiSlide_Tick(object sender, EventArgs e)
		{
			// ignore the first tick
			if (LastTickTime.Year == 1987)
			{
				LastTickTime = DateTime.Now;
				return;
			}

			int primwidth = Screen.PrimaryScreen.WorkingArea.Width;
			int primheight = Screen.PrimaryScreen.WorkingArea.Height;
			int primright = Screen.PrimaryScreen.WorkingArea.Right;
			int primbottom = Screen.PrimaryScreen.WorkingArea.Bottom;

			int aimedleft = gpButtonsLeft;
			if (ButtonsEntering == 0)
			{
				if (Root.Docked)
					aimedleft = gpButtonsLeft + gpButtons.Width - btDock.Right;
				else
					aimedleft = gpButtonsLeft;
			}
			else if (ButtonsEntering == -1)
				aimedleft = gpButtonsLeft + gpButtons.Width;

			if (gpButtons.Left > aimedleft)
			{
				float dleft = gpButtons.Left - aimedleft;
				dleft /= 70;
				if (dleft > 8) dleft = 8;
				dleft *= (float)(DateTime.Now - LastTickTime).TotalMilliseconds;
				if (dleft > 120) dleft = 230;
				if (dleft < 1) dleft = 1;
				gpButtons.Left -= (int)dleft;
				LastTickTime = DateTime.Now;
				if (gpButtons.Left < aimedleft)
				{
					gpButtons.Left = aimedleft;
				}
				Root.UponButtonsUpdate |= 0x1;
			}
			else if (gpButtons.Left < aimedleft)
			{
				float dleft = aimedleft - gpButtons.Left;
				dleft /= 70;
				if (dleft > 8) dleft = 8;
				// fast exiting when not docked
				if (ButtonsEntering == -1 && !Root.Docked)
					dleft = 8;
				dleft *= (float)(DateTime.Now - LastTickTime).TotalMilliseconds;
				if (dleft > 120) dleft = 120;
				if (dleft < 1) dleft = 1;
				// fast exiting when docked
				if (ButtonsEntering == -1 && dleft == 1)
					dleft = 2;
				gpButtons.Left += (int)dleft;
				LastTickTime = DateTime.Now;
				if (gpButtons.Left > aimedleft)
				{
					gpButtons.Left = aimedleft;
				}
				Root.UponButtonsUpdate |= 0x1;
			}

			if (ButtonsEntering == -1 && gpButtons.Left == aimedleft)
			{
				tiSlide.Enabled = false;
				Root.StopInk();
				return;
			}

			short retVal = GetKeyState(27);
			if ((retVal & 0x8000) == 0x8000)
			{
				RetreatAndExit();
			}

		}

		[DllImport("user32.dll")]
		static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
		[DllImport("user32.dll", SetLastError = true)]
		static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll")]
		static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

		[DllImport("user32.dll")]
		public extern static bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
		[DllImport("user32.dll", SetLastError = false)]
		static extern IntPtr GetDesktopWindow();
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern short GetKeyState(int keyCode);
	}
}
