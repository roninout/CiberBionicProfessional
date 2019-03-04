using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace L03_Task04
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // вычитываем значение цвета для Label с изолированного зранилища
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Создание изолированного хранилища уровня  .Net сборки.
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            // Открытие файлового потока с указанием: Директории и Имени файла, FileMode, объекта хранилища.
            using (IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(@"UserSettings.set", FileMode.OpenOrCreate, userStorage))
            {

                // Прочитать данные из потока.
                using (StreamReader userReader = new StreamReader(userStream))
                {
                    string colorLabel = userReader.ReadToEnd();

                    BrushConverter brushConverter = new BrushConverter();
                    if (!string.IsNullOrEmpty(colorLabel))
                        Label1.Background = (Brush)brushConverter.ConvertFromString(colorLabel);
                }
            }
        }

        // событие выбора цвета из комбоббокса
        private void ClrPcker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            // меняем надпись на выбранный цвет
            Label1.Content = ClrPcker.SelectedColorText;

            // меняем Background на выбранный цвет
            BrushConverter brushConverter = new BrushConverter();
            Label1.Background = (Brush)brushConverter.ConvertFromString(ClrPcker.SelectedColor.ToString());
        }

        // сохранеем цвет в хранилище
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            // Создание изолированного хранилища уровня  .Net сборки.
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            // Открытие файлового потока с указанием: Директории и Имени файла, FileMode, объекта хранилища.
            using (IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(@"UserSettings.set", FileMode.OpenOrCreate, userStorage))
            {

                //   Запись данных в поток
                using (StreamWriter userWriter = new StreamWriter(userStream))
                {
                    userWriter.WriteLine(ClrPcker.SelectedColor);
                    Label1.Content = string.Format("Сохранение прошло успешно!");
                }
            }
        }
    }
}
