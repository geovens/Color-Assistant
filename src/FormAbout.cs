﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gInk
{
	public partial class FormAbout : Form
	{
		public FormAbout()
		{
			InitializeComponent();
		}

		private void FormAbout_Load(object sender, EventArgs e)
		{
			this.Icon = gInk.Properties.Resources.icon;
			string version = Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2);
			string about = "Color Assistant v" + version + "\r\n";
			about += "(c) 2017 Weizhi Nai\r\n";
			about += "Licensed under MIT\r\n";
			about += "https://github.com/geovens/Color-Assistant\r\n";
			about += "\r\n";
			textBox1.Text = about;
			textBox1.Select(textBox1.Text.Length, 0);
		}
	}
}
