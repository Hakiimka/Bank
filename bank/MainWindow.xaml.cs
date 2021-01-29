using System.Windows;

namespace bank
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
        // ConnectToDataBase connect = new ConnectToDataBase();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            log.Show();
        }
        RegWindow reg = new RegWindow();
        LogWindow log = new LogWindow();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            reg.Show();
        }
    }
}
