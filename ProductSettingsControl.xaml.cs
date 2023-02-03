using System.Windows;
using System.Windows.Controls;

namespace ProductTutorial
{
    /// <summary>
    /// Interaction logic for ProductSettingsControl.xaml
    /// </summary>
    public partial class ProductSettingsControl : UserControl
    {
        public ProductSettingsControl()
        {
            InitializeComponent();
            DataContext = ProductTutorialSettings.CurrentSettings;
        }

        private void SaveSettings(object sender, RoutedEventArgs e)
        {
            ProductTutorialSettings.CurrentSettings.Save();
        }
    }
}
