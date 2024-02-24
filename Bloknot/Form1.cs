using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Bloknot
{

    public partial class Form1 : Form
    {
        private string openFile;
        public void PrintPage(object sender, PrintPageEventArgs e)// Для печати
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 0, 0);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "all (*.*) |*.*"; //Фильтр
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);// Берем путь к файлу и читаем его
                openFile = ofd.FileName;
            }
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(openFile, richTextBox1.Text);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Ошибка сохранения");
            }


        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog();
            printDocument.PrintPage += PrintPage;
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
            }

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "all (*.*) |*.*"; //Фильтр
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, richTextBox1.Text);
                openFile = sfd.FileName;
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void выделениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog.Color;
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void выбратьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
    }
}
