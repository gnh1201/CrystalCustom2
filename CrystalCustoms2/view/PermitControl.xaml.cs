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

using CrystalCustoms2.controls;
using CrystalCustoms2.networking;
using CrystalCustoms2.view;
using CrystalCustoms2.model.KoreaCustomsModel;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// PermitControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PermitControl : UserControl
    {
        private PermitViewer PermitViewerInstance = null;
        private LayoutDocumentPane documentPane = null;

        public PermitControl(LayoutDocumentPane documentPaneInstance)
        {
            // 패널 컨트롤 선언
            documentPane = documentPaneInstance;

            // 객체 초기화
            InitializeComponent();
            IntalizeControls();
        }

        private void IntalizeControls()
        {
            int currentYear = DateTime.Now.Year;
            for (int i = 1950; i <= 2038; i++) {
                ComboBoxItem selItem = new ComboBoxItem();
                selItem.Tag = i.ToString();
                selItem.Content = i;
                if(currentYear == i)
                {
                    selItem.IsSelected = true;
                }

                selBlYy.Items.Add(selItem);
            }
        }

        private void clickedBtnOk(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> reqParams = new Dictionary<string, string>();

            // B/L 유형
            string selBlValue = ((ComboBoxItem)selBlNo.SelectedItem).Tag.ToString();
            string selBlYyValue = ((ComboBoxItem)selBlYy.SelectedItem).Tag.ToString();
            cargCsclPrgsInfoQryRtnVo permitInfo = new cargCsclPrgsInfoQryRtnVo();
            switch (selBlValue)
            {
                case "mblNo": // 마스터 B/L
                    reqParams.Add("mblNo", txtBlNo.Text);
                    reqParams.Add("blYy", selBlYyValue);
                    permitInfo = KoreaCustoms.retrieveCargCsclPrgsInfo("mblNo", reqParams);
                    break;
                case "hblNo": // 하우스 B/L
                    reqParams.Add("hblNo", txtBlNo.Text);
                    reqParams.Add("blYy", selBlYyValue);
                    permitInfo = KoreaCustoms.retrieveCargCsclPrgsInfo("hblNo", reqParams);
                    break;
                case "cargMtNo": // 화물번호
                    reqParams.Add("cargMtNo", txtCargMtNo.Text);
                    permitInfo = KoreaCustoms.retrieveCargCsclPrgsInfo("cargMtNo", reqParams);
                    break;
            }

            // 면장뷰어(PermitViewer) 불러오기
            PermitViewerInstance = new PermitViewer(documentPane, permitInfo);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "PermitViewer",
                Title = "수입면장확인",
                Content = PermitViewerInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }
    }
}
