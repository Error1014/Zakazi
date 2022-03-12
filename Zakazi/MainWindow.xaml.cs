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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddZakaz(object sender, RoutedEventArgs e)
        {
            ListZakazov.Add(int.Parse(ReadNumZakaz1.Text));
            ShowZakaz();
            ReadNumZakaz1.Text = "";
        }

        private void DeletZakaz(object sender, RoutedEventArgs e)
        {
            if (ListZakazov.Count>0)
            {
                ListZakazov.RemoveAt(ListZakazov.Count - 1);
                ShowZakaz();
            }
            else
            {
                MessageBox.Show("У вас нет заказов");
            }
        }
        public void ShowZakaz()
        {
            textBockNoDone.Text = "";
            for (int i = 0; i < ListZakazov.Count; i++)
            {
                textBockNoDone.Text += ListZakazov[i].ToString()+" ";
            }

        }
    }
}
