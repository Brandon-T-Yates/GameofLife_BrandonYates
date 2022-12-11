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
       
        private NumericUpDown timer;
        private NumericUpDown width;
        private NumericUpDown height;

        #region Initialize Form
        public GridTimeForm()
        {
            this.timer = new NumericUpDown();
            this.width = new NumericUpDown();
            this.height = new NumericUpDown();
            this.timer.Value = 1;
            InitializeComponent();
        }
        #endregion

        #region Time
        //creates the getter and setter for time change
        public int GetTime() => (int)this.timer.Value;
        public void SetTime(int time) => this.timer.Value = (Decimal)time;
        #endregion

        #region Grid Size
        public int GetGridWidth() => (int)this.width.Value;
        public void SetGridWidth(int widthV) => this.width.Value = (Decimal) widthV;
        public int GetGridHeight() => (int)this.height.Value;
        public void SetGridHeight(int heightV) => this.height.Value = (Decimal)heightV;
        #endregion

    }
}
