using System;
using System.Drawing;
using System.Windows.Forms;

namespace Csharp_Console_Test_DOTNET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //number of windows created
            int amount = 2048;

            //get the combined size of all monitors on the system
            Rectangle rect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);
            foreach (Screen screen in Screen.AllScreens)
                rect = Rectangle.Union(rect, screen.Bounds);
            //...and then assign those values
            int maxHeight = (int)rect.Height;
            int maxWidth = (int)rect.Width;
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                //basic window parameters
                Form f = new Form();
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.MinimizeBox = false;
                f.MaximizeBox = false;
                f.Text = "P W N E D   N O O B";

                //randomly assign position of window on the screen
                int y = rnd.Next(0,maxHeight);
                int x = rnd.Next(0,maxWidth);
                f.StartPosition = FormStartPosition.Manual;
                f.SetDesktopLocation(x-(maxWidth/Screen.AllScreens.Length), y);

                //text body of the window
                TextBox body = new TextBox();
                body.ReadOnly = true;
                body.Text = "YOU HAVE FAILED YOUR CYBER AWARENESS CHALLENGE, SHIPWRECK. \n NOW PERISH";
                body.TextAlign = HorizontalAlignment.Center;
                body.Width = 300;
                body.Height = 300;
                body.Multiline = true;
                body.Font = new Font("Arial", 24, FontStyle.Bold);
                f.Controls.Add(body);

                //render window, then repeat
                f.Show();
            }
        }
    }
}
