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

        public ManageSettlement(LayoutDocumentPane documentPane, cargCsclPrgsInfoQryRtnVo responseResult = null)
        {
            this.documentPane = documentPane;
            this.responseResult = responseResult;

            InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControls();
        }

        private void InitializeControls()
        {
        }

        // 정보 조회
        private void settleDataGrid_SelectionChanged(object sender, EventArgs e)
        {
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
