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
using DLLdiscounts;

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
        int countBook =0;
        float cost =0;
        float discount = 0;
        Calctulate calctulate = new Calctulate();
        public Bascket(List<bookToOrder> bookToOrders, orders order)
        {
            InitializeComponent();
            this.bookToOrders = bookToOrders;
            this.order = order;
            listOrders.ItemsSource = bookToOrders;
            foreach (var books in bookToOrders)
            {
                countBook += (int)books.count;
                cost = (float)books.books.cost*countBook;
            }
            discount = calctulate.MakeDiscount(countBook, cost) * 100;
            cost =cost + cost*calctulate.MakeDiscount(countBook, cost);
            textCost.Text = "Итоговая цена: " + cost.ToString();
            
        }

        private void buttonMakeOrder_Click(object sender, RoutedEventArgs e)
        {
            bookToOrders.Clear();
            isBascketEmpty = true;
            listOrders.Items.Refresh();
            MessageBox.Show("Ваш заказ готовится к исполнению! Информация по заказу\nНомер заказа: " + order.IDorder + "\nКогда забрать: на кассе сегодня\nЦена со скидкой: " + cost + "\nСкидка: " + discount +"%");
            BaseConnector.BaseConnect.orders.Add(order);
            BaseConnector.BaseConnect.bookToOrder.AddRange(bookToOrders);
            BaseConnector.BaseConnect.SaveChanges();
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
