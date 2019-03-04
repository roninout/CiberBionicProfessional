using Microsoft.Win32;
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace L05_Task04
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitTextBox();
            InitControls();
        }

        Brush tBackColor;
        Brush tColor;
        int tSize = 10;
        FontFamily tFont;
        RegistryKey registryKey;
        bool bType;


        #region Init
        // вычитываем значение цвета для Label с изолированного зранилища
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //// Создание изолированного хранилища уровня  .Net сборки.
            //IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            //// Открытие файлового потока с указанием: Директории и Имени файла, FileMode, объекта хранилища.
            //using (IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(@"UserSettings.set", FileMode.OpenOrCreate, userStorage))
            //{

            //    // Прочитать данные из потока.
            //    using (StreamReader userReader = new StreamReader(userStream))
            //    {
            //        string colorLabel = userReader.ReadToEnd();

            //        BrushConverter brushConverter = new BrushConverter();
            //        //if (!string.IsNullOrEmpty(colorLabel))
            //        //Label1.Background = (Brush)brushConverter.ConvertFromString(colorLabel);
            //    }
            //}
        }

        // заполненение элементов данными
        private void InitControls()
        {
            string[] FontStandartSize = new string[] { "6", "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" };

            // наполняем комбобокс 1 со стилями
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
                comboStyleFonts1.Items.Add(fontFamily.Source);
            comboStyleFonts1.SelectedItem = tFont;

            // наполняем комбобокс 1 с стандартными размерами шрифтов
            foreach (var item in FontStandartSize)
                comboSyze1.Items.Add(item);
            comboSyze1.SelectedItem = tSize;

            // наполняем комбобокс 2 со стилями
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
                comboStyleFonts2.Items.Add(fontFamily.Source);
            comboStyleFonts2.SelectedItem = tFont;

            // наполняем комбобокс 2 с стандартными размерами шрифтов
            foreach (var item in FontStandartSize)
                comboSyze2.Items.Add(item);
            comboSyze2.SelectedItem = tSize;

        }

        // Init TextBox
        private void InitTextBox()
        {
            ReadFromReg();
            textBlock1.FontFamily = tFont;
            textBlock1.FontSize = tSize;
            textBlock1.Background = tBackColor;
            textBlock1.Foreground = tColor;
        }

        #endregion

        #region Настройки для XML-элементов

        private void ClrPcker_Back1_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            // меняем надпись на выбранный цвет
            Label_Example1.Content = ClrPcker_Back1.SelectedColorText;

            // меняем Background на выбранный цвет
            BrushConverter brushConverter = new BrushConverter();
            Label_Example1.Background = (Brush)brushConverter.ConvertFromString(ClrPcker_Back1.SelectedColor.ToString());
        }

        private void ClrPcker_Text1_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            // меняем Foreground на выбранный цвет
            BrushConverter brushConverter = new BrushConverter();
            Label_Example1.Foreground = (Brush)brushConverter.ConvertFromString(ClrPcker_Text1.SelectedColor.ToString());
        }

        private void comboStyleFonts1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // меняем стиль текста
            Label_Example1.FontFamily = new FontFamily(comboStyleFonts1.SelectedItem.ToString());
        }

        private void comboSyze1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // меняем размера текста
            Label_Example1.FontSize = Int32.Parse(comboSyze1.SelectedItem.ToString());
        }

        // сохранить в XML
        private void Btn_SaveToXml_Click(object sender, RoutedEventArgs e)
        {
            // Создание изолированного хранилища уровня  .Net сборки.
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            // Открытие файлового потока с указанием: Директории и Имени файла, FileMode, объекта хранилища.
            using (IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(@"UserSettings.set", FileMode.OpenOrCreate, userStorage))
            {

                //   Запись данных в поток
                using (StreamWriter userWriter = new StreamWriter(userStream))
                {
                    //userWriter.WriteLine(ClrPcker.SelectedColor);
                    //Label_Example1.Content = string.Format("Сохранение прошло успешно!");
                }
            }
        }

        #endregion

        #region Настройки для REG-элементов
        private void ClrPcker_Back2_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            // меняем надпись на выбранный цвет
            Label_Example2.Content = ClrPcker_Back2.SelectedColorText;

            // меняем Background на выбранный цвет
            BrushConverter brushConverter = new BrushConverter();
            Label_Example2.Background = (Brush)brushConverter.ConvertFromString(ClrPcker_Back2.SelectedColor.ToString());
        }

        private void ClrPcker_Text2_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            // меняем Foreground на выбранный цвет
            BrushConverter brushConverter = new BrushConverter();
            Label_Example2.Foreground = (Brush)brushConverter.ConvertFromString(ClrPcker_Text2.SelectedColor.ToString());
        }

        private void comboStyleFonts2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // меняем стиль текста
            Label_Example2.FontFamily = new FontFamily(comboStyleFonts2.SelectedItem.ToString());
        }

        private void comboSyze2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // меняем размера текста
            Label_Example2.FontSize = Int32.Parse(comboSyze2.SelectedItem.ToString());
        }

        // сохранить в REG
        private void Btn_SaveToReg_Click(object sender, RoutedEventArgs e)
        {
            WriteToReg();
        }

        #endregion

        #region REG
        // считываем данные
        private void ReadFromReg()
        {
            var bc = new BrushConverter();

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("CBS_L05_Task04");

            try
            {
                tBackColor = (Brush)bc.ConvertFromString(registryKey.GetValue("BackColor").ToString());
                tColor = (Brush)bc.ConvertFromString(registryKey.GetValue("TextColor").ToString());
                tSize = Convert.ToInt32(registryKey.GetValue("Size"));
                tFont = new FontFamily(registryKey.GetValue("Font").ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("bla-bla");
            }
            finally
            {
                // Закрыть ключ нужно обязательно.
                registryKey.Close();
            }
        }

        // записываем данные
        private void WriteToReg()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software", true);

            try
            {
                // Попытка создать/открыть новый ключ.
                RegistryKey newKey = registryKey.CreateSubKey("CBS_L05_Task04");
                newKey.SetValue("BackColor", ClrPcker_Back2.SelectedColorText.ToString());
                newKey.SetValue("TextColor", ClrPcker_Text2.SelectedColor.ToString());
                newKey.SetValue("Size", comboSyze2.SelectedItem.ToString());
                newKey.SetValue("Font", comboStyleFonts2.SelectedItem.ToString());
            }
            catch (Exception e)
            {
                // Если возникает проблема - выводим сообщение о ней на экран.
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Закрыть ключ нужно обязательно.
                registryKey.Close();
            }
        }


        #endregion


    }
}
