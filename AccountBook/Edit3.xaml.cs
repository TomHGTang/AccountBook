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
    public partial class Edit3 : PhoneApplicationPage
    {
        private string id;
        private Voucher item;
        private double moneyBefore;
        private string account1Before;
        private string account2Before;

        public Edit3()
        {
            InitializeComponent();

            Common.BuildListPicker(this.listTransIn);
            Common.BuildListPicker(this.listTransOut);

            id = PhoneApplicationService.Current.State["id"].ToString();
            item = Common.GetRecordById(id);

            moneyBefore = item.Money;
            account1Before = item.Account1;
            account2Before = item.Account2;

            listTransOut.SelectedItem = item.Account1;
            listTransIn.SelectedItem = item.Account2;
            DatePickerTrans.Value = item.DT;
            textBox_Trans.Text = item.Money.ToString();
            textBox_TransDesc.Text = item.Desc;
        }

        private void appbar_buttonSave_Click(object sender, EventArgs e)
        {
            if (this.textBox_Trans.Text.Trim() == "")
            {
                MessageBox.Show("金额不能为空！");
            }
            else
            {
                item.Money = double.Parse(this.textBox_Trans.Text);
                item.Desc = this.textBox_TransDesc.Text;
                item.DT = DateTime.Parse(this.DatePickerTrans.Value.Value.ToString("yyyy/MM/dd"));
                item.Account1 = listTransOut.SelectedItem.ToString();
                item.Account2 = listTransIn.SelectedItem.ToString();

                App.accountHelper.UpdateBalanceTrans(account2Before, account1Before, moneyBefore);
                App.accountHelper.UpdateBalanceTrans(item.Account1, item.Account2, item.Money);

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
                        //删掉就相当于转回去
                        App.accountHelper.UpdateBalanceTrans(item.Account2, item.Account1, item.Money);
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