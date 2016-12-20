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

using Xceed.Wpf.AvalonDock.Layout;
using LiteDB;
using CrystalCustoms2.model;
using CrystalCustoms2.common;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// ManageEstimate.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ManageEstimate : UserControl
    {
        public int currentRowId = 0;
        public int saveMode = 0;
        private DataTable dataTable = null;
        private LayoutDocumentPane documentPane;
        private NewEstimateControl NewEstimateControlInstance = null;

        public ManageEstimate(LayoutDocumentPane documentPane)
        {
            this.documentPane = documentPane;
            InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControls();
        }

        // 초기화
        private void InitializeControls()
        {

            using (var db = new LiteDatabase(@"Estimates.db"))
            {
                var col = db.GetCollection<Estimates>("Estimates");
                var results = col.FindAll();

                dataTable = new DataTable();

                // 컬럼 생성
                string[] dataColumnBindNames = {
                    "Id", "ReptName", "ReptTel", "ReptFax", "ReptOwn", "ReptAddress", "ReptDate",
                    "ReptNo", "SendName", "SendAddress", "SendTel", "SendFax",
                    "SendDeadline", "SendOwn", "ShipDate","ShipType", "DeliveryPoint", "PayCond",
                    "TaxRate"
                };
                // bind estDataGrid
                foreach (string item2 in dataColumnBindNames)
                {
                    DataGridTextColumn dgItem = new DataGridTextColumn();
                    dgItem.Header = item2;
                    dgItem.Binding = new Binding(item2);
                    estDataGrid.Columns.Add(dgItem);
                }
                foreach (string item2 in dataColumnBindNames)
                {
                    dataTable.Columns.Add(item2, typeof(string));
                }

                foreach (Estimates item2 in results)
                {
                    dataTable.Rows.Add(
                        item2.Id,
                        item2.ReptName,
                        item2.ReptTel,
                        item2.ReptFax,
                        item2.ReptOwn,
                        item2.ReptAddress,
                        item2.ReptDate,
                        item2.ReptNo,
                        item2.SendName,
                        item2.SendAddress,
                        item2.SendTel,
                        item2.SendFax,
                        item2.SendDeadline,
                        item2.SendOwn,
                        item2.ShipDate,
                        item2.ShipType,
                        item2.DeliveryPoint,
                        item2.PayCond,
                        item2.TaxRate
                    );
                }

                estDataGrid.ItemsSource = dataTable.DefaultView;
                estDataGrid.Items.Refresh();
            }
        }

        // 정보 조회
        private void settleDataGrid_SelectionChanged(object sender, EventArgs e)
        {
        }

        // 신규 견적추가
        private void ClickedBtnAdd(object sender, EventArgs e)
        {
            NewEstimateControlInstance = new NewEstimateControl(documentPane);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "NewEstimateControl",
                Title = "새로운 견적 추가",
                Content = NewEstimateControlInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        // 정보 수정
        private void ClickedBtnEdit(object sender, EventArgs e)
        {

        }

        // 정보 삭제
        private void ClickedBtnDelete(object sender, EventArgs e)
        {
        }

        // 판매완료시
        private void ClickedBtnComplete(object sender, EventArgs e)
        {

        }

        // pdf 내보내기
        private void ClickedBtnExport(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            DataRowView row = (DataRowView)estDataGrid.SelectedItems[0];

            dt2.Columns.Add("번호", typeof(Int32));
            dt2.Columns.Add("항목이름", typeof(string));
            dt2.Columns.Add("항목값", typeof(string));

            int i = 0;
            foreach (DataColumn column in dataTable.Columns)
            {
                dt2.Rows.Add(i+1, column.ColumnName, row[i]);

                i++;
            }

            // pdf 파일 저장
            string pdfname = ReportWriter.write(dt2);
            Xceed.Wpf.Toolkit.MessageBox.Show(pdfname + "파일로 저장되었습니다.");
        }
    }
}
