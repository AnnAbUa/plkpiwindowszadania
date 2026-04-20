using System.Drawing;
using System.Windows.Forms;

namespace _2004Zad2Saper
{
    public partial class Form1 : Form
    {
        const int rows = 8;
        const int cols = 8;
        const int mineCount = 10;

        Button[,] buttons = new Button[rows, cols];
        bool[,] mines = new bool[rows, cols];
        bool[,] opened = new bool[rows, cols];

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            CreateField();
            PlaceMines();
        }

        private void CreateField()
        {
            int size = 40;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(size, size);
                    btn.Location = new Point(j * size, i * size);
                    btn.Tag = new Point(i, j);
                    btn.Click += Cell_Click;

                    buttons[i, j] = btn;
                    Controls.Add(btn);
                }
            }

            this.ClientSize = new Size(cols * size, rows * size);
        }

        private void PlaceMines()
        {
            int placed = 0;

            while (placed < mineCount)
            {
                int r = random.Next(rows);
                int c = random.Next(cols);

                if (!mines[r, c])
                {
                    mines[r, c] = true;
                    placed++;
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Point p = (Point)btn.Tag;

            int row = p.X;
            int col = p.Y;

            OpenCell(row, col);
        }

        private void OpenCell(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
                return;

            if (opened[row, col])
                return;

            opened[row, col] = true;
            buttons[row, col].Enabled = false;

            if (mines[row, col])
            {
                buttons[row, col].Text = "*";
                buttons[row, col].BackColor = Color.Red;
                ShowAllMines();
                MessageBox.Show("Ви програли!");
                DisableAllButtons();
                return;
            }

            int count = CountMinesAround(row, col);

            if (count > 0)
            {
                buttons[row, col].Text = count.ToString();
            }
            else
            {
                buttons[row, col].Text = "";

                OpenCell(row - 1, col);
                OpenCell(row + 1, col);
                OpenCell(row, col - 1);
                OpenCell(row, col + 1);
                OpenCell(row - 1, col - 1);
                OpenCell(row - 1, col + 1);
                OpenCell(row + 1, col - 1);
                OpenCell(row + 1, col + 1);
            }

            CheckWin();
        }

        private int CountMinesAround(int row, int col)
        {
            int count = 0;

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < rows && j >= 0 && j < cols)
                    {
                        if (mines[i, j])
                            count++;
                    }
                }
            }

            return count;
        }

        private void ShowAllMines()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (mines[i, j])
                    {
                        buttons[i, j].Text = "*";
                        buttons[i, j].BackColor = Color.LightPink;
                    }
                }
            }
        }

        private void DisableAllButtons()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[i, j].Enabled = false;
                }
            }
        }

        private void CheckWin()
        {
            int safeCells = rows * cols - mineCount;
            int openedSafeCells = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (opened[i, j] && !mines[i, j])
                        openedSafeCells++;
                }
            }

            if (openedSafeCells == safeCells)
            {
                MessageBox.Show("Ви перемогли!");
                DisableAllButtons();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
