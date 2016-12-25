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
using System.Windows.Shapes;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// SettleDetailWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettleDetailWindow : Window
    {
        public SettleDetailWindow()
        {
            InitializeComponent();
        }

        // 확인 시
        private void ClickedBtnOk(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
