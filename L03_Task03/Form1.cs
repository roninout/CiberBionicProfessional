using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L03_Task03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitComboBox();
        }

        // инициализация комбобокса названиями логических дисков
        public void InitComboBox()
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach (var item in driveInfo)
                comboBox1.Items.Add(item.Name);
            comboBox1.SelectedIndex = 0; // устанавливаем индекс в 0
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            listBox1.Items.Clear();
            string path = comboBox2.Text;

            try
            {
                string[] files = new DirectoryInfo($@"{path}").GetFiles(textBox1.Text+".*", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
                this.listBox1.Items.AddRange(files);
                label2.Text = $"Найдено файлов: {listBox1.Items.Count}";
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Отказано в доступе");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Директория не существует");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            if (!String.IsNullOrEmpty(comboBox1.Text))
            {
                var directorys = new DirectoryInfo(comboBox1.Text).GetDirectories().Select(f => f.FullName).ToArray();
                foreach (var item in directorys)
                    comboBox2.Items.Add(item);
                comboBox2.SelectedIndex = 0; // устанавливаем индекс в 0
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(listBox1.SelectedItem.ToString()))
            {
                using (StreamReader reader = File.OpenText(listBox1.SelectedItem.ToString()))
                {
                    textBox2.Text = reader.ReadToEnd();
                }
            }
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo(listBox1.SelectedItem.ToString());
            FileStream source = File.OpenRead(listBox1.SelectedItem.ToString());
            FileStream destination = File.Create(listBox1.SelectedItem.ToString() + ".dfl");

            using (DeflateStream compressor = new DeflateStream(destination, CompressionMode.Compress))
            {
                int theByte = source.ReadByte();
                while (theByte != -1)
                {
                    compressor.WriteByte((byte)theByte);
                    theByte = source.ReadByte();
                }
                label2.Text = "Архив был создан:" + info.Name + ".dfl";
            }

            source.Close();
            destination.Close();
        }
    }
}
