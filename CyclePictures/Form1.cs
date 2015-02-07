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
//using System.Timers;

namespace CyclePictures
{
    
    public partial class Form1 : Form
    {
        private List<string> ImageList;
        private int index;
        //private float button1_Ratio;
        
        private int storedWidth;
        private int storedHeight;
        public static int ButtonPadding = 10;

        private bool Slideshow;
        private int offsetTime;
        ImageChange SlideshowOption;
        System.Windows.Forms.Timer Time;
        //Timer Time;
        Random RIndGen;
        
        private enum ImageChange
        {
            Random = 0x00,
            Next = 0x01,
            Backwards = 0x02
        }

        public Form1()
        {
            ImageList = new List<string>();
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;
            index = -1;
            
            
            storedWidth = this.Width;
            storedHeight = this.Height;
            button2.AutoSize = true;
            

            //Handles Slideshow
            Time = new Timer();
            SlideshowOption = ImageChange.Next;
            Time.Tick += new EventHandler(SlideChange);

            RIndGen = new Random();     //Need to generate a more complicated random number generator
            Slideshow = false;
            offsetTime = 5000;  // Default 5 Seconds
            
            // Handles Key Events
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
        }
        private void SlideChange(object caller, /*System.Timers.ElapsedEventArgs*/EventArgs args)
        {
            switch (SlideshowOption)
            {
                case ImageChange.Next:
                    changeIndex(1);
                    break;
                case ImageChange.Backwards:
                    changeIndex(1);
                    break;
                case ImageChange.Random:
                    index = RIndGen.Next(ImageList.Count);
                    break;
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Right) { changeIndex(1); }
            else if (e.KeyChar == (char)Keys.Left) { changeIndex(-1); }
            else if (e.KeyChar == (char)Keys.Escape)
            { Close(); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        //override maximize
        protected override void OnMaximumSizeChanged(EventArgs e)
        {
            base.OnMaximumSizeChanged(e);
            throw new OutOfMemoryException();
        }
        

        protected override void OnClick(EventArgs e)
        {
            //Rectangle R = new Rectangle();

            if (this.ClientRectangle.Contains(MousePosition))
            {
                if (!toolStrip1.Visible) { toolStrip1.Visible = true; }
                if (!button1.Visible) { button1.Visible = true; }
                if (!button2.Visible) { button2.Visible = true; }
                if (!button3.Visible) { button3.Visible = true; }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Right)
            {
                //Show the right click form
                contextMenuStrip1.Visible = true;
                contextMenuStrip1.Top = e.Y + this.Top + contextMenuStrip1.Height*3/4;
                contextMenuStrip1.Left = e.X + this.Left;// + contextMenuStrip1.Width * 3 / 4;
                Console.WriteLine(e.X);
                Console.WriteLine(e.Y);
                Console.WriteLine(this.Top);
                Console.WriteLine(this.Left);
                //contextMenuStrip1.
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                // Check your window state here
                Console.WriteLine(m.WParam);
                if (m.WParam == new IntPtr(0xF032) || m.WParam == new IntPtr(0xF030)) //Maximize event - Double Clicking Window (0xF032) OR Maximize event - SC_MAXIMIZE from Winuser.h (0xF030)
                {
                    // THe window is being maximized
                    storedWidth = this.Width;
                    storedHeight = this.Height;

                    SizeF scale = new SizeF(Screen.GetBounds(this).Width / (float)storedWidth,     // Scale new width over old width where NEW width is the width of the screen
                          1.0f);                                                                   // Keep buttons and toolbars the same height

                    button1.Scale(scale);
                    button2.Scale(scale);
                    button3.Scale(scale);
                    toolStrip1.Scale(scale);


                }
                else if (m.WParam == new IntPtr(0xF122) || m.WParam == new IntPtr(0xF120)) // Un-maximize event - SC_RESTORE from Winuser.h (0xF122) OR Un-maximize event - SC_RESTORE from Winuser.h (0xF120)
                {
                    // THe window is being restored after maximized
                    SizeF scale = new SizeF((float)storedWidth / Screen.GetBounds(this).Width,     // Scale new width over old width where OLD width is the width of the screen
                          1.0f);                                                                   // Keep buttons and toolbars the same height

                    button1.Scale(scale);
                    button2.Scale(scale);
                    button3.Scale(scale);
                    toolStrip1.Scale(scale);
                }
            }
            base.WndProc(ref m);
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            storedWidth = this.Width;
            storedHeight = this.Height;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            /*
            button1
            base.OnResize(e);
            toolStrip1.Resize = Resize;
            button1.Size = 5;*/
            toolStrip1.Width = this.Width;
            //button1.Scale(new SizeF(Height, Width));
            SizeF scale = new SizeF( (float)Width / (float)storedWidth,     // Scale new width over old width
                                      1.0f );                               // Keep buttons and toolbars the same height
            if (storedWidth != 0 && storedHeight != 0)
            {
                button1.Scale(scale);
                button2.Scale(scale);
                button3.Scale(scale);
                toolStrip1.Scale(scale);
                
            }
            /*
            if (this.WindowState == FormWindowState.Maximized)
            {
                //button1.Location = new Point(ButtonPadding - 10, button2.Location.Y);
                button3.Location = new Point (Width - button1.Location.X, button2.Location.Y);
                button2.Location = new Point (Width/2 - button3.Width/2, button3.Location.Y);;
            }*/
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            //Do Nothing
        }

        private void Hide_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeIndex(1);
        }

        private void addDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt user to search for picture or folder with pictures in it.
            //Create a method to go through folders to find all pictures.
            //Create new Form
            addFiles aF = new addFiles(this);
            aF.Visible = true;
        }
        /// <summary>
        /// Adds the filenames from <paramref name="pathNames"/> to the image list.
        /// If a path cannot be converted into an image, it is ignored and a warning message appears.
        /// Error messages should be produced by the caller (if desired) of the method in the event that the method returns false
        /// </summary>
        /// <param name="checkSubFolders"></param>
        /// <param name="pathNames"></param>
        public bool addDirectory(bool checkSubFolders, params string[] pathNames)
        {
            bool r = false;
            bool warning = false;
            Image temp;
            // If input lists only 1 filepath and that filepath is a directory (folder)
            if (pathNames.Length == 1 && Directory.Exists(pathNames[0]))
            {
                /*
                    * Go through the files inside pathNames[0] and check for image files
                    * Directory.
                    */
                IEnumerator<string> directory;
                try
                {
                    directory = Directory.EnumerateFileSystemEntries(pathNames[0]).GetEnumerator();
                }
                catch (Exception e)
                {
                    if (e is UnauthorizedAccessException)
                    {
                        ErrorMsg Error = new ErrorMsg(this, "Error: insufficient permission to access filepath " + e.ToString());
                        Error.Visible = true;
                        return false;
                    }
                    return false;
                }
                //Go through the directory
                while(directory.MoveNext())
                {
                    
                    if (Directory.Exists(directory.Current))
                    {
                        //If the folder has subfolders, run through if the checkbox was checked
                        if (checkSubFolders)
                        {
                            if (addDirectory(true, directory.Current))
                            { r = true; }
                        }
                    }
                    else
                    {
                        //Check if the path is a valid image, and if so add it
                        try 
                        {
                            temp = Image.FromFile(directory.Current);
                            ImageList.Add(directory.Current);
                            r = true;
                        }
                        catch (Exception){}
                    }
                }
            }
            else if (pathNames.Length == 1 && !Directory.Exists(pathNames[0]))
            {
                //Check if the path is a valid image, and if so add it
                try
                {
                    
                    temp = Image.FromFile(pathNames[0]);
                    ImageList.Add(pathNames[0]);
                    r = true;
                }
                catch (Exception e) { }
            }
            else if (pathNames.Length > 1)
            {
                for (int i = 0; i < pathNames.Length; i++)
                {
                    if (Directory.Exists(pathNames[i]))
                    {
                        if (checkSubFolders)
                        {
                            addDirectory(true, pathNames[i]);
                        }
                    }
                    else
                    {
                        try
                        {
                            //Check if the path is a valid image, and if so add it
                            temp = Image.FromFile(pathNames[i]);
                            ImageList.Add(pathNames[i]);
                            if (!r) { r = true; }
                        }
                        catch (Exception)
                        { if (!warning) { warning = true; } }
                    }
                }
            }
            /*
            if (checkSubFolders)
            {
                Directory.
            }
            */
            if (warning && r)
            {
                //Create popup warning message:
                /* if (pathNames.Length == 1)
                * ""
                * "Warning, 1 or more"
                * 
                */
                ErrorMsg Warning = new ErrorMsg(this, "Warning: one or more files were unable to be read");
                Warning.Visible = true;
            }

            if (r && BackgroundImage == null)
            {
                if (index == -1)
                { index = 0; }
                BackgroundImage = Image.FromFile(ImageList[index]);
            }
            return r;
        }

