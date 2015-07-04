using System;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Windows.Controls;

namespace AccountBook
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();     
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }
        //页面加载处理
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //trexStoryboard.Begin();
            ////设置收入Tile的总收入金额
            //SummaryIncome.Content ="总收入："+ Common.GetSummaryIncome().ToString()+"元";
            ////设置支出Tile的总支出金额
            //SummaryExpenses.Content = "总支出" + Common.GetSummaryExpenses().ToString()+"元";
            ////计算月结余
            //double mouthIncome = Common.GetThisMouthSummaryIncome();
            //double mouthExpenses = Common.GetThisMouthSummaryExpenses();
            //MouthBalance.Content = "月结余：" + (mouthIncome - mouthExpenses).ToString() + "元";
            ////计算年结余
            //double yearIncome = Common.GetThisYearSummaryIncome();
            //double yearExpenses = Common.GetThisYearSummaryExpenses();
            //YearBalance.Content = "年结余：" + (yearIncome - yearExpenses).ToString() + "元";
            
            //获取今日的账单记录，并绑定到首页的ListBox控件进行显示
            listToday.ItemsSource = Common.GetResent15DayAllRecords();
            listAccount.ItemsSource = Common.GetAllAccount();
        }
        //跳转到新增一笔收入页面
        private void Income_Tile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddAccount.xaml?Type=1", UriKind.Relative));
        }
        //跳转到新增一笔支出页面
        private void Expenses_Tile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddAccount.xaml?Type=0", UriKind.Relative));
        }
        //跳转到图表分析页面
        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChartPage.xaml", UriKind.Relative));
        }
        //跳转到月报表页面
        private void MouthReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MouthReport.xaml", UriKind.Relative));
        }
        //跳转到年报表页面
        private void YearReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/YearReport.xaml", UriKind.Relative));
        }
        //跳转到添加类别页面
        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddCategory.xaml", UriKind.Relative));
        }
        //跳转到查询页面
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }
        //跳转到理财计划页面
        private void Note_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Note.xaml", UriKind.Relative));
        }
        //跳转到设置页面
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));
        }

        
        #region 底部菜单栏相应的事件 

        //跳转到查询页面
        private void appbar_buttonSearch_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }

        //跳转到新增一笔页面
        private void appbar_buttonAdd_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddAccount.xaml?Type=0", UriKind.Relative));
        }

        //跳转到月流水页面
        private void appbar_ItemMonth(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MouthReport.xaml", UriKind.Relative));
        }

        //跳转到年流水页面
        private void appbar_ItemYear(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/YearReport.xaml", UriKind.Relative));
        }

        #endregion       

        //全景控件滑动时自动切换应用程序栏
        private void Panorama_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ApplicationBar.IsVisible == false && ((Panorama)sender).SelectedIndex == 0)
            {
                ApplicationBar.IsVisible = true;
            }
            else
            {
                ApplicationBar.IsVisible = false;
            }
        }

        //跳转到收支分类设置页面
        private void CategorySetting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CategorySetting.xaml", UriKind.Relative));
        }

        //跳转到账户设置页面
        private void AccountSetting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AccountSetting.xaml", UriKind.Relative));
        }

        //跳转到商家设置页面
        private void StoreSetting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/StoreSetting.xaml", UriKind.Relative));
        }

        private void accountItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StackPanel panel = (StackPanel)sender;
            string uri = String.Format("/AccountList.xaml?id={0}", panel.Tag);
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void inCategoryReport_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChartPage.xaml?type=2", UriKind.Relative));
        }

        private void outCategoryReport_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChartPage.xaml?type=1", UriKind.Relative));
        }

        private void storeReport_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/StoreChart.xaml", UriKind.Relative));
        }

        //private void moneyReport_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/MoneyChart.xaml", UriKind.Relative));
        //}
    }
}