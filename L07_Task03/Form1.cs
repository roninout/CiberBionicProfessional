using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;


namespace L07_Task03
{
    public partial class Form1 : Form
    {
        Assembly assembly = null;
        public Form1()
        {
            InitializeComponent();
            initializeCheckList();

        }

        private void initializeCheckList()
        {
            Array elems = Enum.GetValues(typeof(MemberTypes));

            for(int i = 0; i < elems.Length - 1; i++)
            {
                checkedListBox.Items.Add(elems.GetValue(i).ToString());
            }
        }


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Строка приема полного имени загружаемой сборки.
                string path = openFileDialog.FileName;

                try
                {
                    assembly = Assembly.LoadFile(path);

                    textBox.Text += "СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Вывод информации о всех типах в сборке.
                textBox.Text += "СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                Type[] types = assembly.GetTypes(); //Получаем список всех типов
                //string[] items = checkedListBox.Items.OfType<string>().ToArray(); //Получаем массив строковых представлений ообъектов в checkList

                foreach (Type type in types)
                {
                    string str = "";

                    textBox.Text += $"Тип:  {type, -20}" + Environment.NewLine;

                    //Выводим инфо о атрибутах типов
                    if (checkBoxType.Checked)
                    {
                        object[] attributes = type.GetCustomAttributes(false);
                        foreach (Attribute attr in attributes)
                            textBox.Text += $"   Атрибуты типа: {attr}" + Environment.NewLine;
                    }
                    

                    MemberInfo[] members = type.GetMembers(); //Получаем список всех членов типа                           

                    if (members != null)
                    {
                        for (int i = 0; i < members.Length; i++)
                        {
                            //for (int j = 0; j < items.Length; j++)
                            for (int j = 0; j < checkedListBox.Items.Count; j++)
                            {
                                
                                if (members[i].MemberType.ToString() == checkedListBox.Items[j].ToString() && checkedListBox.GetItemChecked(j))
                                {
                                    str += $"{members[i].MemberType, -15}{members[i].Name}" + Environment.NewLine;
                                    if (checkBoxMembers.Checked)
                                    {
                                        object[] attributes = members[i].GetCustomAttributes(false);
                                        foreach(Attribute attr in attributes)
                                            str += $"   Атрибуты члена: {attr}" + Environment.NewLine;
                                    }                                       

                                    break;
                                }
                            }
                               
                        }
                    }

                    textBox.Text += str + Environment.NewLine;
                } 

            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
       
    }
}
