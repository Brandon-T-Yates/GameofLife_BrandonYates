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
        #region NumericUpDown
        //private NumericUpDown timer;
        //private NumericUpDown width;
        //private NumericUpDown height;
        #endregion

        #region Initialize Form
        public GridTimeForm()
        {
            //this.timer = new NumericUpDown();
            //this.width = new NumericUpDown();
            //this.height = new NumericUpDown();
            //this.timer.Value = 1;
            InitializeComponent();
        }
        #endregion

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
        #region Time
        ////creates the getter and setter for time change
        //public int GetTime() => (int)this.timer.Value;
        //public void SetTime(int time) => this.timer.Value = (Decimal)time;
        //#endregion

        //#region Grid Size
        //public int GetGridWidth() => (int)this.width.Value;
        //public void SetGridWidth(int widthV) => this.width.Value = (Decimal) widthV;
        //public int GetGridHeight() => (int)this.height.Value;
        //public void SetGridHeight(int heightV) => this.height.Value = (Decimal)heightV;
        #endregion
    }
}
