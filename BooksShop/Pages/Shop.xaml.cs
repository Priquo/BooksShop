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
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        int countBookOrder = 0;
        float discount = 0;
        float costOrder = 0;
        List<books> books = BaseConnector.BaseConnect.books.ToList();
        List<bookToOrder> ordersBook = new List<bookToOrder>();
        orders order = new orders();
        Calctulate makeDiscount = new Calctulate();
        public Shop()
        {
            InitializeComponent();
            listBooks.ItemsSource = books;
            if (BaseConnector.BaseConnect.orders.Count() != 0)
                order.IDorder = BaseConnector.BaseConnect.orders.Last().IDorder + 1;
            else
                order.IDorder = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button butt = (Button)sender;
            countBookOrder++;
            textBoxCountBook.Text = "Колличество выбранных книг: " + countBookOrder.ToString();            
            if (ordersBook.FindIndex(x => x.IDbook == Convert.ToInt32(butt.Uid)) != -1)
                ordersBook.First(x => x.IDbook == Convert.ToInt32(butt.Uid)).count++;
            ordersBook.Add(new bookToOrder() { IDbook = Convert.ToInt32(butt.Uid), IDorder = order.IDorder, count = 1 });
            costOrder += (float)books.First(x => x.IDbook == Convert.ToInt32(butt.Uid)).cost;
            discount = makeDiscount.MakeDiscount(countBookOrder, costOrder);
        }
    }
}
