﻿using System;
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
    public partial class AccountList : PhoneApplicationPage
    {
        private string id;

        public AccountList()
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
            id = NavigationContext.QueryString["id"];
            string accountName = Common.GetAccount(id).Name;
            
            PageTitle.Text = accountName;
            txtBalanceIn.Text = "流入 " + Common.GetAccountInSummary(accountName).ToString();
            txtBalanceOut.Text = "流出 " + Common.GetAccountOutSummary(accountName).ToString();

            listAccount.ItemsSource = Common.GetAccountItems(accountName);
        }
    }
}