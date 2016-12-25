using CrystalCustoms2.model;
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
using System.Windows.Shapes;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// NewInventoryWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewInventoryWindow : Window
    {
        private string workType = null;
        private ManageInventory ManageInventoryInstance = null;

        public NewInventoryWindow(string workType, object parentForm = null)
        {
            this.workType = workType;
            ManageInventoryInstance = (ManageInventory)parentForm;

            InitializeComponent();
        }

        // 신규 등록인 경우
        public void ClickedBtnOk(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgBoxResult;
            using (var db = new LiteDatabase(@"Inventories.db"))
            {
                // 재고정보 등록
                var col = db.GetCollection<Inventories>("Inventories");
                var item = new Inventories
                {
                    Name = txtProductName.Text,
                    Mblno = txtMblno.Text,
                    Hblno = txtHblno.Text,
                    Qty = txtProductQty.Text,
                    Unitprice = Int32.Parse(txtProductUnitprice.Text),
                    Standard = txtProductStandard.Text
                };
                col.Insert(item);

                // 리스트 새로고침
                ManageInventoryInstance.RefreshControls();

                // 등록완료 안내
                msgBoxResult = Xceed.Wpf.Toolkit.MessageBox.Show("재고 정보를 등록하였습니다.");
                this.Close();
            }
        }
    }
}
