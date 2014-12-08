using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mazz
{
    public partial class Form1 : Form
    {
        private MazGen _MazGen;
        private Options _Options;
        private Bitmap _Bitmap;

        public Form1()
        {
            InitializeComponent();
            _Options = new Options();

            propertyGrid.PropertySort = PropertySort.Categorized;
            propertyGrid.SelectedObject = _Options;          
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            _Bitmap = new Bitmap(_Options.Rows * (_Options.NodeWidth) + 10, 
                _Options.Columns * (_Options.NodeWidth) + 10);

            Graphics _Graphics = Graphics.FromImage((Image)_Bitmap);

            _MazGen = null;
            _Graphics.DrawRectangle(Pens.Blue, 5, 5, _Options.Rows * _Options.NodeWidth, 
                _Options.Columns * _Options.NodeWidth);
            _MazGen = new MazGen(_Options.Rows, _Options.Columns, _Options.NodeWidth);
            _MazGen.Draw(_Graphics);

            pictureBox.Image = (Image)_Bitmap;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    
                    break;
                case MouseButtons.Right:

                    break;
            }
        }
    }
}
