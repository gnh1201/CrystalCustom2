using CrystalCustoms2.model;
using LiteDB;
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

namespace CrystalCustoms2.view
{
    /// <summary>
    /// ManageInventory.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ManageInventory : UserControl
    {
        public ManageInventory(LayoutDocumentPane documentPaneInstance)
        {
            InitializeComponent();
            InitializeControls();
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

        // 외부 접근
        public void RefreshControls()
        {
            InitializeControls();
        }

        // 더블클릭 시
        private void Row_DoubleClick(object sender, EventArgs e)
        {

        }


        // 신규
        private void ClickedBtnNew(object sender, EventArgs e)
        {
            NewInventoryWindow invWIndow = new NewInventoryWindow("new", this);
            invWIndow.Show();
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
