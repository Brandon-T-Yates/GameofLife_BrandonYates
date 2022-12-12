using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

        #region Width Height and Timer
        public int Width
        {
            get { return (int)widthChange.Value; }
            set { widthChange.Value = value; }
        }

        public int Height
        {
            get { return (int)heightChange.Value; }
            set { heightChange.Value = value; }
        }

        public int Timer
        {
            get { return (int)timerChange.Value; }
            set { timerChange.Value = value; }
        }
        #endregion
  
    }
}
