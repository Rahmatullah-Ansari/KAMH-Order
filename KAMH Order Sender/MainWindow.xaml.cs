using KAMH_Order_Sender.ViewModel;
using System.Windows;

namespace KAMH_Order_Sender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainGrid.DataContext = SingleOrderViewModel.GetInstance;
        }
    }
}
