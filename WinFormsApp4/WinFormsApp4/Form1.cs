namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Green)
            {
                this.BackColor = Color.Red;
            }
            else if (this.BackColor == Color.Red)
            {
                this.BackColor = Color.Yellow;
            }
            else
                this.BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if(name != "")
                label1.Text = "Hello, " + name +"!";
        }
    }
}
