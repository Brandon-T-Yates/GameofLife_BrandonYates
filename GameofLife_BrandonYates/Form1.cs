﻿using System;
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
    public partial class Form1 : Form
    {
        #region Arrays
        // The universe array
        bool[,] universe = new bool[20, 20];
        bool[,] scratchPad = new bool[20, 20];
        bool scratched = true;
        #endregion

        #region Grid Colors
        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;
        #endregion

        #region Timer
        // The Timer class
        Timer timer = new Timer();
        #endregion

        #region ints
        // Generation count
        int generations = 0;
        int LivingCells = 0;
        #endregion

        #region Form
        public Form1()  
        {
            InitializeComponent();

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
            this.universe = scratchPad;
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
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }
        #endregion

        #region Something
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

        #region Counting Neighbors
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
                //if (universe[x, y])
                //{
                //    count--;
                //}
            }
            return count;
        }
        #endregion

        #region Counting LivingCells
        private void countLivingCells()
        {
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

        #region Finite & T
        private void Checker()
        {
            scratchPad = new bool[universe.GetLength(0), universe.GetLength(1)];

            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int i = 0; i < universe.GetLength(1); i++)
                {
                    if (scratched)
                    {

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

        #region Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Play
        private void playButton_Click(object sender, EventArgs e)
        {
            this.timer.Enabled = true;
        }
        #endregion

        #region Pause
        private void pauseButton_Click(object sender, EventArgs e)
        {
            this.countLivingCells();
            this.timer.Enabled = false;
        }
        #endregion
         
        #region Next
        private void nextButton_Click(object sender, EventArgs e)
        {
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
            this.universe = new bool[15, 15];
            this.generations = 0;
            this.toolStripStatusLabelGenerations.Text = "Generations = " + this.generations.ToString();
            this.graphicsPanel1.Invalidate();
        }

        private void fileNew_Click(object sender, EventArgs e)
        {
            this.universe = new bool[15, 15];
            this.generations = 0;
            this.toolStripStatusLabelGenerations.Text = "Generations = " + this.generations.ToString();
            this.graphicsPanel1.Invalidate();
        }


        #endregion

        #region Living Cell Count
        private void cellsAlive_Click(object sender, EventArgs e)
        {
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
            ColorDialog dlg = new ColorDialog();
            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
        }
        #endregion

        #region Cell Color
        private void cellColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
            this.graphicsPanel1.Invalidate();
        }
        #endregion
    }
}
