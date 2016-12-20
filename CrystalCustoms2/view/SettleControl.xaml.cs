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

using CrystalCustoms2.model;
using CrystalCustoms2.model.KoreaCustomsModel;
using CrystalCustoms2.controller;
using LiteDB;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// SettleControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettleControl : UserControl
    {
        private cargCsclPrgsInfoQryRtnVo responseResult = null;
        private Dictionary<string, string> settleDict = new Dictionary<string, string>();

        public SettleControl()
        {
            InitializeComponent();
        }

        public SettleControl(LayoutDocumentPane documentPaneInstance, cargCsclPrgsInfoQryRtnVo responseResultInstance = null)
        {
            responseResult = responseResultInstance;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            if(responseResult != null) {
                txtMblno.Text = responseResult.cargCsclPrgsInfoQryVo.First().mblNo;
                txtHblno.Text = responseResult.cargCsclPrgsInfoQryVo.First().hblNo;
                txtProductName.Text = responseResult.cargCsclPrgsInfoQryVo.First().prnm;
            }
        }

        // 운송등록 및 입고
        private void ClickedBtnOk(object sender, RoutedEventArgs e)
        {
            // 운송정보 등록
            Settles st = new Settles();
            st.SettleName = txtSettleName.Text;
            st.SettleShipno = txtShipno.Text;
            st.SettleLoadport = txtLoadport.Text;
            st.SettleSize = Int32.Parse(txtSize.Text);
            st.SettleArriveDate = DateTime.Parse(txtArrivedate.Text);
            st.SettleOwn = txtSettleOwn.Text;
            st.SettleMblno = txtMblno.Text;
            st.SettleHblno = txtHblno.Text;
            st.SettleArriveport = txtArriveport.Text;
            st.SettleWeight = txtWeight.Text;
            st.SettleWeightUnit = txtWeightUnit.Text;
            st.SettleVolume = Int32.Parse(txtVolume.Text);
            st.SettleVolumeUnit = txtVolumeUnit.Text;
            st.SettleDuty = Int32.Parse(txtSettleDuty.Text);
            st.SettleVat = Int32.Parse(txtSettleVat.Text);
            st.SettleCommision = Int32.Parse(txtSettleCommision.Text);

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

                // 운송정보 등록
                var col2 = db.GetCollection<Settles>("Settles");
                var item2 = st;
                col2.Insert(item2);
            }

            Xceed.Wpf.Toolkit.MessageBox.Show("운송정보를 등록하였습니다.");
        }

        private void InitializeDIctionary()
        {

        }
    }
}
