using System;
using System.Windows.Forms;

namespace Tarnavskiy01052026
{
    public partial class Form1 : Form
    {
        // 1. Просто створюємо масив із назвами файлів (покладіть ці файли в папку bin/Debug)
        string[] memes = { "1.jpg", "2.jpg", "3.jpg" };

        // 2. Змінна для збереження номера поточної картинки
        int index = 0;

        public Form1()
        {
            //InitializeComponent();

            // Налаштовуємо картинку, щоб вона не обрізалася
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Показуємо першу картинку відразу при запуску
            //pictureBox1.ImageLocation = memes[index];
        }

        // Кнопка "Назад"
        private void button1_Click(object sender, EventArgs e)
        {
            index = index - 1; // Зменшуємо номер

            if (index < 0)
            {
                index = memes.Length - 1; // Якщо пішли в мінус — стрибаємо в кінець
            }

            //pictureBox1.ImageLocation = memes[index];
        }

        // Кнопка "Вперед"
        private void button2_Click(object sender, EventArgs e)
        {
            index = index + 1; // Збільшуємо номер

            if (index >= memes.Length)
            {
                index = 0; // Якщо картинки закінчилися — повертаємось до першої (0)
            }

            //pictureBox1.ImageLocation = memes[index];
        }
    }
}