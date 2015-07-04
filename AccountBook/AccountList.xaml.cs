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
    public partial class AccountList : PhoneApplicationPage
    {
        private string id;

        public AccountList()
        {
            InitializeComponent();
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