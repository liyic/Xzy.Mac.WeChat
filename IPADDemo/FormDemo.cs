﻿using IPADDemo.Model;
using IPADDemo.WeChat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPADDemo
{
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
            InitializeComponent();
            WxDelegate.qrCode += new QrCode(this.calback_qrcode);
            WxDelegate.show += new Show(this.calback_show);
            CheckForIllegalCrossThreadCalls = false;
        }

        private void FormDemo_Load(object sender, EventArgs e)
        {
            XzyWeChatThread weChatThread = new XzyWeChatThread();

        }

        void calback_qrcode(string qrcode)
        {
            byte[] arr2 = Convert.FromBase64String(qrcode);
            using (MemoryStream ms2 = new MemoryStream(arr2))
            {
                System.Drawing.Bitmap bmp2 = new System.Drawing.Bitmap(ms2);
                pictureBox1.Image = bmp2;
            }
        }

        void calback_show(string str)
        {
            textBox1.Text = str;
        }
    }
}
