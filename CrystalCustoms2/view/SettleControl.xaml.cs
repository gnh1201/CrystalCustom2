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

using CrystalCustoms2.model.KoreaCustomsModel;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// SettleControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettleControl : UserControl
    {
        private Dictionary<string, string> settleDict = new Dictionary<string, string>();

        public SettleControl()
        {
            InitializeComponent();
        }

        public SettleControl(LayoutDocumentPane documentPaneInstance, cargCsclPrgsInfoQryRtnVo responseResultInstance = null)
        {
            InitializeComponent();
        }

        private void ClickedBtnOk(object sender, RoutedEventArgs e)
        {

        }

        private void InitializeDIctionary()
        {

        }
    }
}
