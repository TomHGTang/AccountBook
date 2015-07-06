using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AccountBook
{
    public partial class Search : PhoneApplicationPage
    {
        public Search()
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

        // 处理菜单栏单击事件，查询记账记录
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            DateTime? begin = DatePickerBegin.Value;
            DateTime? end = DatePickerEnd.Value;
            listReport.ItemsSource = Common.Search(begin, end, keyWords.Text);
        }
    }
}