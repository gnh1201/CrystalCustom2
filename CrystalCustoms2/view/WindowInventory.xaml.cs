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

using LiteDB;
using CrystalCustoms2.model;
using System.Data;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// WindowInventory.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WindowInventory : Window
    {
        private NewEstimateControl NewEstimateControlInstance = null;

        public WindowInventory(object parentForm)
        {
            NewEstimateControlInstance = (NewEstimateControl)parentForm;

            InitializeComponent();
            InitializeControls(); // 컨트롤 초기화
        }

        private void InitializeControls()
        {
            using (var db = new LiteDatabase(@"Inventories.db"))
            {
                // 재고정보 등록
                var col = db.GetCollection<Inventories>("Inventories");
                var results = col.FindAll();

                // 수입면장 기본정보
                DataTable dataTable = new DataTable();

                // 컬럼 생성
                string[] dataColumnBindNames = {
                    "Id", "Name", "Mblno", "Hblno", "Qty", "Unitprice", "Standard"
                };
                foreach (string item2 in dataColumnBindNames)
                {
                    dataTable.Columns.Add(item2, typeof(string));
                }

                foreach (Inventories item2 in results)
                {
                    dataTable.Rows.Add(
                        item2.Id,
                        item2.Name,
                        item2.Mblno,
                        item2.Hblno,
                        item2.Qty,
                        item2.Unitprice,
                        item2.Standard
                    );
                }

                invDataGrid.ItemsSource = dataTable.DefaultView;
                invDataGrid.Items.Refresh();
            }
        }

        // 상품 선택시
        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            // 상품추가
            DataRowView row = (DataRowView)invDataGrid.SelectedItems[0];
            string[] passObj = {
                row[0].ToString(), row[1].ToString(), row[5].ToString(), row[4].ToString(), ""
            };

            MessageBox.Show(String.Join(" ", passObj));

            NewEstimateControlInstance.AddOptionItem(passObj);

            // 추가 후 닫기
            this.Close();
        }
    }
}
