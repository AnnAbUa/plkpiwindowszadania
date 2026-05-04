using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Tarnavskiy01052026
{
    public partial class Form1 : Form
    {
        // Список для шляхів до картинок
        private List<string> memePaths = new List<string>();
        // Поточний номер картинки
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();

            // Налаштовуємо PictureBox, щоб картинка вписувалася в межі
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            LoadMemes();
            UpdateDisplay();
        }

        private void LoadMemes()
        {
            // Шлях до папки з мемами (створіть папку 'memes' у папці bin/Debug)
            string folderPath = Path.Combine(Application.StartupPath, "memes");

            if (Directory.Exists(folderPath))
            {
                // Отримуємо всі файли популярних графічних форматів
                string[] files = Directory.GetFiles(folderPath, "*.*");
                foreach (string file in files)
                {
                    string ext = Path.GetExtension(file).ToLower();
                    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".gif")
                    {
                        memePaths.Add(file);
                    }
                }
            }

            if (memePaths.Count == 0)
            {
                MessageBox.Show("Будь ласка, додайте картинки у папку: " + folderPath);
            }
        }

        private void UpdateDisplay()
        {
            if (memePaths.Count > 0)
            {
                pictureBox1.ImageLocation = memePaths[currentIndex];
                this.Text = $"Мем {currentIndex + 1} з {memePaths.Count}";
            }
        }

        // Кнопка "Назад"
        private void button1_Click(object sender, EventArgs e)
        {
            if (memePaths.Count == 0) return;

            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = memePaths.Count - 1; // Перехід до останнього
            }
            UpdateDisplay();
        }

        // Кнопка "Вперед"
        private void button2_Click(object sender, EventArgs e)
        {
            if (memePaths.Count == 0) return;

            currentIndex++;
            if (currentIndex >= memePaths.Count)
            {
                currentIndex = 0; // Повернення до першого
            }
            UpdateDisplay();
        }
    }
}