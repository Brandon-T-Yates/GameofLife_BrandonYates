using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameofLife_BrandonYates
{
    public partial class Form1 : Form
    {
        #region Arrays
        // The universe arrays
        static int Yset = 20;
        static int Xset = 20;
        bool[,] universe = new bool[Form1.Xset, Form1.Yset];
        bool[,] scratchPad = new bool[Form1.Xset, Form1.Yset];
        bool[,] faded = new bool[Form1.Xset, Form1.Yset];
        bool[,] Blank = new bool[Form1.Xset, Form1.Yset];
        bool scratched = true;
        bool PackType = true;
        #endregion

        #region Colors
        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;
        Color backgroundColor = Color.White;
        #endregion

        #region Timer
        // The Timer class
        Timer timer = new Timer();
        #endregion

        #region Ints & Bools
        // Generation count
        int Seed = 5899632;
        bool GridOn = true;
        bool CounterVisible = true;
        bool HudToggle = true;
        int generations = 0;
        int LivingCells = 0;

        public void SetX(int x) => Form1.Xset = x;

        public void SetY(int y) => Form1.Yset = y;
        #endregion

        #region Form
        public Form1()  
        {
            InitializeComponent();

            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;
            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
            this.cellsAlive.Text = "Living Cells = " + this.LivingCells.ToString();
        }
        #endregion

        #region NextGen
        // Calculate the next generation of cells
        private void NextGeneration()
        {
            int livingCells = 0;
            Checker();

            for (int y = 0; y < universe.GetLength(0); y++)
            {
                //Go throught the cells 
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[y, x] = scratchPad[y, x];

                    if (scratchPad[y, x]) livingCells++;
                }
            }
            this.Blank = this.universe;
            this.universe = scratchPad;
            this.scratchPad = this.Blank;
            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            this.cellsAlive.Text = "Living Cells: " + this.LivingCells.ToString();
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region PrevGen
        // Calculate the next generation of cells
        //private void PreviousGeneration()
        //{
        //    int livingCells = 0;
        //    Checker();

        //    for (int y = 0; y < universe.GetLength(0); y--)
        //    {
        //        //Go throught the cells 
        //        for (int x = 0; x < universe.GetLength(0); x--)
        //        {
        //            universe[y, x] = scratchPad[y, x];

        //            if (scratchPad[y, x]) livingCells--;
        //        }
        //    }
        //    this.universe = scratchPad;
        //    // Increment generation count
        //    generations--;

        //    // Update status strip generations
        //    toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
        //    this.graphicsPanel1.Invalidate();
        //}
        #endregion

        #region Timer
        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
            countLivingCells();
        }
        #endregion

        #region Grid
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                        //e.Graphics.DrawString(this.CountNeighborsFinite(x, y).ToString(), this.Font, Brushes.Black, (RectangleF)cellRect);
                    }

                    // Outline the cell with a pen
                    if (GridOn == true)
                    {
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }
                    Font font = new Font("Arial", 7f);
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    if (CounterVisible == true)
                    {
                        e.Graphics.DrawString(CountNeighborsFinite(x, y).ToString(), Font, Brushes.DarkRed,cellRect, stringFormat);
                    }
                    if (HudToggle == true)
                    {
                        this.PrintHUD(e);
                    }
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }
        #endregion

        #region Turning Cells
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                this.countLivingCells();
                // Tell Windows you need to repaint

                graphicsPanel1.Invalidate();
            }
        }
        #endregion

        #region Finite Rules
        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0) { continue; }
                    // if xCheck is less than 0 then continue
                    // if yCheck is less than 0 then continue
                    if (xCheck < 0 || yCheck < 0) { continue; }
                    // if xCheck is greater than or equal too xLen then continue
                    // if yCheck is greater than or equal too yLen then continue
                    if (xCheck >= xLen || yCheck >= yLen) { continue; }

                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }
        #endregion

        #region Counting LivingCells
        private void countLivingCells()
        {
            //Counts the total number of living cells
            this.LivingCells = 0;
            for (int x = 0; x < this.universe.GetLength(1); ++x)
            {
                for (int y = 0; y < this.universe.GetLength(0); ++y)
                {
                    if (this.universe[y, x])
                        ++this.LivingCells;
                }
            }
        }
        #endregion

        #region Checker
        private void Checker()
        {
            //The ruling for how the cells are supposed to act under Finite grid
            scratchPad = new bool[universe.GetLength(0), universe.GetLength(1)];

            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int i = 0; i < universe.GetLength(1); i++)
                {
                    if (PackType == true)
                    {
                    //    if ((CountNeighborsToroidal(x, i) < 2) && universe[x, i])
                    //    {
                    //        scratchPad[x, i] = false;
                    //    }
                    //    else if ((CountNeighborsToroidal(x, i) > 3) && universe[x, i])
                    //    {
                    //        scratchPad[x, i] = false;
                    //    }
                    //    else if ((CountNeighborsToroidal(x, i) == 2 || CountNeighborsToroidal(x, i) == 3) && universe[x, i])
                    //    {
                    //        scratchPad[x, i] = true;
                    //    }
                    //    else if ((CountNeighborsToroidal(x, i) == 3) && universe[x, i] == false)
                    //    {
                    //        scratchPad[x, i] = true;
                    //    }

                    //}
                    //else
                    //{
                        if ((CountNeighborsFinite(x, i) < 2) && universe[x, i])
                        {
                            scratchPad[x, i] = false;
                        }
                        else if ((CountNeighborsFinite(x, i) > 3) && universe[x, i])
                        {
                            scratchPad[x, i] = false;
                        }
                        else if ((CountNeighborsFinite(x, i) == 2 || CountNeighborsFinite(x, i) == 3) && universe[x, i])
                        {
                            scratchPad[x, i] = true;
                        }
                        else if ((CountNeighborsFinite(x, i) == 3) && universe[x, i] == false)
                        {
                            scratchPad[x, i] = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region Toroidal Rules
        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    // if xOffset and yOffset are both equal to 0 then continue
                    if ((xCheck == 0) && (yCheck == 0)) { continue; }
                    // if xCheck is less than 0 then set to xLen - 1
                    // if yCheck is less than 0 then set to yLen - 1
                    if (xCheck < 0 && yCheck < 0)
                    {
                        xCheck = xLen - 1;
                        yCheck = yLen - 1;
                    }
                    // if xCheck is greater than or equal too xLen then set to 0
                    // if yCheck is greater than or equal too yLen then set to 0
                    if (xCheck >= xLen && yCheck >= yLen)
                    {
                        xCheck = 0;
                        yCheck = 0;
                    }
                    if (universe[xCheck, yCheck] == true) count++;
                    this.graphicsPanel1.Invalidate();
                }
            }
            return count;
        }
        #endregion

        #region Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Used to close the program
            this.Close();
        }
        #endregion

        #region Play
        private void playButton_Click(object sender, EventArgs e)
        {
            //Runs the program
            this.timer.Enabled = true;
        }
        #endregion

        #region Pause
        private void pauseButton_Click(object sender, EventArgs e)
        {
            //Pauses the generation count
            this.countLivingCells();
            this.timer.Enabled = false;
        }
        #endregion
         
        #region Next
        private void nextButton_Click(object sender, EventArgs e)
        {
            // Goes to the next generation of cell life
            this.countLivingCells();
            this.NextGeneration();
        }

        #endregion

        #region Prev
        //private void previousButton1_Click(object sender, EventArgs e)
        //{
        //    this.PreviousGeneration();
        //}
        #endregion

        #region Empty
        private void NewGrid_Click(object sender, EventArgs e)
        { 
            // Creates a new clean universe
            this.universe = new bool[20, 20];
            this.generations = 0;
            this.toolStripStatusLabelGenerations.Text = "Generations = " + this.generations.ToString();
            this.graphicsPanel1.Invalidate();
        }

        private void fileNew_Click(object sender, EventArgs e)
        {
            // Creates a new clean universe
            this.universe = new bool[20, 20];
            this.generations = 0;
            this.toolStripStatusLabelGenerations.Text = "Generations = " + this.generations.ToString();
            this.graphicsPanel1.Invalidate();
        }


        #endregion

        #region Form Closing
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Auto saves color when clicking the X on the window
            Properties.Settings.Default.PanelColor = gridColor;
            Properties.Settings.Default.PanelColor = cellColor;
            Properties.Settings.Default.PanelColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Living Cell Count
        private void cellsAlive_Click(object sender, EventArgs e)
        {
            // Handles the counting of the cells on the window
            this.LivingCells = 0;
            for (int x = 0; x < this.universe.GetLength(1); ++x)
            {
                for (int y = 0; y < this.universe.GetLength(0); ++y)
                {
                    if (this.universe[y, x])
                    {
                        ++this.LivingCells;
                        this.cellsAlive.Text = "Living Cells = " + this.LivingCells.ToString();
                    }
                }
            }
            this.countLivingCells();
        }
        #endregion

        #region Grid Color
        private void gridColorButton_Click(object sender, EventArgs e)
        {
            //Promts dialog and allows color change based on user selection 
            ColorDialog dlg = new ColorDialog();
            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
            }
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region Cell Color
        private void cellColorButton_Click(object sender, EventArgs e)
        {
            //Promts dialog and allows color change based on user selection 
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
            this.graphicsPanel1.Invalidate();
        }

        #endregion

        #region Background Color
        private void backgroundColorTool_Click(object sender, EventArgs e)
        {
            //Promts dialog and allows color change based on user selection 
            ColorDialog dlg = new ColorDialog();
            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
        }
        #endregion

        #region Save File
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All Files|*.*|Cells|*.cells";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.DefaultExt = "cells";
            if (DialogResult.OK != saveFileDialog.ShowDialog())
                return;
            StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
            streamWriter.WriteLine(string.Format("!{0}", (object)DateTime.Now));
            for (int index1 = 0; index1 < this.universe.GetLength(1); ++index1)
            {
                string str = string.Empty;
                for (int index2 = 0; index2 < this.universe.GetLength(0); ++index2)
                    str = !this.universe[index2, index1] ? str + "O" : str + "@";
                streamWriter.WriteLine(str);
            }
            streamWriter.Close();
        }

        private void fileSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All Files|*.*|Cells|*.cells";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.DefaultExt = "cells";
            if (DialogResult.OK != saveFileDialog.ShowDialog())
                return;
            StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
            streamWriter.WriteLine(string.Format("!{0}", (object)DateTime.Now));
            for (int index1 = 0; index1 < this.universe.GetLength(1); ++index1)
            {
                string str = string.Empty;
                for (int index2 = 0; index2 < this.universe.GetLength(0); ++index2)
                    str = !this.universe[index2, index1] ? str + "O" : str + "@";
                streamWriter.WriteLine(str);
            }
            streamWriter.Close();
        }

        #endregion

        #region Open File
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*|Cells|*.cells";
            openFileDialog.FilterIndex = 2;
            if (DialogResult.OK != openFileDialog.ShowDialog())
                return;
            StreamReader streamReader = new StreamReader(openFileDialog.FileName);
            int length1 = 0;
            int length2 = 0;
            while (!streamReader.EndOfStream)
            {
                string str = streamReader.ReadLine();
                for (int index = 0; index < str.Length; ++index)
                {
                    if (str[0] != '!')
                    {
                        length1 = str.Length;
                        length2 = index + 1;
                    }
                }
            }
            this.universe = new bool[length1, length2];
            this.scratchPad = new bool[length1, length2];
            int index1 = 0;
            streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
            while (!streamReader.EndOfStream)
            {
                string str = streamReader.ReadLine();
                if (str[0] != '!')
                {
                    for (int index2 = 0; index2 < str.Length; ++index2)
                        this.universe[index2, index1] = str[index2] == '@';
                    ++index1;
                }
            }
            this.graphicsPanel1.Invalidate();
            streamReader.Close();
        }

        private void fileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*|Cells|*.cells";
            openFileDialog.FilterIndex = 2;
            if (DialogResult.OK != openFileDialog.ShowDialog())
                return;
            StreamReader streamReader = new StreamReader(openFileDialog.FileName);
            int length1 = 0;
            int length2 = 0;
            while (!streamReader.EndOfStream)
            {
                string str = streamReader.ReadLine();
                for (int index = 0; index < str.Length; ++index)
                {
                    if (str[0] != '!')
                    {
                        length1 = str.Length;
                        length2 = index + 1;
                    }
                }
            }
            this.universe = new bool[length1, length2];
            this.scratchPad = new bool[length1, length2];
            int index1 = 0;
            streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
            while (!streamReader.EndOfStream)
            {
                string str = streamReader.ReadLine();
                if (str[0] != '!')
                {
                    for (int index2 = 0; index2 < str.Length; ++index2)
                        this.universe[index2, index1] = str[index2] == '@';
                    ++index1;
                }
            }
            this.graphicsPanel1.Invalidate();
            streamReader.Close();
        }


        #endregion

        #region Reset
        private void resetButton_Click(object sender, EventArgs e)
        {
            // Resets the background color to the default color save on .exe
            Properties.Settings.Default.Reset();
            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;
        }
        #endregion

        #region Reload
        private void reloadButton_Click(object sender, EventArgs e)
        {
            // Reloads to the last color change that was saved in local files
            Properties.Settings.Default.Reload();
            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;
        }
        #endregion

        #region Random Seed
        private void randomSeed_Click(object sender, EventArgs e)
        {
            RandomSeed setSeed = new RandomSeed();
            setSeed.SetSeed(this.Seed);
            if (DialogResult.OK != setSeed.ShowDialog())
                return;
            this.Seed = setSeed.GetSeed();
            this.Randomize(this.Seed);
            this.graphicsPanel1.Invalidate();
        }
        private void Randomize(int Seed)
        {
            Random random1 = new Random(Seed);
            Random random2 = new Random(Seed);
            for (int index1 = 0; index1 < this.universe.GetLength(1); ++index1)
            {
                for (int index2 = 0; index2 < this.universe.GetLength(0); ++index2)
                {
                    if (random2.Next(2) > 0)
                        this.universe[index2, index1] = true;
                }
            }
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region Random Time
        private void randomTime_Click(object sender, EventArgs e)
        {
            // Randomly generates living cells on the grid
            Random random = new Random();
            for (int y = 0; y < this.universe.GetLength(0); ++y)
            {
                for (int x = 0; x < this.universe.GetLength(1); ++x)
                    this.universe[y, x] = random.Next(0, 2) != 0;
            }
            this.countLivingCells();
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region Context Menu Stip
        private void rightClickRandom_Click(object sender, EventArgs e)
        {
            //Used to make right click randomize buttom
            Random random = new Random();
            for (int y = 0; y < this.universe.GetLength(0); ++y)
            {
                for (int x = 0; x < this.universe.GetLength(1); ++x)
                    this.universe[y, x] = random.Next(0, 2) != 0;
            }
            this.countLivingCells();
            this.graphicsPanel1.Invalidate();
        }

        private void rightClickGrid_Click(object sender, EventArgs e)
        {
            //Used to make right click Grid Color Change
            ColorDialog dlg = new ColorDialog();
            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
            }
            this.graphicsPanel1.Invalidate();
        }

        private void rightClickCell_Click(object sender, EventArgs e)
        {
            //Used to make right click Cell Color Change
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
            this.graphicsPanel1.Invalidate();
        }

        private void rightClickBG_Click(object sender, EventArgs e)
        {
            //Used to make right click Background/ Dead Cells Color Change
            ColorDialog dlg = new ColorDialog();
            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
        }

        #endregion

        #region Grid & Time Change
        private void gridAndTimeButton_Click(object sender, EventArgs e)
        {
            int xset = Form1.Xset;
            int yset = Form1.Yset;
            GridTimeForm gridTime = new GridTimeForm();
            gridTime.SetTime(this.timer.Interval);
            gridTime.SetGridWidth(Form1.Xset);
            gridTime.SetGridHeight(Form1.Yset);
            if (DialogResult.OK == gridTime.ShowDialog())
            {
                return;
                //this.timer.Interval = gridTime.GetTime();
                //this.universe = new bool[gridTime.GetGridWidth(), gridTime.GetGridHeight()];
            }
            this.timer.Interval = gridTime.GetTime();
            this.SetY(gridTime.GetGridHeight());
            this.SetX(gridTime.GetGridWidth());
            if (xset != Form1.Xset || yset != Form1.Yset)
            {
                this.timer.Enabled = false;
                this.universe = new bool[gridTime.GetGridWidth(), gridTime.GetGridHeight()];
                this.scratchPad = new bool[gridTime.GetGridWidth(), gridTime.GetGridHeight()];
                this.Blank = new bool[gridTime.GetGridWidth(), gridTime.GetGridHeight()];
                this.faded = new bool[gridTime.GetGridWidth(), gridTime.GetGridHeight()];
                this.timer.Enabled = false;
                this.generations = -1;
                this.NextGeneration();
            } 
        }


        #endregion

        #region Neighbor Counting
        private void neighborCountToggle_Click(object sender, EventArgs e)
        {
            this.CounterVisible = !this.CounterVisible;
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region Print HUD
        public void PrintHUD(PaintEventArgs e)
        {
            Font font = new Font("Arial", 12.5f);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            Rectangle layoutRectangle = new Rectangle(0, 320, 300, 200);
            string str = string.Format("Generations: {0}\nCell Count: {1}\nBoundary Type: {2}\nUniverse Size: {3}/{4}", (object)this.generations, this.LivingCells, (object)this.UniverseType(), (object)Form1.Xset, (object)Form1.Yset);
            e.Graphics.DrawString(str.ToString(), font, Brushes.Orange, (RectangleF)layoutRectangle, format);
        }
        #endregion

        #region Universe Type
        public string UniverseType() => !this.PackType ? "Toroidal" : "Finite";
        #endregion

        #region HUD Toggle
        private void hUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.HudToggle = !this.HudToggle;
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region Finite Toggle
        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PackType = true;
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region Toroidal Toggle
        private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PackType = false;
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region Grid Toggle
        private void gridToggle_Click(object sender, EventArgs e)
        {
            this.GridOn = !this.GridOn;
            this.graphicsPanel1.Invalidate();
        }

        #endregion

    }
}