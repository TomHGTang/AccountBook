using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Coding4Fun.Phone.Controls;

namespace AccountBook
{
    public partial class AddNewAccount : PhoneApplicationPage
    {
        public AddNewAccount()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            base.NavigationService.GoBack();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(SaveAccount(txtName.Text.Trim(),txtAmount.Text.Trim()))
            {
                App.accountHelper.SaveToFile();
                base.NavigationService.GoBack();
            }
        }

        //保存新添加的账户
        private bool SaveAccount(string name, string money)
        {
            string errMsg = "";
            if(name!=""&&money!="")
            {
                Account account = new Account();
                
                account.ID = Guid.NewGuid();
                account.Name = name;
                account.Balance = Double.Parse(money);
                
                App.accountHelper.AddNew(account);
                
                return true;
            }
            else
            {
                if (name == "")
                {
                    errMsg += "账户名称不能为空！\n";
                }
                if (money == "")
                {
                    errMsg += "账户金额不能为空！\n";
                }
                MessageBox.Show(errMsg);
                return false;
            }
                       
        }        
    }
}