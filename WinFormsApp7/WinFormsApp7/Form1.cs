namespace WinFormsApp7
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
            int x = rnd.Next(0, this.ClientSize.Width - button1.Width);
            int y = rnd.Next(0, this.ClientSize.Height - button1.Height);
            button1.Location = new Point(x, y);
        }
    }
}
