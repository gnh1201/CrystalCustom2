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
        public SettleControl(LayoutDocumentPane documentPaneInstance, cargCsclPrgsInfoQryRtnVo responseResultInstance = null)
        {
            InitializeComponent();
        }
    }
}
