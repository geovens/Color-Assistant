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
			this.btTHnarrow = new System.Windows.Forms.Button();
			this.btTHmiddle = new System.Windows.Forms.Button();
			this.btDock = new System.Windows.Forms.Button();
			this.btTHwide = new System.Windows.Forms.Button();
			this.btStop = new System.Windows.Forms.Button();
			this.tiSlide = new System.Windows.Forms.Timer(this.components);
			this.btShift = new System.Windows.Forms.Button();
			this.gpButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpButtons
			// 
			this.gpButtons.BackColor = System.Drawing.Color.WhiteSmoke;
			this.gpButtons.Controls.Add(this.btShift);
			this.gpButtons.Controls.Add(this.btTHnarrow);
			this.gpButtons.Controls.Add(this.btTHmiddle);
			this.gpButtons.Controls.Add(this.btDock);
			this.gpButtons.Controls.Add(this.btTHwide);
			this.gpButtons.Controls.Add(this.btStop);
			this.gpButtons.Location = new System.Drawing.Point(42, 84);
			this.gpButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.gpButtons.Name = "gpButtons";
			this.gpButtons.Size = new System.Drawing.Size(632, 93);
			this.gpButtons.TabIndex = 3;
			// 
			// btTHnarrow
			// 
			this.btTHnarrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btTHnarrow.FlatAppearance.BorderSize = 0;
			this.btTHnarrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHnarrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHnarrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btTHnarrow.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btTHnarrow.Image = global::gInk.Properties.Resources.thnarrow;
			this.btTHnarrow.Location = new System.Drawing.Point(317, 5);
			this.btTHnarrow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btTHnarrow.Name = "btTHnarrow";
			this.btTHnarrow.Size = new System.Drawing.Size(80, 80);
			this.btTHnarrow.TabIndex = 2;
			this.btTHnarrow.UseVisualStyleBackColor = true;
			this.btTHnarrow.Click += new System.EventHandler(this.btTH_Click);
			// 
			// btTHmiddle
			// 
			this.btTHmiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btTHmiddle.FlatAppearance.BorderSize = 0;
			this.btTHmiddle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHmiddle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btTHmiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btTHmiddle.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btTHmiddle.Image = global::gInk.Properties.Resources.thmiddle;
			this.btTHmiddle.Location = new System.Drawing.Point(229, 5);
			this.btTHmiddle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btTHmiddle.Name = "btTHmiddle";
			this.btTHmiddle.Size = new System.Drawing.Size(80, 80);
			this.btTHmiddle.TabIndex = 1;
			this.btTHmiddle.UseVisualStyleBackColor = true;
			this.btTHmiddle.Click += new System.EventHandler(this.btTH_Click);
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
			this.btDock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btDock.Name = "btDock";
			this.btDock.Size = new System.Drawing.Size(60, 80);
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
			this.btTHwide.Image = global::gInk.Properties.Resources.thwide;
			this.btTHwide.Location = new System.Drawing.Point(116, 5);
			this.btTHwide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btTHwide.Name = "btTHwide";
			this.btTHwide.Size = new System.Drawing.Size(80, 80);
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
			this.btStop.Location = new System.Drawing.Point(530, 5);
			this.btStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
			// btShift
			// 
			this.btShift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btShift.FlatAppearance.BorderSize = 0;
			this.btShift.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btShift.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btShift.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btShift.Image = global::gInk.Properties.Resources.thnarrow;
			this.btShift.Location = new System.Drawing.Point(420, 4);
			this.btShift.Margin = new System.Windows.Forms.Padding(4);
			this.btShift.Name = "btShift";
			this.btShift.Size = new System.Drawing.Size(80, 80);
			this.btShift.TabIndex = 3;
			this.btShift.UseVisualStyleBackColor = true;
			this.btShift.Click += new System.EventHandler(this.btShift_Click);
			// 
			// FormCollection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1510, 920);
			this.Controls.Add(this.gpButtons);
			this.ForeColor = System.Drawing.Color.LawnGreen;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
		public System.Windows.Forms.Button btShift;
	}
}

