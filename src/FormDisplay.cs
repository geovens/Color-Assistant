using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Ink;

namespace gInk
{
	public partial class FormDisplay : Form
	{
		public Root Root;
		IntPtr Canvus;
		IntPtr canvusDc;
		IntPtr OneStrokeCanvus;
		IntPtr onestrokeDc;
		IntPtr BlankCanvus;
		IntPtr blankcanvusDc;
		Graphics gCanvus;
		public Graphics gOneStrokeCanvus;
		//Bitmap ScreenBitmap;
		IntPtr hScreenBitmap;
		IntPtr memscreenDc;

		Bitmap gpButtonsImage;
		SolidBrush TransparentBrush;
		SolidBrush SemiTransparentBrush;

		byte[] screenbits;
		byte[] drawscreenbits;
		List<Point> MatchPixelList;

		public FormDisplay(Root root)
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

			Bitmap InitCanvus = new Bitmap(this.Width, this.Height);
			Canvus = InitCanvus.GetHbitmap(Color.FromArgb(0));
			OneStrokeCanvus = InitCanvus.GetHbitmap(Color.FromArgb(0));
			//BlankCanvus = InitCanvus.GetHbitmap(Color.FromArgb(0));

			IntPtr screenDc = GetDC(IntPtr.Zero);
			canvusDc = CreateCompatibleDC(screenDc);
			SelectObject(canvusDc, Canvus);
			onestrokeDc = CreateCompatibleDC(screenDc);
			SelectObject(onestrokeDc, OneStrokeCanvus);
			//blankcanvusDc = CreateCompatibleDC(screenDc);
			//SelectObject(blankcanvusDc, BlankCanvus);
			gCanvus = Graphics.FromHdc(canvusDc);
			gCanvus.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
			gOneStrokeCanvus = Graphics.FromHdc(onestrokeDc);
			gOneStrokeCanvus.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

			// for color pick
			hScreenBitmap = InitCanvus.GetHbitmap(Color.FromArgb(0));
			memscreenDc = CreateCompatibleDC(screenDc);
			SelectObject(memscreenDc, hScreenBitmap);
			screenbits = new byte[50000000];
			drawscreenbits = new byte[50000000];
			MatchPixelList = new List<Point>();

			ReleaseDC(IntPtr.Zero, screenDc);
			InitCanvus.Dispose();

			//this.DoubleBuffered = true;

			gpButtonsImage = new Bitmap(2400, 100);
			TransparentBrush = new SolidBrush(Color.Transparent);
			SemiTransparentBrush = new SolidBrush(Color.FromArgb(120, 255, 255, 255));


			ToTopMostThrough();
		}

		public void ToTopMostThrough()
		{
			UInt32 dwExStyle = GetWindowLong(this.Handle, -20);
			SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000);
			SetWindowPos(this.Handle, (IntPtr)0, 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0004 | 0x0010 | 0x0020);
			//SetLayeredWindowAttributes(this.Handle, 0x00FFFFFF, 1, 0x2);
			SetWindowLong(this.Handle, -20, dwExStyle | 0x00080000 | 0x00000020);
			SetWindowPos(this.Handle, (IntPtr)(-1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0010 | 0x0020);
		}

		public void ClearCanvus()
		{
			gCanvus.Clear(Color.Transparent);
		}
		public void ClearCanvus(Graphics g)
		{
			g.Clear(Color.Transparent);
		}

		public void DrawSnapping(Rectangle rect)
		{
			gCanvus.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
			if (rect.Width > 0 && rect.Height > 0)
			{
				gCanvus.FillRectangle(SemiTransparentBrush, new Rectangle(0, 0, rect.Left, this.Height));
				gCanvus.FillRectangle(SemiTransparentBrush, new Rectangle(rect.Right, 0, this.Width - rect.Right, this.Height));
				gCanvus.FillRectangle(SemiTransparentBrush, new Rectangle(rect.Left, 0, rect.Width, rect.Top));
				gCanvus.FillRectangle(SemiTransparentBrush, new Rectangle(rect.Left, rect.Bottom, rect.Width, this.Height - rect.Bottom));
				Pen pen = new Pen(Color.FromArgb(200, 80, 80, 80));
				pen.Width = 3;
				gCanvus.DrawRectangle(pen, rect);
			}
			else
			{
				gCanvus.FillRectangle(SemiTransparentBrush, new Rectangle(0, 0, this.Width, this.Height));
			}
			gCanvus.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
		}

