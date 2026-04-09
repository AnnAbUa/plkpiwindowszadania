using static System.Windows.Forms.LinkLabel;
using System.IO;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public int[] nums = new int[8];
        public string txt = "";

        List<int> good = new List<int>();
        List<int> ok = new List<int>();
        List<int> ehh = new List<int>();
        List<int> eww = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                good.Clear();
                ok.Clear();
                ehh.Clear();
                eww.Clear();

                nums[0] = Convert.ToInt32(textBox1.Text);
                nums[1] = Convert.ToInt32(textBox2.Text);
                nums[2] = Convert.ToInt32(textBox3.Text);
                nums[3] = Convert.ToInt32(textBox4.Text);
                nums[4] = Convert.ToInt32(textBox5.Text);
                nums[5] = Convert.ToInt32(textBox6.Text);
                nums[6] = Convert.ToInt32(textBox7.Text);
                nums[7] = Convert.ToInt32(textBox8.Text);
                foreach(int num in nums)
                {
                    if (num < 0 || num > 12)
                    {
                        MessageBox.Show("Please enter integers between 0 and 12!");
                        return;
                    }
                }

                float sum = 0;
                foreach(int num in nums)
                {
                    sum += num;
                }
                float average = sum / nums.Length;

                int minimal = nums.Min();
                int maximal = nums.Max();

                foreach (int num in nums)
                {
                    if (num >= 10)
                    {
                        good.Add(num);
                    }
                    else if (num >= 7)
                    {
                        ok.Add(num);
                    }
                    else if (num >= 4)
                    {
                        ehh.Add(num);
                    }
                    else
                    {
                        eww.Add(num);
                    }
                }

                txt = string.Join(", ", nums);
                txt += $"\nAverage: {average}";
                txt += $"\nMaximum: {maximal}";
                txt += $"\nMinimum: {minimal} \n";
                txt += $"\nPerfect grades: {good.Count}";
                txt += $"\nOK grades: {ok.Count}";
                txt += $"\nNot good grades: {ehh.Count}";
                txt += $"\nBad grades: {eww.Count}";

                if (eww.Count > 0 || ehh.Count > 0)
                {
                    txt += "\nYou have some bad grades";
                }
                else
                {
                    txt += "\nYou have 0 bad grades";
                }


                using (StreamWriter writer = new StreamWriter("FinalFeedback.txt", false))
                {
                    writer.WriteLine(txt);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid integers in all text boxes!");
                return;
            }
            label11.Text = txt;
        }
    }
}
