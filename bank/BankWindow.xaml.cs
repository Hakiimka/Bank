using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace bank
{
    /// <summary>
    /// Логика взаимодействия для BankWindow.xaml
    /// </summary>
    public partial class BankWindow : Window
    {
        ConnectToDataBase connect = new ConnectToDataBase();
        private List<User> names = new List<User>();
        private List<string> stringNames = new List<string>();
        public BankWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MoneyPars pars = new MoneyPars(new ParsGetHTML("https://novosibirsk.1000bankov.ru/kurs/"));
            List<string> Money = pars.GetMoneyInfo();
            MoneyListBox.ItemsSource = Money;
            MessageBox.Show(MoneyListBox.SelectedIndex.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            User_list.ItemsSource = StringLoadList();
        }

        private List<string> StringLoadList()
        {
            DataTable table = new DataTable();
            table = connect.GetTable();
            List<string> names = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var stringArr = table.Rows[i].ItemArray.Select(x => x.ToString()).ToArray();
                names.Add(stringArr[1]);
            }
            return names;
        }
        private List<User> LoadList()
        {
            DataTable table = new DataTable();
            table = connect.GetTable();
            List<User> names = new List<User>();
            User user;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var stringArr = table.Rows[i].ItemArray.Select(x => x.ToString()).ToArray();
                user = new User(stringArr[1], stringArr[2], stringArr[3], stringArr[4]);
                names.Add(user);
            }
            return names;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connect.CloseConnection();
        }


    }
}
