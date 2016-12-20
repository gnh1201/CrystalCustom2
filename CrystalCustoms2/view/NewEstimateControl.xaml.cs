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
    /// NewEstimateControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewEstimateControl : UserControl
    {
        private LayoutDocumentPane documentPane;
        private List<EstimateItems> estItems = new List<EstimateItems>();

        public NewEstimateControl(LayoutDocumentPane documentPaneInstance)
        {
            documentPane = documentPaneInstance;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        ///  견적 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickedBtnSave(object sender, RoutedEventArgs e)
        {
            Estimates dataItem = new Estimates
            {
                ReptName = txtReptName.Text,
                ReptTel = txtReptTel.Text,
                ReptFax = txtReptFax.Text,
                ReptOwn = txtReptOwn.Text,
                ReptAddress = txtReptAddress.Text,
                ReptDate = txtReptDate.Text,
                ReptNo = txtReptNo.Text,
                SendName = txtSendName.Text,
                SendAddress = txtSendAddress.Text,
                SendTel = txtSendTel.Text,
                SendFax = txtSendFax.Text,
                SendDeadline = txtSendDeadline.Text,
                SendOwn = txtSendOwn.Text,
                SalesOwn = txtSalesOwn.Text,
                ShipDate = txtShipDate.Text,
                ShipType = txtShipType.Text,
                DeliveryPoint = txtDeliveryPoint.Text,
                PayCond = txtPayCond.Text,
                TaxRate = txtTaxRate.Text,
                Items = estItems,
                Amount = txtAmount.Text
            };

            // db에 저장
            using (var db = new LiteDatabase(@"Estimates.db"))
            {
                // 견적 등록
                var col = db.GetCollection<Estimates>("Estimates");
                var item = dataItem;
                col.Insert(item);

                Xceed.Wpf.Toolkit.MessageBox.Show("견적등록이 완료되었습니다.");
            }
        }

        private void ClickedBtnAddItem(object sender, RoutedEventArgs e)
        {
            WindowInventory newForm = new WindowInventory(this);
            newForm.Show();
        }

        private void ClickedBtnRemoveItem(object sender, RoutedEventArgs e)
        {

        }

        // 항목 추가
        public void AddOptionItem(string[] row) {
            estItems = new List<EstimateItems>();
            estDataGrid.Items.Add(row);
        }
    }
}
