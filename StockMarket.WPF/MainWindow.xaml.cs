using StockMarket.WPF.Controls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StockMarket.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;

            
        }


        private void drag_action(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        public MainWindow GetMainWindow() 
        {
            return this;
        }

        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            //handler your zoomIn/Out here
        }
    


    }
}