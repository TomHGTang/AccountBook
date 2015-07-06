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
    public partial class Edit2 : PhoneApplicationPage
    {
        private string id;
        private Voucher item;
        private double moneyBefore;
        private string accountBefore;

        public Edit2()
        {
            InitializeComponent();

            Common.BuildListPicker(this.listPickerIncome, 2);
            Common.BuildListPicker(this.listAccountIn);

            id = PhoneApplicationService.Current.State["id"].ToString();
            item = Common.GetRecordById(id);

            moneyBefore = item.Money;
            accountBefore = item.Account;

            listPickerIncome.SelectedItem = item.Category;
            listAccountIn.SelectedItem = item.Account;
            DatePickerIncome.Value = item.DT;
            textBox_Income.Text = item.Money.ToString();
            textBox_IncomeDesc.Text = item.Desc;
        }

        private void appbar_buttonSave_Click(object sender, EventArgs e)
        {
            if (this.textBox_Income.Text.Trim() == "")
            {
                MessageBox.Show("金额不能为空！");
            }
            else
            {
                item.Money = double.Parse(this.textBox_Income.Text);
                item.Desc = this.textBox_IncomeDesc.Text;
                item.DT = DateTime.Parse(this.DatePickerIncome.Value.Value.ToString("yyyy/MM/dd"));
                item.Category = listPickerIncome.SelectedItem.ToString();
                item.Account = listAccountIn.SelectedItem.ToString();

                App.accountHelper.UpdateBalanceOut(accountBefore, moneyBefore);
                App.accountHelper.UpdateBalanceIn(item.Account, item.Money);
                
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
                        //删去收入，那么需要减掉
                        App.accountHelper.UpdateBalanceOut(item.Account, item.Money);
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