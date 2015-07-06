using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AccountBook
{
    public partial class CategoryList : PhoneApplicationPage
    {
        private string name;
        private int year;
        private int month;
        private int isStore;

        public CategoryList()
        {
            InitializeComponent();
        }

        private void items_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StackPanel panel = (StackPanel)sender;
            short type = Common.GetRecordById(panel.Tag.ToString()).Type;
            string uri;
            if (type == 1)
            {
                uri = String.Format("/Edit1.xaml?id={0}", panel.Tag);
            }
            else if (type == 2)
            {
                uri = String.Format("/Edit2.xaml?id={0}", panel.Tag);
            }
            else
            {
                uri = String.Format("/Edit3.xaml?id={0}", panel.Tag);
            }
            PhoneApplicationService.Current.State["id"] = panel.Tag;
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            name = NavigationContext.QueryString["name"];
            year = Int32.Parse(NavigationContext.QueryString["year"]);
            month = Int32.Parse(NavigationContext.QueryString["month"]);
            isStore = Int32.Parse(NavigationContext.QueryString["isStore"]);
            IEnumerable<Voucher> list;
            if(isStore==0)
            {
                list = Common.GetAllRecords().Where(c => c.DT.Year == year && c.DT.Month == month && c.Category == name);
            }
            else
            {
                list = Common.GetAllRecords().Where(c => c.DT.Year == year && c.DT.Month == month && c.Store == name);
            }
         
            PageTitle.Text = name;
            date.Text = year + "年" + month + "月";
            total.Text += list.Sum(c => c.Money);
            listCategory.ItemsSource = list;         
        }

    }
}