		public void DrawButtons(bool redrawbuttons, bool exiting = false)
		{
			int top = Root.FormCollection.gpButtons.Top;
			int height = Root.FormCollection.gpButtons.Height;
			int left = Root.FormCollection.gpButtons.Left;
			int width = Root.FormCollection.gpButtons.Width;
			if (redrawbuttons)
				Root.FormCollection.gpButtons.DrawToBitmap(gpButtonsImage, new Rectangle(0, 0, width, height));
			
			if (exiting)
				gCanvus.FillRectangle(TransparentBrush, left - 120, top, width + 80, height);
			gCanvus.DrawImage(gpButtonsImage, left, top);
		}
		public void DrawButtons(Graphics g, bool redrawbuttons, bool exiting = false)
		{
			int top = Root.FormCollection.gpButtons.Top;
			int height = Root.FormCollection.gpButtons.Height;
			int left = Root.FormCollection.gpButtons.Left;
			int width = Root.FormCollection.gpButtons.Width;
			if (redrawbuttons)
				Root.FormCollection.gpButtons.DrawToBitmap(gpButtonsImage, new Rectangle(0, 0, width, height));

			if (exiting)
				g.FillRectangle(TransparentBrush, left - 120, top, width + 80, height);
			g.DrawImage(gpButtonsImage, left, top);
		}

		public void DrawTest(int x, int y)
		{
			Pen bp = new Pen(Color.FromArgb(250, 250, 0, 0));
			gCanvus.DrawLine(bp, new Point(x, y), new Point(x + 100, y + 100));
		}

		
		protected override void OnPaint(PaintEventArgs e)
		{
			UpdateFormDisplay(true);
		}


		public byte GC(int i, int j, int c)
		{
			return screenbits[(this.Width * j + i) * 4 + c];
		}
		public void SC(int i, int j, byte v)
		{
			screenbits[(this.Width * j + i) * 4 + 0] = v;
			screenbits[(this.Width * j + i) * 4 + 1] = v;
			screenbits[(this.Width * j + i) * 4 + 2] = v;
			screenbits[(this.Width * j + i) * 4 + 3] = 50;
		}

