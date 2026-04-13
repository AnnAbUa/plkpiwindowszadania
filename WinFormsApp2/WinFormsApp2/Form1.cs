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
        public string text = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            eightStuff = false;
            bigLetter = false;
            smallLetter = false;
            number = false;
            specialStuff = false;

            string password = textBox1.Text;
            text = "";

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    bigLetter = true;
                }

                if (char.IsLower(c))
                {
                    smallLetter = true;
                }

                if (char.IsDigit(c))
                {
                    number = true;
                }

                if (specialChars.Contains(c))
                {
                    specialStuff = true;
                }
            }

            if (password.Length >= 8)
            {
                eightStuff = true;
            }

            if (!eightStuff)
            {
                text += "Not 8 symbols\n";
            }
            if (!bigLetter)
            {
                text += "No big letter\n";
            }
            if (!smallLetter)
            {
                text += "No small letter\n";
            }
            if (!number)
            {
                text += "No number \n";
            }
            if (!specialStuff)
            {
                text += "No special symbol\n";
            }

            int score = 0;
            if (eightStuff)
            {
                score++;
            }
            if (bigLetter)
            {
                score++;
            }
            if (smallLetter)
            {
                score++;
            }
            if (number)
            {
                score++;
            }
            if (specialStuff)
            {
                score++;
            }

            string level = "";

            if (score <= 2)
            {
                level = "Weak";
            }
            else if (score <= 4)
            {
                level = "Medium";
            }
            else
            {
                level = "Strong";
            }

            text += "\nLevel: " + level;

            label1.Text = text;
            try
            {
                if (score == 5)
                {
                    using (StreamWriter writer = new StreamWriter("result.txt"))
                    {
                        writer.WriteLine(password);
                    }
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to file: " + ex.Message);
            }
        }
    }
}

