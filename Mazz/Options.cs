using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;


namespace Mazz
{
    public class Options
    {
        public Options() { }

        private int _Width = 32;
        [Category("Settings")]
        [Description("Length of each column")]
        public int Columns { get { return _Width; } set { _Width = value; } }

        private int _Height = 32;
        [Category("Settings")]
        [Description("Length of each row")]
        public int Rows { get { return _Height; } set { _Height = value; } }

        private int _NodeWidth = 10;
        [Category("Settings")]
        [Description("Distance between walls in pixels")]
        public int NodeWidth { get { return _NodeWidth; } set { _NodeWidth = value; } }
    }
}
