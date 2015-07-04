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
    public partial class AddCategory : PhoneApplicationPage
    {
        public AddCategory()
        {
            InitializeComponent();
            FreshList();
        }

        //刷新列表
        private void FreshList()
        {
            OutListBox.ItemsSource = Common.GetCategory(1);
            InListBox.ItemsSource = Common.GetCategory(2);
        }

        //添加分类
        private void appbar_buttonAdd_Click(object sender, EventArgs e)
        {
            string kind = pivot.SelectedIndex > 0 ? "收入" : "支出";
            TextBox txtBox = new TextBox();
            CustomMessageBox msgBox = new CustomMessageBox()
            {
                Caption = "添加" + kind + "分类",
                LeftButtonContent = "保存",
                RightButtonContent = "取消",
                Content = txtBox
            };

            msgBox.Dismissing += (s1, e1) =>
            {
                switch(e1.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        SaveCategory(txtBox.Text.Trim());
                        FreshList();
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

        //保存分类
        private bool SaveCategory(string name)
        {
            try
            {
                if(name == "")
                {
                    MessageBox.Show("类别名称不能为空！");
                    return false;
                }
                else
                {
                    Category category = new Category(){
                        Name = name,
                        Type = short.Parse((pivot.SelectedIndex + 1).ToString())
                    };
                    App.categoryHelper.AddNew(category);
                    App.categoryHelper.SaveToFile();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
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

        //删除分类
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            string kind = pivot.SelectedIndex > 0 ? "收入" : "支出";
            var button = sender as Button;
            if(button!=null)
            {
                Category delCategory = (Category)button.DataContext;                
                CustomMessageBox msgBox = new CustomMessageBox()
                {
                    Caption = "删除分类",
                    Message = "确定要删除" + kind + "分类" + " “" + delCategory.Name + "” " + "吗？",
                    LeftButtonContent = "确定",
                    RightButtonContent = "取消"
                };

                msgBox.Dismissing += (s1, e1) =>
                {
                    switch (e1.Result)
                    {
                        case CustomMessageBoxResult.LeftButton:
                            App.categoryHelper.Remove(delCategory);
                            App.categoryHelper.SaveToFile();

                            ToastPrompt tp = new ToastPrompt();
                            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255,255,255,255));
                            tp.Foreground = brush;
                            tp.Background = pivot.Foreground;
                            tp.Message = "成功删除" + kind + "分类" + " “" + delCategory.Name + "” ";
                            tp.Show();  
                          
                            FreshList();
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

        //编辑分类
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            string kind = pivot.SelectedIndex > 0 ? "收入" : "支出";
            var button = sender as Button;
            if (button != null)
            {
                Category editCategory = (Category)button.DataContext;
                TextBox txtBox = new TextBox();
                txtBox.Text = editCategory.Name;
                CustomMessageBox msgBox = new CustomMessageBox()
                {
                    Caption = "修改分类",
                    LeftButtonContent = "确定",
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
                                    MessageBox.Show("类别名称不能为空！"); 
                                }
                                else if (txtBox.Text.Trim() != editCategory.Name)
                                {
                                    App.categoryHelper.Update(editCategory, txtBox.Text.Trim());
                                    App.categoryHelper.SaveToFile();

                                    ToastPrompt tp = new ToastPrompt();
                                    SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                                    tp.Foreground = brush;
                                    tp.Background = pivot.Foreground;
                                    tp.Message = "修改成功";
                                    tp.Show(); 
                                }
                            }
                            catch(Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }                                                      
                            FreshList();
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