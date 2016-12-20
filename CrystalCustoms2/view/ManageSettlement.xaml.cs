using System;
using System.Collections.Generic;
using System.Data;
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
using System.Collections;

using Xceed.Wpf.Toolkit;
using CrystalCustoms2.model;
using CrystalCustoms2.controller;
using CrystalCustoms2.model.KoreaCustomsModel;
using Xceed.Wpf.AvalonDock.Layout;
using LiteDB;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// ManageApikeys.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ManageSettlement : UserControl
    {
        public int currentRowId = 0;
        public int saveMode = 0;
        private DataTable dataTable = null;
        private LayoutDocumentPane documentPane;
        private cargCsclPrgsInfoQryRtnVo responseResult;
        private SettleControl SettleControlInstance = null;

        public ManageSettlement(LayoutDocumentPane documentPane)
        {
            this.documentPane = documentPane;
            InitializeComponent();

            GetSettleLIst();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControls();
        }

        private void InitializeControls()
        {
        }

        // 면장 조회
        private void GetSettleLIst()
        {
            // db에서 조회
            using (var db = new LiteDatabase(@"Inventories.db"))
            {
                var items = db.GetCollection<Settles>("Settles");
                var results = items.FindAll();

                // 수입면장 기본정보
                DataTable dataTable = new DataTable();

                // 컬럼 생성
                string[] dataColumnBindNames = {
                    "SettleName", "SettleShipno", "SettleLoadport", "SettleSize", "SettleArriveDate",
                    "SettleOwn", "SettleMblno", "SettleHblno", "SettleArriveport", "SettleWeight",
                    "SettleWeightUnit", "SettleVolume", "SettleVolumeUnit", "SettleDuty", "SettleVat",
                    "SettleCommision"
                };

                // bind permitDatagrid
                foreach (string item2 in dataColumnBindNames)
                {
                    DataGridTextColumn dgItem = new DataGridTextColumn();
                    dgItem.Header = item2;
                    dgItem.Binding = new Binding(item2);
                    settleDataGrid.Columns.Add(dgItem);
                }
                foreach (string item2 in dataColumnBindNames)
                {
                    dataTable.Columns.Add(item2, typeof(string));
                }

                foreach (Settles item2 in results)
                {
                    dataTable.Rows.Add(
                        item2.SettleName,
                        item2.SettleShipno,
                        item2.SettleLoadport,
                        item2.SettleSize,
                        item2.SettleArriveDate,
                        item2.SettleOwn,
                        item2.SettleMblno,
                        item2.SettleHblno,
                        item2.SettleArriveport,
                        item2.SettleWeight,
                        item2.SettleWeightUnit,
                        item2.SettleVolume,
                        item2.SettleVolumeUnit,
                        item2.SettleDuty,
                        item2.SettleVat,
                        item2.SettleCommision
                    );
                }

                settleDataGrid.ItemsSource = dataTable.DefaultView;
                settleDataGrid.Items.Refresh();
            }
        }


        // 정보 조회
        private void settleDataGrid_SelectionChanged(object sender, EventArgs e)
        {
        }

        // 새로운 운송 추가
        private void ClickedBtnAdd(object sender, EventArgs e)
        {
            SettleControlInstance = new SettleControl(documentPane);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "SettleControl",
                Title = "운송추가",
                Content = SettleControlInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        // 신규
        private void ClickedBtnSave(object sender, EventArgs e)
        {
        }

        // 정보 수정
        private void ClickedBtnEdit(object sender, EventArgs e)
        {
        }

        // 정보 삭제
        private void ClickedBtnDelete(object sender, EventArgs e)
        {
        }

        // 이전 조회
        private void ClickedBtnPrev(object sender, EventArgs e)
        {
        }

        // 다음 조회
        private void ClickedBtnNext(object sender, EventArgs e)
        {
        }
    }
}
