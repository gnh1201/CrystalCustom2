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

namespace CrystalCustoms2.view
{
    /// <summary>
    /// ManageApikeys.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ManageApikeys : UserControl
    {
        public int currentRowId = 0;
        public int saveMode = 0;
        private DataTable dataTable = null;

        public ManageApikeys()
        {
            InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControls();
        }

        private void InitializeControls()
        {
            bindDataColumns(); // 열 생성
            bindDataRows(); // 행 생성

            // DataGrid 이벤트 처리
            keyDataGrid.SelectionChanged += new SelectionChangedEventHandler(
                keyDataGrid_SelectionChanged
            );
        }

        // 데이터 그리드 열
        private void bindDataColumns()
        {
            // DataTable 생성
            dataTable = new DataTable();

            // 컬럼 생성
            dataTable.Columns.Add("ID", typeof(string));
            dataTable.Columns.Add("TYPE", typeof(string));
            dataTable.Columns.Add("NAME", typeof(string));
            dataTable.Columns.Add("DESC", typeof(string));
            dataTable.Columns.Add("CODE", typeof(string));
            dataTable.Columns.Add("CNT", typeof(string));
            dataTable.Columns.Add("LAST", typeof(string));
            dataTable.Columns.Add("DATE", typeof(string));
        }

        // 데이터 그리드 행
        private void bindDataRows()
        {
            // 데이터 불러오기
            List<Apikeys> dataItems = OpApikeys.GetItems(0);
            foreach (Apikeys item in dataItems)
            {
                dataTable.Rows.Add(new object[] {
                    item.KeyId,
                    item.KeyType,
                    item.KeyName,
                    item.KeyDesc,
                    item.KeyCode,
                    item.KeyCount,
                    item.KeyLastused.ToString(OpApikeys.datetimeFormat),
                    item.KeyDatetime.ToString(OpApikeys.datetimeFormat)
                });
            }

            // DataTable의 Default View를 바인딩하기
            keyDataGrid.ItemsSource = dataTable.DefaultView;
            keyDataGrid.Items.Refresh();

            // 선택번호 초기화
            //currentRowId = 0;
        }

        // 정보 조회
        private void keyDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            IList selectedItems = dg.SelectedItems;

            if (selectedItems.Count <= 0)
                return;

            DataRowView row = (DataRowView)dg.SelectedItems[0];
            int rowId = Int32.Parse((string)row[0]);

            List<Apikeys> dataItems = OpApikeys.GetItems(rowId);
            foreach(Apikeys item in dataItems)
            {
                txtKeyId.Text = item.KeyId.ToString();
                txtKeyType.Text = item.KeyType;
                txtKeyName.Text = item.KeyName;
                txtKeyDesc.Text = item.KeyDesc;
                txtKeycode.Text = item.KeyCode;
                txtKeyDatetime.Text = item.KeyDatetime.ToString(OpApikeys.datetimeFormat);
                break;
            }

            // 현재등록번호
            currentRowId = rowId;

            // 신규버튼 초기화
            if (saveMode == 1)
            {
                saveMode = 0;
                btnSave.Content = "신규";
            }
        }

        // 신규
        private void ClickedBtnSave(object sender, EventArgs e)
        {
            if (saveMode == 0)
            {
                saveMode = 1;

                txtKeyId.Text = "0";
                txtKeyType.Text = "NewKey";
                txtKeyName.Text = "NewServiceKey";
                txtKeyDesc.Text = "새로운 인증키";
                txtKeycode.Text = "123abc123abc123abc";
                txtKeyDatetime.Text = "2016-12-17 00:00:00";
                txtKeyName.Focus();
                btnSave.Content = "저장";
            }
            else
            {
                // 등록
                Apikeys st = new Apikeys();
                st.KeyId = 0;
                st.KeyType = txtKeyType.Text;
                st.KeyName = txtKeyType.Text;
                st.KeyDesc = txtKeyDesc.Text;
                st.KeyCode = txtKeycode.Text;
                st.KeyDatetime = DateTime.Parse(txtKeyDatetime.Text);

                MessageBoxResult result;
                if (OpApikeys.AddItem(st) > 0)
                {
                    bindDataColumns(); // 열 생성
                    bindDataRows(); // 행 생성
                    result = Xceed.Wpf.Toolkit.MessageBox.Show("등록을 완료하였습니다.");
                } else
                {
                    result = Xceed.Wpf.Toolkit.MessageBox.Show("등록을 실패하였습니다.");
                }
            }
        }

        // 정보 수정
        private void ClickedBtnEdit(object sender, EventArgs e)
        {
            MessageBoxResult result;
            if (currentRowId > 0)
            {
                Apikeys st = new Apikeys();
                st.KeyId = Int32.Parse(txtKeyId.Text);
                st.KeyType = txtKeyType.Text;
                st.KeyName = txtKeyName.Text;
                st.KeyDesc = txtKeyDesc.Text;
                st.KeyCode = txtKeycode.Text;
                st.KeyDatetime = DateTime.Parse(txtKeyDatetime.Text);

                if (OpApikeys.UpdateItem(st) > 0)
                {
                    bindDataColumns(); // 열 생성
                    bindDataRows(); // 행 생성
                    result = Xceed.Wpf.Toolkit.MessageBox.Show("수정을 완료하였습니다.");
                }
                else
                {
                    result = Xceed.Wpf.Toolkit.MessageBox.Show("수정을 실패하였습니다.");
                }
            } else
            {
                result = Xceed.Wpf.Toolkit.MessageBox.Show("수정할 대상이 없습니다.");
            }
        }

        // 정보 삭제
        private void ClickedBtnDelete(object sender, EventArgs e)
        {
            MessageBoxResult result;
            if (currentRowId > 0)
            {
                if (OpApikeys.DeleteItem(currentRowId) > 0)
                {
                    bindDataColumns(); // 열 생성
                    bindDataRows(); // 행 생성
                    result = Xceed.Wpf.Toolkit.MessageBox.Show("삭제를 완료했습니다.");
                } else
                {
                    result = Xceed.Wpf.Toolkit.MessageBox.Show("삭제를 실패했습니다.");
                }
            } else
            {
                result = Xceed.Wpf.Toolkit.MessageBox.Show("삭제할 대상이 없습니다.");
            }
        }

        // 이전 조회
        private void ClickedBtnPrev(object sender, EventArgs e)
        {
            MessageBoxResult result;
            if (currentRowId > 1) {
                keyDataGrid.SelectedIndex--;
            } else
            {
                result = Xceed.Wpf.Toolkit.MessageBox.Show("이전 건이 없습니다.");
            }
        }

        // 다음 조회
        private void ClickedBtnNext(object sender, EventArgs e)
        {
            MessageBoxResult result;
            if (keyDataGrid.Items.Count > (keyDataGrid.SelectedIndex + 1))
            {
                keyDataGrid.SelectedIndex++;
            } else
            {
                result = Xceed.Wpf.Toolkit.MessageBox.Show("다음 건이 없습니다.");
            }
        }
    }
}