        private void button1_Click(object sender, EventArgs e)
        {   changeIndex(-1);    }

        /// <summary>
        /// Changes the position of the current image by the <paramref name="offset"/> value
        /// If <paramref name="offset"/> is positive, go through normal ordering of the list.
        /// If <paramref name="offset"/> is negative, go through the reverse order of the list
        /// </summary>
        /// <param name="offset"></param>
        private void changeIndex(int offset)
        {
            if (ImageList.Count == 0)
            { return; }

            index += offset;
            if (offset > 0)
            {
                while (index >= ImageList.Count)
                { index -= ImageList.Count; }
            }
            if (offset < 0)
            {
                while (index < 0)
                { index += ImageList.Count; }
            }
            BackgroundImage = Image.FromFile(ImageList[index]);
        }

        /// <summary>
        /// Set the value of index to <paramref name="i"/>
        /// Throw IndexOutOfRangeException if i is not within range: [0, Length)
        /// </summary>
        /// <param name="i"></param>
        private void setIndex(int i)
        {
            if (i >= ImageList.Count || i < 0)
            { throw new IndexOutOfRangeException(); }

            index = i;
        }

        private void deleteDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Allow this form to be enabled when you create the form but disable the deleteDirectory Button
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Slideshow Options
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Set a slideshow so that
            if (button2.Text == "Slideshow")
            {
                //Change text and resize button
                button2.Text = "End Slideshow";
                button2.Width += 20;
                button2.Location = new Point(button2.Location.X - 10, button2.Location.Y);

                //Add an offset to the time so that the image changes every X seconds
                Slideshow = true;
                Time.Start();
                Time.Interval = offsetTime;
            }
            else
            {
                //Change text and resize button
                button2.Text = "Slideshow";
                button2.Width -= 20;
                button2.Location = new Point(button2.Location.X + 10, button2.Location.Y);

                //Stop time change
                Slideshow = false;
                Time.Stop();
            }
        }

        
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
            
        }
        
        /// <summary>
        /// Corresponds to the Display Filename button in toolbar
        /// Creates popup window that shows filename and gives user the ability to copy the name to the clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                FileName F = new FileName(ImageList[index], this);
                F.Visible = true;
            }
            else 
            {
                //Produce Error Message that says: "ERROR: No image files loaded"
            }
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Center;
        }
        private void repeatingTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Tile;
        }

        private void stretchDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e) {/*Do Nothing*/ }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        
    }
}
