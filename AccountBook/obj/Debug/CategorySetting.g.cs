﻿#pragma checksum "D:\大学\软件工程\AccountBook\AccountBook\CategorySetting.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "259490128A11298448905A31E1971FC5"
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
    
    
    public partial class AddCategory : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot pivot;
        
        internal System.Windows.Controls.ListBox OutListBox;
        
        internal System.Windows.Controls.ListBox InListBox;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_buttonAdd;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/AccountBook;component/CategorySetting.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.pivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("pivot")));
            this.OutListBox = ((System.Windows.Controls.ListBox)(this.FindName("OutListBox")));
            this.InListBox = ((System.Windows.Controls.ListBox)(this.FindName("InListBox")));
            this.appbar_buttonAdd = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_buttonAdd")));
        }
    }
}

