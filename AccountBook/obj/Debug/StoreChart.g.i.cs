﻿#pragma checksum "D:\大学\软件工程\AccountBook\AccountBook\StoreChart.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C0A985A1D6580620871A6F3633E47D1E"
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
using Microsoft.Windows.Controls.DataVisualization.Charting;
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
    
    
    public partial class StoreChart : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot pageTitle;
        
        internal Microsoft.Windows.Controls.DataVisualization.Charting.Chart chart1;
        
        internal Microsoft.Windows.Controls.DataVisualization.Charting.PieSeries PieChart1;
        
        internal Microsoft.Windows.Controls.DataVisualization.Charting.Chart chart2;
        
        internal Microsoft.Windows.Controls.DataVisualization.Charting.ColumnSeries ColumnSeries1;
        
        internal System.Windows.Controls.ListBox listMouthReport;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/AccountBook;component/StoreChart.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.pageTitle = ((Microsoft.Phone.Controls.Pivot)(this.FindName("pageTitle")));
            this.chart1 = ((Microsoft.Windows.Controls.DataVisualization.Charting.Chart)(this.FindName("chart1")));
            this.PieChart1 = ((Microsoft.Windows.Controls.DataVisualization.Charting.PieSeries)(this.FindName("PieChart1")));
            this.chart2 = ((Microsoft.Windows.Controls.DataVisualization.Charting.Chart)(this.FindName("chart2")));
            this.ColumnSeries1 = ((Microsoft.Windows.Controls.DataVisualization.Charting.ColumnSeries)(this.FindName("ColumnSeries1")));
            this.listMouthReport = ((System.Windows.Controls.ListBox)(this.FindName("listMouthReport")));
        }
    }
}

