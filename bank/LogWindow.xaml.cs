using System.Data;
using System.Linq;
using System.Windows;

namespace bank
{
    /// <summary>
    /// Логика взаимодействия для LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        BankWindow Bank = new BankWindow();
        ConnectToDataBase connect = new ConnectToDataBase();
        User user { get; set; }
        public LogWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable table = new DataTable();
            table = connect.GetTable();
            try
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var stringArr = table.Rows[i].ItemArray.Select(x => x.ToString()).ToArray();

                    if (stringArr[1] == Name.Text && stringArr[2] == Password.Password)
                    {
                        int index = i;
                        user = new User(stringArr[1], stringArr[2], stringArr[3], stringArr[4]);
                        MessageBox.Show("Вы успешно вошли!");
                        Bank.label.Content = "Вы вошли как " + user._name + " на вашем счету " + user._money_count;
                        Bank.Show();
                        Close();
                        break;
                    }
                }
            }
            catch { MessageBox.Show("Неправильный логин или пароль"); }
        }
    }
}