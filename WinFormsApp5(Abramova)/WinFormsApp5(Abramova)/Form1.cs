namespace WinFormsApp5_Abramova_
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        string currentPlayer = "X";

        public Form1()
        {
            InitializeComponent();
            button2.MouseEnter += button2_MouseEnter;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            int maxX = this.ClientSize.Width - button2.Width;
            int maxY = this.ClientSize.Height - button2.Height;

            int newX = rnd.Next(0, maxX + 1);
            int newY = rnd.Next(0, maxY + 1);

            button2.Location = new Point(newX, newY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MakeMove(Button btn)
        {
            if (btn.Text != "")
            {
                return;
            }

            btn.Text = currentPlayer;

            if (CheckWin())
            {
                MessageBox.Show(currentPlayer + " wins!");
                ResetGame();
                return;
            }

            if (currentPlayer == "X")
            {
                currentPlayer = "O";
            }
            else
            {
                currentPlayer = "X";
            }
        }

        private bool CheckWin()
        {
            if (button3.Text == button4.Text && button4.Text == button5.Text && button3.Text != "")
            {
                return true;
            }
            if (button6.Text == button7.Text && button7.Text == button8.Text && button6.Text != "")
            {
                return true;
            }
            if (button9.Text == button10.Text && button10.Text == button11.Text && button9.Text != "")
            {
                return true;
            }

            if (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "")
            {
                return true;
            }
            if (button4.Text == button7.Text && button7.Text == button10.Text && button4.Text != "")
            {
                return true;
            }
            if (button5.Text == button8.Text && button8.Text == button11.Text && button5.Text != "")
            {
                return true;
            }

            if (button3.Text == button7.Text && button7.Text == button11.Text && button3.Text != "")
            {
                return true;
            }
            if (button5.Text == button7.Text && button7.Text == button9.Text && button5.Text != "")
            {
                return true;
            }

            return false;
        }

        private void ResetGame()
        {
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";

            button6.Text = "";
            button7.Text = "";
            button8.Text = "";

            button9.Text = "";
            button10.Text = "";
            button11.Text = "";

            currentPlayer = "X";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MakeMove(button3);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MakeMove(button4);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MakeMove(button5);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MakeMove(button6);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            MakeMove(button7);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            MakeMove(button8);
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            MakeMove(button9);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            MakeMove(button10);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            MakeMove(button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RESET");
            ResetGame();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            using (StreamReader sr = new StreamReader("data.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    textBox1.Text += line;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("data.txt", false))
            {
                sw.WriteLine(textBox1.Text);
            }
            MessageBox.Show("Saved");
        }
    }
}
