﻿#pragma checksum "D:\大学\软件工程\AccountBook\AccountBook\AddAccount.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C7810CC62E1CC95A2244D9CA76DA8817"
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
    
    
    public partial class AddAccount : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot pivot;
        
        internal System.Windows.Controls.TextBox textBox_Expenses;
        
        internal Microsoft.Phone.Controls.ListPicker listAccountOut;
        
        internal Microsoft.Phone.Controls.ListPicker listPickerExpenses;
        
        internal Microsoft.Phone.Controls.DatePicker DatePickerExpenses;
        
        internal Microsoft.Phone.Controls.ListPicker listStoreOut;
        
        internal System.Windows.Controls.TextBox textBox_ExpensesDesc;
        
        internal System.Windows.Controls.TextBox textBox_Income;
        
        internal Microsoft.Phone.Controls.ListPicker listAccountIn;
        
        internal Microsoft.Phone.Controls.ListPicker listPickerIncome;
        
        internal Microsoft.Phone.Controls.DatePicker DatePickerIncome;
        
        internal System.Windows.Controls.TextBox textBox_IncomeDesc;
        
        internal System.Windows.Controls.TextBox textBox_Trans;
        
        internal Microsoft.Phone.Controls.ListPicker listTransOut;
        
        internal Microsoft.Phone.Controls.ListPicker listTransIn;
        
        internal Microsoft.Phone.Controls.DatePicker DatePickerTrans;
        
        internal System.Windows.Controls.TextBox textBox_TransDesc;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_buttonAdd;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_buttonFinish;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_buttonCancel;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/AccountBook;component/AddAccount.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.pivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("pivot")));
            this.textBox_Expenses = ((System.Windows.Controls.TextBox)(this.FindName("textBox_Expenses")));
            this.listAccountOut = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listAccountOut")));
            this.listPickerExpenses = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listPickerExpenses")));
            this.DatePickerExpenses = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("DatePickerExpenses")));
            this.listStoreOut = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listStoreOut")));
            this.textBox_ExpensesDesc = ((System.Windows.Controls.TextBox)(this.FindName("textBox_ExpensesDesc")));
            this.textBox_Income = ((System.Windows.Controls.TextBox)(this.FindName("textBox_Income")));
            this.listAccountIn = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listAccountIn")));
            this.listPickerIncome = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listPickerIncome")));
            this.DatePickerIncome = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("DatePickerIncome")));
            this.textBox_IncomeDesc = ((System.Windows.Controls.TextBox)(this.FindName("textBox_IncomeDesc")));
            this.textBox_Trans = ((System.Windows.Controls.TextBox)(this.FindName("textBox_Trans")));
            this.listTransOut = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listTransOut")));
            this.listTransIn = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listTransIn")));
            this.DatePickerTrans = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("DatePickerTrans")));
            this.textBox_TransDesc = ((System.Windows.Controls.TextBox)(this.FindName("textBox_TransDesc")));
            this.appbar_buttonAdd = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_buttonAdd")));
            this.appbar_buttonFinish = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_buttonFinish")));
            this.appbar_buttonCancel = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_buttonCancel")));
        }
    }
}

