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
    public partial class Edit1 : PhoneApplicationPage
    {
        private string id;
        private Voucher item;
        private double moneyBefore;
        private string accountBefore;

        public Edit1()
        {
            InitializeComponent();
                      
            Common.BuildListPicker(this.listPickerExpenses, 1);
            Common.BuildListPicker(this.listAccountOut);
            Common.BuildStoreList(this.listStoreOut);

            id = PhoneApplicationService.Current.State["id"].ToString();
            item = Common.GetRecordById(id);

            moneyBefore = item.Money;
            accountBefore = item.Account;

            listPickerExpenses.SelectedItem = item.Category;
            listAccountOut.SelectedItem = item.Account;
            listStoreOut.SelectedItem = item.Store;
            DatePickerExpenses.Value = item.DT;
            textBox_Expenses.Text = item.Money.ToString();
            textBox_ExpensesDesc.Text = item.Desc;
        }

        private void appbar_buttonSave_Click(object sender, EventArgs e)
        {
            if (this.textBox_Expenses.Text.Trim() == "")
            {
                MessageBox.Show("金额不能为空！");
            }
            else
            {
                item.Money = double.Parse(this.textBox_Expenses.Text);
                item.Desc = this.textBox_ExpensesDesc.Text;
                item.DT = DateTime.Parse(this.DatePickerExpenses.Value.Value.ToString("yyyy/MM/dd"));
                item.Category = listPickerExpenses.SelectedItem.ToString();
                item.Account = listAccountOut.SelectedItem.ToString();
                item.Store = listStoreOut.SelectedItem.ToString();
                
                App.accountHelper.UpdateBalanceIn(accountBefore, moneyBefore);
                App.accountHelper.UpdateBalanceOut(item.Account, item.Money);

                App.voucherHelper.Update(item);
                App.voucherHelper.SaveToFile();
                App.accountHelper.SaveToFile();

                NavigationService.GoBack();
            }
        }

        private void appbar_buttonDelete_Click(object sender, EventArgs e)
        {
            CustomMessageBox msgBox = new CustomMessageBox()
            {
                Caption = "删除流水",
                Message = "确定要删除这条流水吗？",
                LeftButtonContent = "确定",
                RightButtonContent = "取消"
            };

            msgBox.Dismissing += (s1, e1) =>
            {
                switch (e1.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        App.voucherHelper.Remove(item);
                        App.voucherHelper.SaveToFile();
                        //删除支出，那么需要加回来
                        App.accountHelper.UpdateBalanceIn(item.Account, item.Money);
                        App.accountHelper.SaveToFile();

                        NavigationService.GoBack();
                        break;
                    case CustomMessageBoxResult.RightButton:
                        break;
                    case CustomMessageBoxResult.None:
                        break;
                    default: break;
                }
            };
            msgBox.Show();    
        }
    }
}