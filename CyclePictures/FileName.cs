using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyclePictures
{
    public partial class FileName : Form
    {
        public static int PADDING = 50;
        private Form1 Caller;
        public FileName(string text, Form1 Parent)
        {
            InitializeComponent();
            Caller = Parent;
            Caller.Enabled = false;

            label1.Text = text;
            if (CopyToC.Width + OpenFolder.Width > label1.Width) { this.Width = CopyToC.Width + OpenFolder.Width + PADDING; }
            else { this.Width = label1.Width + PADDING; }
            this.Width = label1.Width + PADDING;                    //Scale Window
            label1.Left = PADDING / 2 - 5;                          //Position text
            CopyToC.Left = Width / 2 - CopyToC.Width - PADDING / 20;           //Position Button
            OpenFolder.Left = Width / 2 + PADDING / 20;     //Position 2nd button
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(KeyPressEvent);
        }
        private void KeyPressEvent (object caller, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            { Close(); }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
 	        base.OnClosing(e);
            Caller.Enabled = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { Clipboard.SetText(label1.Text); }

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            
            //String temp = new String(label1.Text.ToCharArray());
            int i;
            for (i = label1.Text.Length - 1; i >= 0; i--)
            {
                if ((label1.Text[i]) == '\\' || label1.Text[i] == '/')
                {   break;  }
            }
            System.Diagnostics.Process.Start(label1.Text.Substring(0,i));  
        }

    }
}
