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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MaterialsWindow : Window
    {
        public MaterialsWindow()
        {
            InitializeComponent();
            Loaded += MaterialsWindow_Loaded;
        }

        private async void MaterialsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var materials = await ConnectionDB.GetMaterials();
            DataContext = materials;
        }
    }


}