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
using Xceed.Wpf.AvalonDock.Layout;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// NewEstimateControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewEstimateControl : UserControl
    {
        private LayoutDocumentPane documentPane;
        public NewEstimateControl(LayoutDocumentPane documentPaneInstance)
        {
            documentPane = documentPaneInstance;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClickedBtnAddItem(object sender, RoutedEventArgs e)
        {
            WindowInventory newForm = new WindowInventory(this);
            newForm.Show();
        }

        private void ClickedBtnRemoveItem(object sender, RoutedEventArgs e)
        {

        }
    }
}
