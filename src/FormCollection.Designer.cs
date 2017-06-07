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
			this.btTHwide = new System.Windows.Forms.Button();
			this.btStop = new System.Windows.Forms.Button();
			this.tiSlide = new System.Windows.Forms.Timer(this.components);
			this.btTHmiddle = new System.Windows.Forms.Button();
			this.btTHnarrow = new System.Windows.Forms.Button();
			this.gpButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpButtons
			// 
			this.gpButtons.BackColor = System.Drawing.Color.WhiteSmoke;
			this.gpButtons.Controls.Add(this.btTHnarrow);
			this.gpButtons.Controls.Add(this.btTHmiddle);
			this.gpButtons.Controls.Add(this.btDock);
			this.gpButtons.Controls.Add(this.btTHwide);
			this.gpButtons.Controls.Add(this.btStop);
			this.gpButtons.Location = new System.Drawing.Point(24, 48);
			this.gpButtons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.gpButtons.Name = "gpButtons";
			this.gpButtons.Size = new System.Drawing.Size(304, 53);
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
			this.btDock.Location = new System.Drawing.Point(0, 3);
			this.btDock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btDock.Name = "btDock";
			this.btDock.Size = new System.Drawing.Size(34, 46);
			this.btDock.TabIndex = 0;
			this.btDock.UseVisualStyleBackColor = false;
			this.btDock.Click += new System.EventHandler(this.btDock_Click);
			// 
			// btTHwide
			// 
			this.btTHwide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btTHwide.FlatAppearance.BorderSize = 0;
			this.btTHwide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHwide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHwide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btTHwide.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btTHwide.Image = global::gInk.Properties.Resources.pointer;
			this.btTHwide.Location = new System.Drawing.Point(46, 3);
			this.btTHwide.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btTHwide.Name = "btTHwide";
			this.btTHwide.Size = new System.Drawing.Size(46, 46);
			this.btTHwide.TabIndex = 0;
			this.btTHwide.UseVisualStyleBackColor = true;
			this.btTHwide.Click += new System.EventHandler(this.btTH_Click);
			// 
			// btStop
			// 
			this.btStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btStop.FlatAppearance.BorderSize = 0;
			this.btStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btStop.Image = global::gInk.Properties.Resources.exit;
			this.btStop.Location = new System.Drawing.Point(246, 3);
			this.btStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btStop.Name = "btStop";
			this.btStop.Size = new System.Drawing.Size(46, 46);
			this.btStop.TabIndex = 0;
			this.btStop.UseVisualStyleBackColor = true;
			this.btStop.Click += new System.EventHandler(this.btStop_Click);
			// 
			// tiSlide
			// 
			this.tiSlide.Interval = 15;
			this.tiSlide.Tick += new System.EventHandler(this.tiSlide_Tick);
			// 
			// btTHmiddle
			// 
			this.btTHmiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btTHmiddle.FlatAppearance.BorderSize = 0;
			this.btTHmiddle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHmiddle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHmiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btTHmiddle.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btTHmiddle.Image = global::gInk.Properties.Resources.pointer;
			this.btTHmiddle.Location = new System.Drawing.Point(106, 3);
			this.btTHmiddle.Margin = new System.Windows.Forms.Padding(2);
			this.btTHmiddle.Name = "btTHmiddle";
			this.btTHmiddle.Size = new System.Drawing.Size(46, 46);
			this.btTHmiddle.TabIndex = 1;
			this.btTHmiddle.UseVisualStyleBackColor = true;
			this.btTHmiddle.Click += new System.EventHandler(this.btTH_Click);
			// 
			// btTHnarrow
			// 
			this.btTHnarrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btTHnarrow.FlatAppearance.BorderSize = 0;
			this.btTHnarrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHnarrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHnarrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btTHnarrow.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btTHnarrow.Image = global::gInk.Properties.Resources.pointer;
			this.btTHnarrow.Location = new System.Drawing.Point(166, 3);
			this.btTHnarrow.Margin = new System.Windows.Forms.Padding(2);
			this.btTHnarrow.Name = "btTHnarrow";
			this.btTHnarrow.Size = new System.Drawing.Size(46, 46);
			this.btTHnarrow.TabIndex = 2;
			this.btTHnarrow.UseVisualStyleBackColor = true;
			this.btTHnarrow.Click += new System.EventHandler(this.btTH_Click);
			// 
			// FormCollection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(863, 526);
			this.Controls.Add(this.gpButtons);
			this.ForeColor = System.Drawing.Color.LawnGreen;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
		public System.Windows.Forms.Button btTHwide;
		public System.Windows.Forms.Button btTHnarrow;
		public System.Windows.Forms.Button btTHmiddle;
	}
}

