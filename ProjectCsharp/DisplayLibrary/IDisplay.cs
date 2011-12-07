using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DisplayLibrary
{
    public interface IDisplay
    {
        void DisplayImage(Image img);
        void DisplayMessage(string msg);
    }
}
