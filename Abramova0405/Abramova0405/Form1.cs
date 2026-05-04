namespace Abramova0405
{
    public partial class Form1 : Form
    {
        List<string[]> expenses = new List<string[]>();
        string file = "expenses.txt";

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("col1", "Дата");
            dataGridView1.Columns.Add("col2", "Категорія");
            dataGridView1.Columns.Add("col3", "Опис");
            dataGridView1.Columns.Add("col4", "Сума (грн)");

            UploadData();
            UploadTable();
        }

        void UploadData()
        {
            if (!File.Exists(file)) return;
            foreach (string line in File.ReadAllLines(file))
            {
                string[] c = line.Split(';');
                if (c.Length == 4) expenses.Add(c);
            }
        }

        void DownloadData()
        {
            List<string> lines = new List<string>();
            foreach (string[] z in expenses)
                lines.Add(string.Join(";", z));
            File.WriteAllLines(file, lines);
        }

        void UploadTable()
        {
            dataGridView1.Rows.Clear();
            decimal total = 0, max = 0;

            foreach (string[] e in expenses)
            {
                dataGridView1.Rows.Add(e[0], e[1], e[2], e[3]);
                decimal с = decimal.Parse(e[3]);
                total += с;
                if (с > max) max = с;
            }

            label1.Text = "Загальна: " + total + " грн";
            label2.Text = "Найбільша: " + max + " грн";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Заповніть категорію і суму!");
                return;
            }

            decimal sum;
            if (!decimal.TryParse(textBox3.Text, out sum))
            {
                MessageBox.Show("Сума — тільки число!");
                return;
            }

            string data = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            expenses.Add(new string[] { data, textBox1.Text, textBox2.Text, sum.ToString() });

            DownloadData();
            UploadTable();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
