namespace MyProjecy17._04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Привіт " + textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox2.Text);
            int b = int.Parse(textBox3.Text);
            int sum = a + b;
            label2.Text = "Сума: " + sum;


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                label3.Visible = true;
            else
                label3.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Top -= 10;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button4.Top += 10;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button4.Left -= 10;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button4.Left += 10;
        }
    }
}
