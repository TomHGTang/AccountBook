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
    public partial class Note : PhoneApplicationPage
    {
        public Note()
        {
            InitializeComponent();
            base.Loaded += new RoutedEventHandler(this.StoreSetting_Loaded); 
        }

        private void StoreSetting_Loaded(object sender, RoutedEventArgs e)
        {
            StoreListBox.ItemsSource = Common.GetAllStore();
        }

        //添加商家
        private void appbar_buttonAdd_Click(object sender, EventArgs e)
        {
            TextBox txtBox = new TextBox();
            CustomMessageBox msgBox = new CustomMessageBox()
            {
                Caption = "添加商家",
                LeftButtonContent = "保存",
                RightButtonContent = "取消",
                Content = txtBox
            };

            msgBox.Dismissing += (s1, e1) =>
            {
                switch (e1.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        SaveStore(txtBox.Text.Trim());
                        StoreListBox.ItemsSource = Common.GetAllStore();
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

        //保存商家
        private bool SaveStore(string name)
        {
            try
            {
                if (name == "")
                {
                    MessageBox.Show("商家名称不能为空！");
                    return false;
                }
                else
                {
                    Store store = new Store()
                    {
                        Name = name
                    };
                    App.storeHelper.AddNew(store);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            ToastPrompt tp = new ToastPrompt();
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            tp.Foreground = brush;
            tp.Background = PageTitle.Foreground;
            tp.Message = "保存成功";
            tp.Show();
            return true;
        }

        //编辑商家
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                Store editStore = (Store)button.DataContext;
                TextBox txtBox = new TextBox();
                txtBox.Text = editStore.Name;
                CustomMessageBox msgBox = new CustomMessageBox()
                {
                    Caption = "修改商家",
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
                                    MessageBox.Show("商家名称不能为空！");
                                }
                                else if (txtBox.Text.Trim() != editStore.Name)
                                {
                                    App.storeHelper.Update(editStore, txtBox.Text.Trim());
                                    ToastPrompt tp = new ToastPrompt();
                                    SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                                    tp.Foreground = brush;
                                    tp.Background = PageTitle.Foreground;
                                    tp.Message = "修改成功";
                                    tp.Show();
                                }
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            StoreListBox.ItemsSource = Common.GetAllStore();
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

        //删除商家
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                Store delStore = (Store)button.DataContext;
                CustomMessageBox msgBox = new CustomMessageBox()
                {
                    Caption = "删除商家",
                    Message = "确定要删除商家" + " “" + delStore.Name + "” " + "吗？",
                    LeftButtonContent = "确定",
                    RightButtonContent = "取消"
                };

                msgBox.Dismissing += (s1, e1) =>
                {
                    switch (e1.Result)
                    {
                        case CustomMessageBoxResult.LeftButton:
                            App.storeHelper.Remove(delStore);
                            ToastPrompt tp = new ToastPrompt();
                            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255,255,255,255));
                            tp.Foreground = brush;
                            tp.Background = PageTitle.Foreground;
                            tp.Message = "成功删除商家" + " “" + delStore.Name + "” ";
                            tp.Show();
                            StoreListBox.ItemsSource = Common.GetAllStore();
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
}