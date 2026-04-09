namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public bool eightStuff = false;
        public bool bigLetter = false;
        public bool smallLetter = false;
        public bool number = false;
        public bool specialStuff = false;
        char[] specialChars = { '@', '#', '$', '%', '^', '&' };
        public string text= "";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    bigLetter = true;
                    text += "\nBig letter: " + bigLetter;
                }
                if (char.IsLower(c))
                {
                    smallLetter = true;
                    text += "\nSmall letter: " + smallLetter;
                }
                if (specialChars.Contains(c))
                {
                    specialStuff = true; number = true;
                    text += "\nSpecial character: " + specialStuff;
                }
                if (char.IsDigit(c))
                {
                    number = true;
                    text += "\nNumber: " + number;
                }
            }
            if (password.Length >= 8)
            {
                eightStuff = true;
                text += "\n8 characters: " + eightStuff;
            }
            label1.Text = text;
        }
    }
}
