using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

using CrystalCustoms2.view;
using Xceed.Wpf.AvalonDock.Layout;

namespace CrystalCustoms2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    ///

    public partial class MainWindow
    {
        private PermitControl PermitControlInstance = null;
        private ManageApikeys ManageApikeysInstance = null;
        private AppSetting AppSettingInstance = null;
        private SettleControl SettleControlInstance = null;
        private ManageAddressBook AddressBookInstance = null;
        private ManageEstimate ManageEstimateInstance = null;
        private ManagePermit ManagePermitInstance = null;
        private ManageSettlement ManageSettlementInstance = null;
        private ManageInventory ManageInventoryInstance = null;

        public MainWindow()
        {
            InitializeComponent();

            // 이미지 초기화
            BitmapImage bmImage = new BitmapImage();
            bmImage.BeginInit();
            bmImage.UriSource = new Uri("images/intro.jpg", UriKind.Relative);
            bmImage.EndInit();
            IntroImage.Width = 550;
            IntroImage.Height = 367;
            IntroImage.Source = bmImage;
        }

        private void PermitClicked(object sender, RoutedEventArgs e)
        {
            PermitControlInstance = new PermitControl(documentPane);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "PermitControl",
                Title = "수입면장입력",
                Content = PermitControlInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        private void ManageApikeysClicked(object sender, RoutedEventArgs e)
        {
            ManageApikeysInstance = new ManageApikeys();
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "ManageApikeys",
                Title = "인증키관리",
                Content = ManageApikeysInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        private void AppSettingClicked(object sender, RoutedEventArgs e)
        {
            AppSettingInstance = new AppSetting();
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "AppSetting",
                Title = "어플리케이션 설정",
                Content = AppSettingInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        private void SettleClicked(object sender, RoutedEventArgs e)
        {
            SettleControlInstance = new SettleControl();
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "SettleControl",
                Title = "운송정보 등록",
                Content = SettleControlInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        private void AddressBookClicked(object sender, RoutedEventArgs e)
        {
            AddressBookInstance = new ManageAddressBook();
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "AddressBook",
                Title = "거래처 관리",
                Content = AddressBookInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        private void ManageEstimateClicked(object sender, RoutedEventArgs e)
        {
            ManageEstimateInstance = new ManageEstimate(documentPane);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "ManageEstimate",
                Title = "견적서 관리",
                Content = ManageEstimateInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        private void ManagePermitClicked(object sender, RoutedEventArgs e)
        {
            ManagePermitInstance = new ManagePermit(documentPane);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "ManagePermit",
                Title = "면장관리",
                Content = ManagePermitInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        private void ManageSettlementClicked(object sender, RoutedEventArgs e)
        {
            ManageSettlementInstance = new ManageSettlement(documentPane);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "ManageSettlement",
                Title = "운송관리",
                Content = ManageSettlementInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }

        private void ManageInventoryClicked(object sender, RoutedEventArgs e)
        {
            ManageInventoryInstance = new ManageInventory(documentPane);
            LayoutDocument ld = new LayoutDocument
            {
                ContentId = "ManageInventory",
                Title = "재고관리",
                Content = ManageInventoryInstance,
                IconSource = new BitmapImage(new Uri("images/document.png", UriKind.Relative))
            };
            documentPane.Children.Add(ld);
            documentPane.Children.Last().IsActive = true;
        }
    }
}
