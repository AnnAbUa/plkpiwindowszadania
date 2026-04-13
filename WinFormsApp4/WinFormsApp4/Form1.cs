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
            if (name != "")
                label1.Text = "Hello, " + name + "!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out int num1);
            int.TryParse(textBox3.Text, out int num2);
            label2.Text = (num1 + num2).ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label4.Enabled = true;
            }
            else
            {
                label4.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label5.Left += 10;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label5.Left -= 10;
        }
    }
}