		public void PickColor(int x, int y)
		{		
			IntPtr screenDc = GetDC(IntPtr.Zero);

			BitBlt(memscreenDc, 0, 0, this.Width, this.Height, screenDc, 0, 0, 0x00CC0020);
			GetBitmapBits(hScreenBitmap, this.Width * this.Height * 4, screenbits);

			int targetb = GC(x, y, 0);
			int targetg = GC(x, y, 1);
			int targetr = GC(x, y, 2);
			MatchPixelList.Clear();
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					int b = GC(i, j, 0);
					int g = GC(i, j, 1);
					int r = GC(i, j, 2);
					if (Math.Abs(b - targetb) < 9 && Math.Abs(g - targetg) < 9 && Math.Abs(r - targetr) < 9)
					{
						MatchPixelList.Add(new Point(i, j));
					}
				}
			}

			ReleaseDC(IntPtr.Zero, screenDc);
		}

		public void UpdateFormDisplay(bool draw)
		{
			IntPtr screenDc = GetDC(IntPtr.Zero);

			//Display-rectangle
			Size size = new Size(this.Width, this.Height);
			Point pointSource = new Point(0, 0);
			Point topPos = new Point(this.Left, this.Top);

			//Set up blending options
			BLENDFUNCTION blend = new BLENDFUNCTION();
			blend.BlendOp = AC_SRC_OVER;
			blend.BlendFlags = 0;
			blend.SourceConstantAlpha = 255;  // additional alpha multiplier to the whole image. value 255 means multiply with 1.
			blend.AlphaFormat = AC_SRC_ALPHA;

			if (draw)
				UpdateLayeredWindow(this.Handle, screenDc, ref topPos, ref size, canvusDc, ref pointSource, 0, ref blend, ULW_ALPHA);
			else
				UpdateLayeredWindow(this.Handle, screenDc, ref topPos, ref size, blankcanvusDc, ref pointSource, 0, ref blend, ULW_ALPHA);

			//Clean-up
			ReleaseDC(IntPtr.Zero, screenDc);	
		}

		int MaskColor = 0;
		int MaskColorInterval = 10;
		private void timer1_Tick(object sender, EventArgs e)
		{
			MaskColor += MaskColorInterval;
			if (MaskColor < 0 || MaskColor > 255)
			{
				MaskColorInterval = -MaskColorInterval;
				MaskColor += 2 * MaskColorInterval;
			}

			if (Root.UponButtonsUpdate > 0)
			{
				if ((Root.UponButtonsUpdate & 0x2) > 0)
					DrawButtons(true, true);
				else if ((Root.UponButtonsUpdate & 0x1) > 0)
					DrawButtons(false, true);
				UpdateFormDisplay(true);
				Root.UponButtonsUpdate = 0;
			}

			if (Root.InPick)
			{
				foreach (Point point in MatchPixelList)
				{
					SC(point.X, point.Y, (byte)(MaskColor));
				}

				IntPtr screenDc = GetDC(IntPtr.Zero);
				SetBitmapBits(hScreenBitmap, this.Width * this.Height * 4, screenbits);
				BitBlt(canvusDc, 0, 0, this.Width, this.Height, memscreenDc, 0, 0, 0x00CC0020);
				ReleaseDC(IntPtr.Zero, screenDc);

				DrawButtons(false);
				UpdateFormDisplay(true);
			}
		}

		private void FormDisplay_FormClosed(object sender, FormClosedEventArgs e)
		{
			DeleteObject(Canvus);
			//DeleteObject(BlankCanvus);
			DeleteDC(canvusDc);

			DeleteObject(hScreenBitmap);
			DeleteDC(memscreenDc);
		}

		[DllImport("user32.dll")]
		static extern IntPtr GetDC(IntPtr hWnd);
		[DllImport("user32.dll")]
		static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
		[DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
		public static extern bool DeleteDC([In] IntPtr hdc);
		[DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
		static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);
		[DllImport("gdi32.dll", EntryPoint = "SelectObject")]
		public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);
		[DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject([In] IntPtr hObject);
		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, uint crKey, [In] ref BLENDFUNCTION pblend, uint dwFlags);
		[DllImport("gdi32.dll")]
		public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
		[DllImport("gdi32.dll")]
		public static extern bool StretchBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int nWidthSrc, int nHeightSrc, long dwRop);


		[StructLayout(LayoutKind.Sequential)]
		public struct BLENDFUNCTION
		{
			public byte BlendOp;
			public byte BlendFlags;
			public byte SourceConstantAlpha;
			public byte AlphaFormat;

			public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
			{
				BlendOp = op;
				BlendFlags = flags;
				SourceConstantAlpha = alpha;
				AlphaFormat = format;
			}
		}

		const int ULW_ALPHA = 2;
		const int AC_SRC_OVER = 0x00;
		const int AC_SRC_ALPHA = 0x01;


		[DllImport("user32.dll")]
		static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
		[DllImport("user32.dll", SetLastError = true)]
		static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll")]
		static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);
		[DllImport("user32.dll")]
		public extern static bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

		[DllImport("gdi32.dll")]
		static extern int GetBitmapBits(IntPtr hbmp, int cbBuffer, [Out] byte[] lpvBits);
		[DllImport("gdi32.dll")]
		static extern int SetBitmapBits(IntPtr hbmp, int cbBuffer, [Out] byte[] lpvBits);
		[DllImport("gdi32.dll")]
		static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

		[DllImport("gdi32.dll")]
		static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		[DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
		public static extern IntPtr memcpy(IntPtr dest, IntPtr src, int count);

	}
}
