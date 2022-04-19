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
using BooksShop.Classes;

namespace BooksShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Bascket.xaml
    /// </summary>
    public partial class Bascket : Page
    {
        List<bookToOrder> bookToOrders;
        orders order;
        bool isBascketEmpty = false;
        public Bascket(List<bookToOrder> bookToOrders, orders order)
        {
            InitializeComponent();
            this.bookToOrders = bookToOrders;
            this.order = order;
            listOrders.ItemsSource = bookToOrders;
        }

        private void buttonMakeOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {            
            PageLoader.MainFrame.Navigate(new Shop(isBascketEmpty));            
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            bookToOrders.Clear();
            isBascketEmpty = true;
            listOrders.Items.Refresh();
        }
    }
}
