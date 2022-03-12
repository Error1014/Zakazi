using System;
using System.Collections.Generic;
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

namespace Zakazi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<int> ListZakazov = new List<int>();
        public List<int> ListDoneZakazov = new List<int>();
        public List<Button> myZakaz = new List<Button>();
        public int selectZakaz;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddZakaz(object sender, RoutedEventArgs e)
        {
            ListZakazov.Add(int.Parse(ReadNumZakaz1.Text));
            ShowZakaz();
            AddEditElement();
            ReadNumZakaz1.Text = "";
        }

        private void BtnDeletZakaz(object sender, RoutedEventArgs e)
        {
            DeletZakaz(ListZakazov.Count - 1);
        }
        public void DeletZakaz(int num)
        {
            DeletEditElement();
            if (ListZakazov.Count > 0)
            {
                ListZakazov.RemoveAt(num);
                
                ShowZakaz();
            }
            else
            {
                MessageBox.Show("У вас нет заказов");
            }
        }
        public void ShowZakaz()
        {
            textBlockNoDone.Text = "";
            for (int i = 0; i < ListZakazov.Count; i++)
            {
                textBlockNoDone.Text +=ListZakazov[i].ToString()+" ";
            }
        }
        public void AddEditElement()
        {
            myZakaz.Add(new Button());
            myZakaz[myZakaz.Count - 1].Content = /*"Завершить №" + */ReadNumZakaz1.Text;
            myZakaz[myZakaz.Count - 1].Width = 200;
            myZakaz[myZakaz.Count - 1].Height = 30;
            myZakaz[myZakaz.Count - 1].Click += CompleteZakaz;
            EditZakaz.Children.Add(myZakaz[myZakaz.Count - 1]);
        }
        public void DeletEditElement()
        {
            myZakaz.RemoveAt(myZakaz.Count - 1);
            EditZakaz.Children.RemoveAt(myZakaz.Count);
        }
        public void CompleteZakaz(object sender, RoutedEventArgs e)
        { 
            MessageBox.Show("Заказ Выполнен");
            
            var b = sender as Button;
            string s = b.Content.ToString();
            selectZakaz = int.Parse(s);
            DeletZakaz(myZakaz.Count - 1);
            textBlockDone.Text += selectZakaz + " ";

        }

    }
}
