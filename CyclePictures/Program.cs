using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyclePictures
{
    /// <summary>
    /// Create a Windows Form that displays pictures that users add from the program to the stack
    /// </summary>
    static class Program
    {
        /// <Accomplished>
        /// Allow the windows to resize properly
        ///     Create a struct that contains a component, it's starting position, and its x, y, width, and height ration to the rest of the form
        ///     OnResize should call a list of these structs and use the ratio members to adjust the component member
        /// Add option to view filepath (popup message)
        /// Fix Popup size for filpath
        /// Give the user an option to change the display style of the image (stretch, vs. don't stretch and option to keep original aspect ratio)
        /// Create Icon for Taskbar
        /// Create Icon for Desktop (File)
        /// Handle Maximization of windows
        /// Get the slideshow to work
        /// Restrict minimum window size
        /// </Accomplished>
        /// 
        /// <ToDo>
        /// Get slideshow options to work (need to design a new form)
        /// Get delete directory to work (need to design a new form, should mark current picture)
        /// Create Form for Error Messages and user static constants to store messages: e.g. InavlidArgument = "Error: ..."
        /// </ToDo>
        /// 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
