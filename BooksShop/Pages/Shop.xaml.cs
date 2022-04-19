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
        float costOrderDis = 0;
        List<books> books = BaseConnector.BaseConnect.books.ToList();
        List<bookToOrder> ordersBook = new List<bookToOrder>();
        orders order = new orders();
        Calctulate makeDiscount = new Calctulate();
        public Shop(bool isBascketEmpty)
        {
            InitializeComponent();
            listBooks.ItemsSource = books;
            if (BaseConnector.BaseConnect.orders.Count() != 0)
                order.IDorder = BaseConnector.BaseConnect.orders.Last().IDorder + 1;
            else
                order.IDorder = 1;
            if (isBascketEmpty)
                ordersBook.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageLoader.MainFrame.Navigate(new Bascket(ordersBook, order));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button butt = (Button)sender;
            countBookOrder++;
            textBoxCountBook.Text = "Колличество выбранных книг: " + countBookOrder.ToString();
            if (ordersBook.FindIndex(x => x.IDbook == Convert.ToInt32(butt.Uid)) != -1)
                ordersBook.First(x => x.IDbook == Convert.ToInt32(butt.Uid)).count++;
            else
            {
                books book = books.FirstOrDefault(x => x.IDbook == Convert.ToInt32(butt.Uid));
                ordersBook.Add(new bookToOrder() { IDbook = Convert.ToInt32(butt.Uid), IDorder = order.IDorder, count = 1, orders = order, books =  book});
            }
            costOrder += (float)books.First(x => x.IDbook == Convert.ToInt32(butt.Uid)).cost;            
            discount = makeDiscount.MakeDiscount(countBookOrder, costOrder);
            if (discount > 0)
            {
                textBoxCostWithoutSale.Text = costOrder.ToString();
                costOrderDis = costOrder + costOrder * discount;
                textBoxCost.Text = costOrderDis.ToString();
                textBoxSale.Text = (discount * 100).ToString();
            }
            else
                textBoxCost.Text = costOrder.ToString();
        }
    }
}
