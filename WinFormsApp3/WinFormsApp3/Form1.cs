namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "";
                string inputFile = "data.txt";
                string outputFile = "result.txt";

                if (!File.Exists(inputFile))
                {
                    MessageBox.Show("File not found!");
                    return;
                }
                string text;
                using (StreamReader reader = new StreamReader(inputFile))
                {
                    text = reader.ReadToEnd();
                }

                string[] parts = text.Split(
                    new char[] { ' ', ',', ';', '\n', '\r', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                double[] numbers = new double[parts.Length];
                int count = 0;

                string wrong = "";

                foreach (string p in parts)
                {
                    double num;

                    if (double.TryParse(p, out num))
                    {
                        numbers[count] = num;
                        count++;
                    }
                    else
                    {
                        wrong += p + " ";
                    }
                }

                if (count == 0)
                {
                    string msg = "No correct numbers";

                    if (wrong != "")
                    {
                        msg += "\nWrong values: " + wrong;
                    }

                    label1.Text = msg;
                    using (StreamWriter writer = new StreamWriter(outputFile))
                    {
                        writer.WriteLine(msg);
                    }
                    return;
                }

                double sum = 0;
                double max = numbers[0];
                double min = numbers[0];
                int positive = 0;
                int negative = 0;
                int zero = 0;

                for (int i = 0; i < count; i++)
                {
                    double num = numbers[i];

                    sum += num;

                    if (num > max)
                    {
                        max = num;
                    }

                    if (num < min)
                    {
                        min = num;
                    }

                    if (num > 0)
                    {
                        positive++;
                    }
                    else
                    {
                        if (num < 0)
                        {
                            negative++;
                        }
                        else
                        {
                            zero++;
                        }
                    }
                }

                double avg = sum / count;

                string result =
                    "Numbers: ";

                for (int i = 0; i < count; i++)
                {
                    result += numbers[i] + " ";
                }

                result += "\nSum: " + sum;
                result += "\nAverage: " + avg;
                result += "\nMax: " + max;
                result += "\nMin: " + min;
                result += "\nPositive: " + positive;
                result += "\nNegative: " + negative;
                result += "\nZero: " + zero;
                result += "\nWrong values: ";

                if (wrong == "")
                {
                    result += "none";
                }
                else
                {
                    result += wrong;
                }

                label1.Text = result;
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
