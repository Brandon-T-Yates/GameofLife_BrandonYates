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
    public partial class RandomSeed : Form
    {
        #region Initialize
        public RandomSeed()
        {
            InitializeComponent();
        }
        #endregion

        #region Getter
        public int GetSeed() => (int)this.numericUpDown1.Value;
        #endregion

        #region Setter
        public void SetSeed(int Num) => this.numericUpDown1.Value = (Decimal)Num;
        #endregion

        #region Randomize Button
        private void randomizeButton_Click(object sender, EventArgs e) => this.numericUpDown1.Value = (Decimal)new Random().Next(int.MinValue, int.MaxValue);
        #endregion

    }
}
