using System.Diagnostics.Metrics;

namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int maxwidth = this.ClientSize.Width - button1.Width;
            int maxheight = this.ClientSize.Height - button1.Height;
            button1.Location = new Point(rnd.Next(maxwidth), rnd.Next(maxheight));
        }

       

       

        private void button2_Click(object sender, EventArgs e)
        {
            bool turn = true;
            if (turn)
            {
                button2.Text = "X";
                turn = false;
            }
            else
            {
                button2.Text = "O";
                turn = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
