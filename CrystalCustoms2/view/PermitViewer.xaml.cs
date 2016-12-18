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

using CrystalCustoms2.view;
using CrystalCustoms2.model.KoreaCustomsModel;
using System.Reflection;
using System.Data;

namespace CrystalCustoms2.view
{
    /// <summary>
    /// PermitViewer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PermitViewer : UserControl
    {
        private LayoutDocumentPane documentPane = null;
        private cargCsclPrgsInfoQryRtnVo responseResult = null;
        private Dictionary<string, string> permitDict = new Dictionary<string, string>();
        private SettleControl SettleControlInstance;

        public PermitViewer(LayoutDocumentPane documentPaneInstance, cargCsclPrgsInfoQryRtnVo responseResultInstance)
        {
            documentPane = documentPaneInstance;
            responseResult = responseResultInstance;

            InitializeComponent();
            InitializeDictionary();
            InitializeControls();
        }

        // 컨트롤 초기화
        private void InitializeControls()
        {
            int lastCnt = 0; // set to 0
            int baseRowIndex = -1;
            int divItems = 2;
            Dictionary<PropertyInfo, object> propsItems = new Dictionary<PropertyInfo, object>();

            // 수입면장 기본정보
            List<cargCsclPrgsInfoQryVo> infoBlock1 = responseResult.cargCsclPrgsInfoQryVo;
            PropertyInfo[] props1 = infoBlock1.First().GetType().GetProperties();
            foreach (PropertyInfo prop in props1)
            {
                propsItems.Add(prop, infoBlock1.First());
            }

            // 화면에 입력
            foreach (KeyValuePair<PropertyInfo, object> prop in propsItems)
            {
                // 열 위치 구하기
                int posCol = lastCnt % divItems;
                int bindPosCol = bindPosCol = posCol.Equals(0) ? 0 : 2;

                // 기본 행 조정
                if (posCol.Equals(0))
                {
                    RowDefinition newRowDef = new RowDefinition();
                    GridLengthConverter gridLengthConverter = new GridLengthConverter();
                    newRowDef.Height = (GridLength)gridLengthConverter.ConvertFrom("30");
                    permitSummaries.RowDefinitions.Add(newRowDef);
                    baseRowIndex++;
                }

                // 지정값 구하기
                string fieldName = prop.Key.Name;
                string fieldValue = (string)prop.Key.GetValue(prop.Value);
                //string fieldValue = (string)prop.GetValue(prop, null);

                // 패널 생성
                StackPanel newStackPanel = new StackPanel();
                Grid.SetColumnSpan(newStackPanel, 2);
                Grid.SetRow(newStackPanel, baseRowIndex);
                Grid.SetColumn(newStackPanel, bindPosCol);

                // 제목 생성
                Label newLabel = new Label();
                newLabel.Content = permitDict[fieldName];
                newLabel.VerticalAlignment = VerticalAlignment.Center;
                newLabel.Width = 180;
                newStackPanel.Orientation = Orientation.Horizontal;
                newStackPanel.Children.Add(newLabel);

                // 텍스트박스 생성
                TextBox newTextbox = new TextBox();
                newTextbox.Name = "txt" + FirstCharToUpper(fieldName);
                newTextbox.Text = fieldValue;
                newTextbox.Width = 240;
                newTextbox.IsReadOnly = true;
                newStackPanel.Children.Add(newTextbox);

                // 그리드 추가
                permitSummaries.Children.Add(newStackPanel);

                // 추가횟수 증가
                lastCnt++;
            }

            // 수입면장 상세정보 불러오기
            InitializePermitSubData();
        }

        // 수입면장 상세정보
        private void InitializePermitSubData()
        {
            // 수입면장 상세정보
            List<cargCsclPrgsInfoDtlQryVo> infoBlock2 = responseResult.cargCsclPrgsInfoDtlQryVo;
            DataTable dataTable = new DataTable();

            // 컬럼 생성
            string[] dataColumnBindNames = {
                "shedNm", "prcsDttm", "dclrNo", "rlbrDttm", "wght",
                "rlbrBssNo", "bfhnGdncCn", "wghtUt", "pckGcnt", "cargTrcnRelaBsopTpcd",
                "pckUt", "rlbrCn", "shedSgn"
            };
            foreach(string item in dataColumnBindNames)
            {
                dataTable.Columns.Add(item, typeof(string));
            }

            // 행 추가
            foreach (cargCsclPrgsInfoDtlQryVo item in infoBlock2)
            {
                dataTable.Rows.Add(
                    item.shedNm,
                    item.prcsDttm,
                    item.dclrNo,
                    item.rlbrDttm,
                    item.wght,
                    item.rlbrBssNo,
                    item.bfhnGdncCn,
                    item.wghtUt,
                    item.pckGcnt,
                    item.cargTrcnRelaBsopTpcd,
                    item.pckUt,
                    item.rlbrCn,
                    item.shedSgn
                );
            }

            // DataTable의 Default View를 바인딩하기
            permitSubDataGrid.ItemsSource = dataTable.DefaultView;
            permitSubDataGrid.Items.Refresh();
        }

        // 통관 및 운송정보 등록
        private void ClickedBtnSettle(object sender, RoutedEventArgs e)
        {
            // 통관운송정보입력(SettleControl) 불러오기
            SettleControlInstance = new SettleControl(documentPane, responseResult);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "SettleControl",
                Title = "통관운송정보입력",
                Content = SettleControlInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        // 재고정보 등록
        private void ClickedBtnStock(object sender, RoutedEventArgs e)
        {
        }

        // 첫글자 대문자 변환
        private string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("This is empty");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        // 라벨이름 부여
        private void InitializeDictionary()
        {
            permitDict.Add("cargMtNo", "화물관리번호");
            permitDict.Add("prgsStts", "진행상태");
            permitDict.Add("prgsStCd", "진행상태코드");
            permitDict.Add("shipNat", "선박국적");
            permitDict.Add("shipNatNm", "선박국적명");
            permitDict.Add("mblNo", "MBL번호");
            permitDict.Add("hblNo", "HBL번호");
            permitDict.Add("agnc", "대리점");
            permitDict.Add("shcoFlcoSgn", "선사항공사부호");
            permitDict.Add("shcoFlco", "선사항공사");
            permitDict.Add("cargTp", "화물구분");
            permitDict.Add("ldprCd", "적재항코드");
            permitDict.Add("ldprNm", "적재항명");
            permitDict.Add("lodCntyCd", "적출국가코드");
            permitDict.Add("shipNm", "선박명");
            permitDict.Add("pckGcnt", "포장개수");
            permitDict.Add("pckUt", "포장단위");
            permitDict.Add("blPt", "B/ L유형");
            permitDict.Add("blPtNm", "B/ L유형명");
            permitDict.Add("dsprCd", "양륙항코드");
            permitDict.Add("dsprNm", "양륙항명");
            permitDict.Add("etprCstm", "입항세관");
            permitDict.Add("etprDt", "입항일자");
            permitDict.Add("msrm", "용적");
            permitDict.Add("ttwg", "총중량");
            permitDict.Add("wghtUt", "중량단위");
            permitDict.Add("prnm", "품명");
            permitDict.Add("cntrGcnt", "컨테이너개수");
            permitDict.Add("cntrNo", "컨테이너번호");
            permitDict.Add("csclPrgsStts", "통관진행상태");
            permitDict.Add("prcsDttm", "처리일시");
            permitDict.Add("vydf", "항차");
            permitDict.Add("spcnCargCd", "특수화물코드");
            permitDict.Add("mtTrgtCargYnNm", "관리대상화물여부명");
            permitDict.Add("cargTrcnRelaBsopTpcd", "처리구분");
            permitDict.Add("rlbrDttm", "반출입일시");
            permitDict.Add("rlbrCn", "반출입내용");
            permitDict.Add("wght", "중량");
            permitDict.Add("shedSgn", "장치장부호");
            permitDict.Add("shedNm", "장치장명");
            permitDict.Add("dclrNo", "신고번호");
            permitDict.Add("rlbrBssNo", "반출입근거번호");
            permitDict.Add("bfhnGdncCn", "사전안내내용");
        }
    }
}
