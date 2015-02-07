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
    public partial class ErrorMsg : Form
    {
        private const string genericMessage = "An error has occurred";
        private Form Caller;
        public ErrorMsg(Form Parent)
        {
            InitializeComponent();
            Error.Text = genericMessage;
            Caller = Parent;
            Caller.Enabled = false;
        }

        public ErrorMsg(Form Caller, string message)
        {
            InitializeComponent();
            Error.Text = message;
            switch (message.Substring(0, 7))
            {
                case "Warning":
                case "warning":
                    this.Icon = new Icon("C:/Users/Dylan/Desktop/Programming Stuff/Visual Studio 2013/Projects/CyclePictures/CyclePictures/Warning_Image.ico");
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        { /*Do nothing*/ }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Caller.Enabled = true;
        }
    }
}
