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
        public RandomSeed()
        {
            InitializeComponent();
        }
        public int GetSeedMenu() => (int)this.numericUpDown1.Value;

        public void SetSeedMenu(int Num) => this.numericUpDown1.Value = (Decimal)Num;

        private void randomizeButton_Click(object sender, EventArgs e) => this.numericUpDown1.Value = (Decimal)new Random().Next(int.MinValue, int.MaxValue);

        //public int Seed
        //{
        //    get => (int)this.numericUpDown1.Value;
        //    set => this.numericUpDown1.Value = (Decimal)value;
        //}
        //private void button1_Click(object sender, EventArgs e) => this.numericUpDown1.Value = (Decimal)new Random().Next(int.MinValue, int.MaxValue);

        //public void Randomize(int seed)
        //{
        //    //this.universe.Randomize(seed);
        //    //if (this.Randomized == null)
        //    //    return;
        //    //this.Randomized((object)this, new UniverseEventArgs(this.universe));
        //}
        //private void randomizeButton_Click(object sender, EventArgs e)
        //{
        //    //RandomSeed randomSeed = new RandomSeed();
        //    //randomSeed.Seed = this.seed;
        //    //if (DialogResult.OK != randomSeed.ShowDialog())
        //    //    return;
        //    //this.seed = randomSeed.Seed;
        //    //this.golControl1.Randomize(this.seed);
        //}
    }
}
