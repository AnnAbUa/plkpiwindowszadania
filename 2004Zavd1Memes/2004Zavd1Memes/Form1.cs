namespace _2004Zavd1Memes
{
    public partial class Form1 : Form
    {
        private string[] memes;
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();

            string path = Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory, "Memes"
);
            memes = Directory.GetFiles(path, "*.jpg");
            ShowMeme();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeme()
        {
            if (memes.Length == 0) 
            { 
                MessageBox.Show("No memes"); 
                return; 
            }
            if (!File.Exists(memes[currentIndex])) 
            { 
                MessageBox.Show("Файл не знайдено: " + memes[currentIndex]); 
                return; 
            }

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            try
            {
                byte[] imageBytes = File.ReadAllBytes(memes[currentIndex]);
                var ms = new MemoryStream(imageBytes);
                pictureBox1.Image = Image.FromStream(ms, false, true);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження: " + ex.Message + "\nФайл: " + memes[currentIndex]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentIndex++;

            if (currentIndex >= memes.Length)
                currentIndex = 0;

            ShowMeme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentIndex--;

            if (currentIndex < 0)
                currentIndex = memes.Length - 1;

            ShowMeme();
        }
    }
}
