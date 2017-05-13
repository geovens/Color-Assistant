namespace gInk
{
	partial class FormCollection
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.gpButtons = new System.Windows.Forms.Panel();
			this.btDock = new System.Windows.Forms.Button();
			this.btPointer = new System.Windows.Forms.Button();
			this.btStop = new System.Windows.Forms.Button();
			this.tiSlide = new System.Windows.Forms.Timer(this.components);
			this.gpButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpButtons
			// 
			this.gpButtons.BackColor = System.Drawing.Color.WhiteSmoke;
			this.gpButtons.Controls.Add(this.btDock);
			this.gpButtons.Controls.Add(this.btPointer);
			this.gpButtons.Controls.Add(this.btStop);
			this.gpButtons.Location = new System.Drawing.Point(42, 84);
			this.gpButtons.Name = "gpButtons";
			this.gpButtons.Size = new System.Drawing.Size(330, 92);
			this.gpButtons.TabIndex = 3;
			// 
			// btDock
			// 
			this.btDock.BackColor = System.Drawing.Color.WhiteSmoke;
			this.btDock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btDock.FlatAppearance.BorderSize = 0;
			this.btDock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btDock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btDock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btDock.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btDock.Image = global::gInk.Properties.Resources.dock;
			this.btDock.Location = new System.Drawing.Point(0, 5);
			this.btDock.Name = "btDock";
			this.btDock.Size = new System.Drawing.Size(60, 80);
			this.btDock.TabIndex = 0;
			this.btDock.UseVisualStyleBackColor = false;
			this.btDock.Click += new System.EventHandler(this.btDock_Click);
			// 
			// btPointer
			// 
			this.btPointer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btPointer.FlatAppearance.BorderSize = 0;
			this.btPointer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btPointer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btPointer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btPointer.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btPointer.Image = global::gInk.Properties.Resources.pointer;
			this.btPointer.Location = new System.Drawing.Point(80, 5);
			this.btPointer.Name = "btPointer";
			this.btPointer.Size = new System.Drawing.Size(80, 80);
			this.btPointer.TabIndex = 0;
			this.btPointer.UseVisualStyleBackColor = true;
			this.btPointer.Click += new System.EventHandler(this.btPointer_Click);
			// 
			// btStop
			// 
			this.btStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btStop.FlatAppearance.BorderSize = 0;
			this.btStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btStop.Image = global::gInk.Properties.Resources.exit;
			this.btStop.Location = new System.Drawing.Point(220, 5);
			this.btStop.Name = "btStop";
			this.btStop.Size = new System.Drawing.Size(80, 80);
			this.btStop.TabIndex = 0;
			this.btStop.UseVisualStyleBackColor = true;
			this.btStop.Click += new System.EventHandler(this.btStop_Click);
			// 
			// tiSlide
			// 
			this.tiSlide.Interval = 15;
			this.tiSlide.Tick += new System.EventHandler(this.tiSlide_Tick);
			// 
			// FormCollection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1510, 921);
			this.Controls.Add(this.gpButtons);
			this.ForeColor = System.Drawing.Color.LawnGreen;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCollection";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormCollection_MouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormCollection_MouseUp);
			this.gpButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Button btStop;
		public System.Windows.Forms.Panel gpButtons;
		private System.Windows.Forms.Timer tiSlide;
		public System.Windows.Forms.Button btDock;
		public System.Windows.Forms.Button btPointer;
	}
}

