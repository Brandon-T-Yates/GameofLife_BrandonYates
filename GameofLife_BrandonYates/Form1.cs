using GameofLife_BrandonYates.Properties;
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
        bool border = true;

        public void SetX(int x) => Form1.Xset = x;

        public void SetY(int y) => Form1.Yset = y;
        #endregion

        #region Form
        public Form1()  
        {
            InitializeComponent();
           
            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;
            timer.Interval = Properties.Settings.Default.Timer;
            Yset = Properties.Settings.Default.Height;
            Xset = Properties.Settings.Default.Width;
            cellColor = Properties.Settings.Default.CellColor;
            gridColor = Properties.Settings.Default.GridColor;
            bool[,] tempGrid = new bool[Width, Height];
            bool[,] tempGrid2 = new bool[Width, Height];
            //universe = tempGrid;
            //scratchPad = tempGrid2;
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
            Array.Clear(scratchPad, 0, scratchPad.Length);
            for (int y = 0; y < universe.GetLength(0); y++)
            {
                //Go throught the cells 
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int neighborCount;
                    if (border)
                    {
                        neighborCount = CountNeighborsFinite(x, y);
                    }
                    else
                    {
                        neighborCount = CountNeighborsToroidal(x, y);
                    }
                    bool cell = universe[x, y];

                    if (cell == true && neighborCount < 2)
                    {
                        scratchPad.SetValue(false, x, y);
                    }
                    if (cell == true && neighborCount > 3)
                    {
                        scratchPad.SetValue(false, x, y);
                    }
                    if (cell == true && neighborCount == 2 || neighborCount == 3)
                    {
                        scratchPad.SetValue(true, x, y);
                    }
                    if (cell == false && neighborCount == 3)
                    {
                        scratchPad.SetValue(true, x, y);
                    }
                }
            }
            bool[,] temp = universe;
            //this.Blank = this.universe;+
            universe = scratchPad;
            scratchPad = temp;

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

        #region Grid Design
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

        #region Graphics Panel
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
                    if (xCheck < 0) { continue; }
                    if (yCheck < 0) { continue; }
                    // if xCheck is greater than or equal too xLen then continue
                    // if yCheck is greater than or equal too yLen then continue
                    if (xCheck >= xLen) { continue; }
                    if (yCheck >= yLen) { continue; }

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
                    if ((xOffset == 0 && yOffset == 0)) { continue; }
                    // if xCheck is less than 0 then set to xLen - 1
                    // if yCheck is less than 0 then set to yLen - 1
                    if (xCheck < 0)
                    {
                        xCheck = xLen - 1;
                    }
                    if (yCheck < 0)
                    {
                        yCheck = yLen - 1;
                    }
                    // if xCheck is greater than or equal too xLen then set to 0
                    // if yCheck is greater than or equal too yLen then set to 0
                    if (xCheck >= xLen)
                    {
                        xCheck = 0;
                    }
                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }
                    if (universe[xCheck, yCheck] == true) count++;
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
            this.timer.Enabled = false;
            this.countLivingCells();
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
            Properties.Settings.Default.Timer = timer.Interval;
            Properties.Settings.Default.Height = Yset;
            Properties.Settings.Default.Width = Xset;
            Properties.Settings.Default.CellColor = cellColor;
            Properties.Settings.Default.GridColor = gridColor;
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
            // Used to save the cell patterns
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All Files|*.*|Cells|*.cells";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.DefaultExt = "cells";
            if (DialogResult.OK != saveFileDialog.ShowDialog())
                return;
            StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
            streamWriter.WriteLine(string.Format("!{0}", (object)DateTime.Now));
            for (int x = 0; x < this.universe.GetLength(1); ++x)
            {
                string str = string.Empty;
                for (int y = 0; y < this.universe.GetLength(0); ++y)
                    str = !this.universe[y, x] ? str + "O" : str + "@";
                streamWriter.WriteLine(str);
            }
            streamWriter.Close();
        }

        private void fileSave_Click(object sender, EventArgs e)
        {
            // Used to save the cell patterns
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All Files|*.*|Cells|*.cells";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.DefaultExt = "cells";
            if (DialogResult.OK != saveFileDialog.ShowDialog())
                return;
            StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
            streamWriter.WriteLine(string.Format("!{0}", (object)DateTime.Now));
            for (int x = 0; x < this.universe.GetLength(1); ++x)
            {
                string str = string.Empty;
                for (int y = 0; y < this.universe.GetLength(0); ++y)
                    str = !this.universe[y, x] ? str + "O" : str + "@";
                streamWriter.WriteLine(str);
            }
            streamWriter.Close();
        }

        #endregion

        #region Open File
        private void openButton_Click(object sender, EventArgs e)
        {
            // Used to open a .cell file and display the cell pattern that was saved
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
                for (int x = 0; x < str.Length; ++x)
                {
                    if (str[0] != '!')
                    {
                        length1 = str.Length;
                        length2 = x + 1;
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
                    for (int y = 0; y < str.Length; ++y)
                        this.universe[y, index1] = str[y] == '@';
                    ++index1;
                }
            }
            this.graphicsPanel1.Invalidate();
            streamReader.Close();
        }

        private void fileOpen_Click(object sender, EventArgs e)
        {
            // Used to open a .cell file and display the cell pattern that was saved
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
            for (int y = 0; y < this.universe.GetLength(1); y++)
            {
                for (int x = 0; x < this.universe.GetLength(0); x++)
                {
                    universe[y, x] = false;
                }
            }
            Properties.Settings.Default.Reset();
            graphicsPanel1.BackColor = Properties.Settings.Default.PanelColor;
            timer.Interval = Properties.Settings.Default.Timer;
            Yset = Properties.Settings.Default.Height;
            Xset = Properties.Settings.Default.Width;
            cellColor = Properties.Settings.Default.CellColor;
            gridColor = Properties.Settings.Default.GridColor;
            bool[,] reset = new bool[Width, Height];
            bool[,] reset2 = new bool[Width, Height];
            universe = reset;
            scratchPad = reset2;
            graphicsPanel1.Invalidate();
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
            // Generates the RandomSeed Dialog box and gets and sets values
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
            // Randomly generates a seed number on the random button
            Random randSeed = new Random(Seed);
            for (int x = 0; x < this.universe.GetLength(1); ++x)
            {
                for (int y = 0; y < this.universe.GetLength(0); ++y)
                {
                    if (randSeed.Next(2) > 0)
                        this.universe[y, x] = true;
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
            //Used to get user grid height, width, and time input
            GridTimeForm gridTime = new GridTimeForm();
            gridTime.Timer = timer.Interval;
            gridTime.Width = Xset;
            gridTime.Height = Yset;
            if (DialogResult.OK == gridTime.ShowDialog())
            {
                bool[,] temp = new bool[gridTime.Width, gridTime.Height];
                bool[,] temp2 = new bool[gridTime.Width, gridTime.Height];
                scratchPad = temp;
                universe = temp2;
                Xset = gridTime.Width;
                Yset = gridTime.Height;
                timer.Interval = gridTime.Timer;
                graphicsPanel1.Invalidate();
            }
        }
        #endregion

        #region Neighbor Counting
        private void neighborCountToggle_Click(object sender, EventArgs e)
        {
            // Toggle On/Off Neighbor Counts
            this.CounterVisible = !this.CounterVisible;
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region Print HUD
        public void PrintHUD(PaintEventArgs e)
        {
            // Sets up the HUD Display with formatting and strings
            Font hud = new Font("Arial", 12.5f);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            Rectangle layoutRectangle = new Rectangle(0, 320, 300, 200);
            string hudDisplay = string.Format("Generations: {0}\nCell Count: {1}\nBoundary Type: {2}\nUniverse Size: {3}/{4}", (object)this.generations, this.LivingCells, (object)this.UniverseType(), (object)Xset, (object)Yset);
            e.Graphics.DrawString(hudDisplay.ToString(), hud, Brushes.Orange, (RectangleF)layoutRectangle, format);
        }
        #endregion

        #region Universe Type
        // Tells the HUD which universe to display
        public string UniverseType() => !this.PackType ? "Toroidal" : "Finite";
        #endregion

        #region HUD Toggle
        private void hUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggles On/Off HUD on Grid
            this.HudToggle = !this.HudToggle;
            this.graphicsPanel1.Invalidate();
        }
        #endregion

        #region Finite Toggle
        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Toggles On/ Off Finite Universe
            border = true;
            PackType = true;
            finiteToolStripMenuItem.Checked = true;
            toroidalToolStripMenuItem.Checked = false;
            graphicsPanel1.Invalidate();
        }
        #endregion

        #region Toroidal Toggle
        private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Toggles On/ Off Toroidal Universe
            border = false;
            PackType = false;
            finiteToolStripMenuItem.Checked = false;
            toroidalToolStripMenuItem.Checked = true;
            graphicsPanel1.Invalidate();
        }
        #endregion

        #region Grid Toggle
        private void gridToggle_Click(object sender, EventArgs e)
        {
            // Toggles On/Off Grid
            this.GridOn = !this.GridOn;
            this.graphicsPanel1.Invalidate();
        }

        #endregion

    }
}