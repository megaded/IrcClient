using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using MultiChat.Model;
using MultiChat.ViewModel;
using System.Windows.Controls;

namespace MultiChat
{
    public partial class MainWindow : Window
    {
        public ClientViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ClientViewModel();
            DataContext = ViewModel;                       
        }
    }
}
