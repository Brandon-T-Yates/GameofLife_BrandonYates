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
        #region Initialize Form
        public GridTimeForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Time
        public int Timer
        {
            //creates the getter and setter for time change 
            get { return (int)timerChange.Value; }
            set { timerChange.Value = value; }
        }
        #endregion

        #region Grid Size
        public int Grid
        {
            //creates the getter and setter for grid size change 
            get { return (int)widthChange.Value; }
            set { widthChange.Value = value; }
        }
        #endregion
    }
}
