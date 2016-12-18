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

        public MainWindow()
        {
            InitializeComponent();
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
    }
}
