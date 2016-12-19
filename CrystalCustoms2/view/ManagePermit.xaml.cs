using LiteDB;
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
using System.Data;
using System.Reflection;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// ManagePermit.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ManagePermit : UserControl
    {
        private LayoutDocumentPane documentPane = null;
        private PermitControl PermitControlInstance = null;

        public ManagePermit(LayoutDocumentPane documentPaneInstance)
        {
            documentPane = documentPaneInstance;
            InitializeComponent();

            GetPermitLIst();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // 면장 조회
        private void GetPermitLIst()
        {
            // db에서 조회
            using (var db = new LiteDatabase(@"cargCsclPrgsInfoQryRtnVo.db"))
            {
                var items = db.GetCollection<cargCsclPrgsInfoQryRtnVo>("cargCsclPrgsInfoQryRtnVo");
                var results = items.FindAll();

                // 수입면장 기본정보
                DataTable dataTable = new DataTable();

                // 컬럼 생성
                string[] dataColumnBindNames = {
                        "csclPrgsStts", "vydf", "prnm", "ldprCd", "shipNat",
                        "blPt", "dsprNm", "etprDt", "prgsStCd", "msrm",
                        "wghtUt", "dsprCd", "cntrGcnt", "cargTp", "shcoFlcoSgn",
                        "pckGcnt", "etprCstm", "shipNm", "hblNo", "prcsDttm",
                        "spcnCargCd", "ttwg", "ldprNm", "mtTrgtCargYnNm", "cargMtNo",
                        "cntrNo", "mblNo", "blPtNm", "lodCntyCd", "prgsStts",
                        "shcoFlco", "pckUt", "shipNatNm", "agnc"
                };

                // bind permitDatagrid
                foreach (string item2 in dataColumnBindNames)
                {
                    DataGridTextColumn dgItem = new DataGridTextColumn();
                    dgItem.Header = item2;
                    dgItem.Binding = new Binding(item2);
                    permitDataGrid.Columns.Add(dgItem);
                }
                foreach (string item2 in dataColumnBindNames)
                {
                    dataTable.Columns.Add(item2, typeof(string));
                }

                foreach (cargCsclPrgsInfoQryRtnVo item in results)
                {
                    List<cargCsclPrgsInfoQryVo> infoBlock = item.cargCsclPrgsInfoQryVo;

                    // 행 추가
                    foreach (cargCsclPrgsInfoQryVo item2 in infoBlock)
                    {
                        dataTable.Rows.Add(
                            item2.csclPrgsStts,
                            item2.vydf,
                            item2.prnm,
                            item2.ldprCd,
                            item2.shipNat,
                            item2.blPt,
                            item2.dsprNm,
                            item2.etprDt,
                            item2.prgsStCd,
                            item2.msrm,
                            item2.wghtUt,
                            item2.dsprCd,
                            item2.cntrGcnt,
                            item2.cargTp,
                            item2.shcoFlcoSgn,
                            item2.pckGcnt,
                            item2.etprCstm,
                            item2.shipNm,
                            item2.hblNo,
                            item2.prcsDttm,
                            item2.spcnCargCd,
                            item2.ttwg,
                            item2.ldprNm,
                            item2.mtTrgtCargYnNm,
                            item2.cargMtNo,
                            item2.cntrNo,
                            item2.mblNo,
                            item2.blPtNm,
                            item2.lodCntyCd,
                            item2.prgsStts
                        );
                    }
                }

                permitDataGrid.ItemsSource = dataTable.DefaultView;
                permitDataGrid.Items.Refresh();
            }
        }


        /// <summary>
        ///  면장 추가
        /// </summary>
        private void ClickedBtnAdd(object sender, RoutedEventArgs e)
        {
            PermitControlInstance = new PermitControl(documentPane);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "PermitControl",
                Title = "수입면장입력",
                Content = PermitControlInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }
    }
}
