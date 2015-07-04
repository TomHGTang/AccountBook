using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using Coding4Fun.Phone.Controls;
using System.Windows.Navigation;
using System.Windows.Media;

namespace AccountBook
{
    public partial class AddAccount : PhoneApplicationPage
    {
        public AddAccount()
        {
            InitializeComponent();
            base.Loaded += new RoutedEventHandler(this.AddAccount_Loaded);                
        }

        private void AddAccount_Loaded(object sender, RoutedEventArgs e)
        {
            BindingAllList();
        }

        //绑定页面上所有列表
        private void BindingAllList()
        {
            Common.BuildListPicker(this.listPickerIncome, 2);
            Common.BuildListPicker(this.listPickerExpenses, 1);
            Common.BuildListPicker(this.listAccountIn);
            Common.BuildListPicker(this.listAccountOut);
            Common.BuildListPicker(this.listTransIn);
            Common.BuildListPicker(this.listTransOut);
            Common.BuildStoreList(this.listStoreOut);
        }

        //新增一条记账记录
        private void appbar_buttonAdd_Click(object sender, EventArgs e)
        {
            //用于隐藏软键盘
            pivot.Focus();
            SaveVoucher();
            App.voucherHelper.SaveToFile();
            App.accountHelper.SaveToFile();
            //刷新重置所有表单
            textBox_Expenses.Text = "";
            textBox_ExpensesDesc.Text = "";
            textBox_Income.Text = "";
            textBox_IncomeDesc.Text = "";
            textBox_Trans.Text = "";
            textBox_TransDesc.Text = ""; 
        }
        
        //新增一条记账记录并返回
        private void appbar_buttonFinish_Click(object sender, EventArgs e)
        {
            if (SaveVoucher())
            {
                App.voucherHelper.SaveToFile();
                App.accountHelper.SaveToFile();
                //保存成功则返回上一页
                base.NavigationService.GoBack();
            }
        }
        
        //返回
        private void appbar_buttonCancel_Click(object sender, EventArgs e)
        {
            base.NavigationService.GoBack();
        }

        //保存收支项
        private bool SaveVoucher()
        {
            
            try
            {
                if (pivot.SelectedIndex == 1)
                {//收入
                    if (this.textBox_Income.Text.Trim() == "")
                    {
                        MessageBox.Show("金额不能为空！");
                        return false;
                    }
                    else
                    {
                        //一条记账记录的对象
                        Voucher voucher = new Voucher
                        {
                            Money = double.Parse(this.textBox_Income.Text),
                            Desc = this.textBox_IncomeDesc.Text,
                            DT = DateTime.Parse(this.DatePickerIncome.Value.Value.ToString("yyyy/MM/dd")),
                            Category = listPickerIncome.SelectedItem.ToString(),
                            Type = 2,
                            Account = listAccountIn.SelectedItem.ToString()
                        };
                        //添加一条记录
                        App.voucherHelper.AddNew(voucher);
                        App.accountHelper.UpdateBalanceIn(voucher.Account, voucher.Money);
                    }
                }
                else if (pivot.SelectedIndex == 0)
                {//支出
                    if (this.textBox_Expenses.Text.Trim() == "")
                    {
                        MessageBox.Show("金额不能为空！");
                        return false;
                    }
                    else
                    {
                        //一条记账记录的对象
                        Voucher voucher = new Voucher
                        {
                            Money = double.Parse(this.textBox_Expenses.Text),
                            Desc = this.textBox_ExpensesDesc.Text,
                            DT = DateTime.Parse(this.DatePickerExpenses.Value.Value.ToString("yyyy/MM/dd")),
                            Category = listPickerExpenses.SelectedItem.ToString(),
                            Type = 1,
                            Account = listAccountOut.SelectedItem.ToString(),
                            Store = listStoreOut.SelectedItem.ToString()
                        };
                        //添加一条记录
                        App.voucherHelper.AddNew(voucher);
                        App.accountHelper.UpdateBalanceOut(voucher.Account, voucher.Money);
                    }
                }
                else
                {//转账
                    if (this.textBox_Trans.Text.Trim() == "")
                    {
                        MessageBox.Show("金额不能为空！");
                        return false;
                    }
                    else
                    {
                        //一条记账记录的对象
                        Voucher voucher = new Voucher
                        {
                            Money = double.Parse(this.textBox_Trans.Text),
                            Desc = this.textBox_TransDesc.Text,
                            DT = DateTime.Parse(this.DatePickerTrans.Value.Value.ToString("yyyy/MM/dd")),
                            Type = 3,
                            Account1 = listTransOut.SelectedItem.ToString(),
                            Account2 = listTransIn.SelectedItem.ToString()
                        };
                        //添加一条记录
                        App.voucherHelper.AddNew(voucher);
                        App.accountHelper.UpdateBalanceTrans(voucher.Account1, voucher.Account2, voucher.Money);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return false;
            }
            ToastPrompt tp = new ToastPrompt();
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            tp.Foreground = brush;
            tp.Background = pivot.Foreground;
            tp.Message = "保存成功";
            tp.Show();
            return true;
        }
    }
}