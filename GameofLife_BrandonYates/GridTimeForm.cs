using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameofLife_BrandonYates
{
    public partial class GridTimeForm : Form
    {
        public GridTimeForm()
        {
            InitializeComponent();
        }

        public int Timer
        {
            get { return (int)timerChange.Value; }
            set { timerChange.Value = value; }
        }

        public int Grid
        {
            get { return (int)widthChange.Value; }
            set { widthChange.Value = value; }
        }
    }
}
