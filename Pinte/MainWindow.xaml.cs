using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pinte
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawingAttributes inkDA;

        private List<string> listMode = new List<string> { "Рисование", "Выделение", "Удаление" };
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            inkCnvs.DefaultDrawingAttributes.Color = Colors.Black;

            inkDA = new DrawingAttributes();
            inkDA.Color = Colors.SpringGreen;
            inkDA.Height = 5;
            inkDA.Width = 5;
            inkDA.FitToCurve = false;

            cmbMode.ItemsSource = listMode;
            
        }

        private void btnMenuHide_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void btnMenuClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }


        private void CreatorsMnItm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создателями данного произведения искусства стали: \nПетченко Алексей \nНаходнов Вячеслав", "Создатели");
        }

        private void DiscMnItm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данное приоженние предназначено для недолговременного использования, т.к. может что-то сломаться \nУдачи***", "Описание");

        }

        private void CloseMnItm_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MnItmColor_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            switch (menuItem.Header.ToString())
            {
                case "Чёрный":
                    inkCnvs.DefaultDrawingAttributes.Color = Colors.Black;
                    break;
                case "Красный":
                    inkCnvs.DefaultDrawingAttributes.Color = Colors.Red;
                    break;

                case "Синий":
                    inkCnvs.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;

                case "Зелёный":
                    inkCnvs.DefaultDrawingAttributes.Color = Colors.Green;
                    break;

                case "Жёлтый":
                    inkCnvs.DefaultDrawingAttributes.Color = Colors.Yellow;
                    break;

                case "Фиолетовый":
                    inkCnvs.DefaultDrawingAttributes.Color = Colors.Purple;
                    break;

                default:
                    break;
            }

        }

        private void sldSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (inkCnvs != null)
            {
                inkDA = inkCnvs.DefaultDrawingAttributes;
                Double newSize = Math.Round(sldSize.Value, 0);
                inkDA.Width = newSize;
                inkDA.Height = newSize;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            inkCnvs.Strokes.Clear();
        }

    }
}
