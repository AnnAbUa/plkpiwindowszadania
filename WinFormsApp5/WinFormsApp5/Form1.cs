namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private object label1;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            this.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (!string.IsNullOrEmpty(name))
            {
                MessageBox.Show($"Привіт, {name}!");
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть ім'я.");
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox2.Text);
            double b = Convert.ToDouble(textBox3.Text);
            double sum = a + b;
            label1.Text = "Результат: " + sum.ToString();
        }
    }
}
