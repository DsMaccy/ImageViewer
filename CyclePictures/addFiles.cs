using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CyclePictures
{
    public partial class addFiles : Form
    {
        Form1 Parent;
        string[] locations;
        public addFiles(Form1 Caller)
        {
            
            InitializeComponent();
            Parent = Caller;
            CancelButton = button1;
            AcceptButton = button2;
            Parent.Enabled = false;      //Prevents the caller from being selected
        }
        protected override void OnFormClosing (FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Do Nothing
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Searches a given directory for 
        /// </summary>
        private void findImages()
        {
            List<String> FolderPaths = new List<String>();
            string[] FPaths;
            string originPath = maskedTextBox1.Text;
            bool subPath = checkBox1.Checked;
            Close();

            if (!subPath)
            {
                FPaths = new string[] { originPath };
            }
            else
            {
                //FolderPaths.Add(originPath);
                try
                {
                    FPaths = Directory.GetFiles(originPath, "*.jpg", SearchOption.AllDirectories);
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException || ex is PathTooLongException)
                    {
                        //Create error message popup that says: "ERROR: Pathname invalid"
                        ErrorMsg Error = new ErrorMsg(this, "Error: Invalid Filepath");
                        Error.Visible = true;
                    }
                    else if (ex is UnauthorizedAccessException || ex is IOException)
                    { /*do nothing*/ }
                    return;

                }
            }

            if (Parent.addDirectory(subPath, FPaths))
            {
                InvalidFilename.Clear();
                Close();
            }
            else
            {
                /*
                 * Create an error message
                 * if (subPath)
                 *  "This folder has no images in it (this message may be the result of a lack of permission)"
                 * else
                 *   if (input was a directory): "No compatible images were found in this folder"
                 *   else: "This file could not be read as an image"
                 *  
                 * "Please try another directory"
                 */
                InvalidFilename.RightToLeft = true;
                InvalidFilename.SetError(maskedTextBox1, "No compatible images were found in this folder");
                //InvalidFilename.
                //InvalidFilename.
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // maskedTextBox1.Text is what the user typed into the text area

            /*Thread t = new Thread(new ThreadStart(findImages));
            t.IsBackground = true;
            t.Start();
            */
            findImages();
        }

        /// <summary>
        /// DO NOTHING
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {/*Do Nothing*/}

        /// <summary>
        /// Open up a Dialog Box to browse for a folder/file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseBut_Click(object sender, EventArgs e)
        {
            //OpenFileDialog OFD = new OpenFileDialog();
            //OFD.ShowDialog();
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowDialog();
            
            maskedTextBox1.Text = FBD.SelectedPath;
        }
    }
}
