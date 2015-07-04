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
using Coding4Fun.Phone.Controls;

namespace AccountBook
{
    public partial class Setting : PhoneApplicationPage
    {
        public Setting()
        {
            InitializeComponent();          
            base.Loaded += new RoutedEventHandler(this.AccountSetting_Loaded); 
        }

        private void AccountSetting_Loaded(object sender, RoutedEventArgs e)
        {
            AccountListBox.ItemsSource = Common.GetAllAccount();
        }

        //编辑选中的账户
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                Account editAccount = (Account)button.DataContext;
                TextBox txtBox = new TextBox();
                txtBox.Text = editAccount.Balance.ToString();
                txtBox.InputScope = new InputScope()
                                {
                                    Names = { 
                                        new InputScopeName() 
                                        { NameValue = InputScopeNameValue.Number } 
                                    }
                                };
                CustomMessageBox msgBox = new CustomMessageBox()
                {
                    Caption = "修改账户初始金额",
                    Message = "若已有流水记录，请通过流水页面“记一笔 > 收入”来修改账户金额。否则账户金额将被覆盖，收支平衡将被打乱。",
                    LeftButtonContent = "保存",
                    RightButtonContent = "取消",
                    Content = txtBox
                };

                msgBox.Dismissing += (s1, e1) =>
                {
                    switch (e1.Result)
                    {
                        case CustomMessageBoxResult.LeftButton:
                            try
                            {
                                if (txtBox.Text.Trim() == "")
                                {
                                    MessageBox.Show("账户金额不能为空！");
                                }
                                else if (txtBox.Text.Trim() != editAccount.Balance.ToString())
                                {
                                    App.accountHelper.Update(editAccount, Double.Parse(txtBox.Text));
                                    App.accountHelper.SaveToFile();
                                    ToastPrompt tp = new ToastPrompt();
                                    tp.Background = PageTitle.Foreground;
                                    tp.Message = "修改成功";
                                    tp.Show();
                                }
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            //Fresh
                            AccountListBox.ItemsSource = Common.GetAllAccount();
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

        //删除选中的账户
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                Account delAccount = (Account)button.DataContext;
                CustomMessageBox msgBox = new CustomMessageBox()
                {
                    Caption = "删除账户",
                    Message = "确定要删除" + "账户" + " “" + delAccount.Name + "” " + "吗？",
                    LeftButtonContent = "确定",
                    RightButtonContent = "取消"
                };

                msgBox.Dismissing += (s1, e1) =>
                {
                    switch (e1.Result)
                    {
                        case CustomMessageBoxResult.LeftButton:
                            // TODO: 流水中有账户的不能删掉！
                            if(Common.IsAccountDeleteable(delAccount.Name))
                            {
                                App.accountHelper.Remove(delAccount);
                                App.accountHelper.SaveToFile();

                                ToastPrompt tp = new ToastPrompt();
                                tp.Background = PageTitle.Foreground;
                                tp.Message = "成功删除" + "账户" + " “" + delAccount.Name + "” ";
                                tp.Show();
                            }
                            else
                            {
                                ToastPrompt tp = new ToastPrompt();
                                tp.Background = PageTitle.Foreground;
                                tp.Message = "无法删除！\n流水中有账户" + " “" + delAccount.Name + "” " + "信息。";
                                tp.Show();
                            }
                            
                            AccountListBox.ItemsSource = Common.GetAllAccount();
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

        private void appbar_buttonAdd_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddNewAccount.xaml", UriKind.Relative));
        }       
    }
}