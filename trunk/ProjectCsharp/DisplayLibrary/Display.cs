using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DisplayLibrary
{
    public class Display : IDisplay
    {

        private PictureBox picturebox;
        private TextBox textbox;

        public Display(PictureBox picturebox, TextBox textbox)
        {
            this.picturebox = picturebox;
            this.textbox = textbox;
        }
        
        public void DisplayImage(Image img)
        {
            this.picturebox.Image = img;
        }


        public void DisplayMessage(string msg)
        {
            this.textbox.Text = msg;
        }
    }
}
