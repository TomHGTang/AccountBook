﻿#pragma checksum "D:\大学\软件工程\AccountBook\AccountBook\Edit1 - 复制.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3356944496DA38C2DF24A35C1BFBE301"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace AccountBook {
    
    
    public partial class Edit1 : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox textBox_Expenses;
        
        internal Microsoft.Phone.Controls.ListPicker listAccountOut;
        
        internal Microsoft.Phone.Controls.ListPicker listPickerExpenses;
        
        internal Microsoft.Phone.Controls.DatePicker DatePickerExpenses;
        
        internal Microsoft.Phone.Controls.ListPicker listStoreOut;
        
        internal System.Windows.Controls.TextBox textBox_ExpensesDesc;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_buttonSave;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_buttonDelete;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/AccountBook;component/Edit1%20-%20%E5%A4%8D%E5%88%B6.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.textBox_Expenses = ((System.Windows.Controls.TextBox)(this.FindName("textBox_Expenses")));
            this.listAccountOut = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listAccountOut")));
            this.listPickerExpenses = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listPickerExpenses")));
            this.DatePickerExpenses = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("DatePickerExpenses")));
            this.listStoreOut = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listStoreOut")));
            this.textBox_ExpensesDesc = ((System.Windows.Controls.TextBox)(this.FindName("textBox_ExpensesDesc")));
            this.appbar_buttonSave = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_buttonSave")));
            this.appbar_buttonDelete = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_buttonDelete")));
        }
    }
}

