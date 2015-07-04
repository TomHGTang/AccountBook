using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;

namespace AccountBook
{
    public class CategorySumTable
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Percentage { get; set; }
    }

    public partial class ChartPage : PhoneApplicationPage
    {
        private int type;
        private int year;
        private int month;

        public ChartPage()
        {
            InitializeComponent();
            base.Loaded += new RoutedEventHandler(this.Report_Loaded);
        }

        // 页面加载事件处理
        private void Report_Loaded(object sender, RoutedEventArgs e)
        {
            type = Int32.Parse(NavigationContext.QueryString["type"]);
            month = DateTime.Today.Month;
            year = DateTime.Today.Year;
                       
            DrawChart();
        }

        //绘制收入或支出分类报表
        public void DrawChart()
        {
            if (type == 1)
            {
                pageTitle.Title = year + "年" + month + "月" + "支出分类报表";
            }
            else
            {
                pageTitle.Title = year + "年" + month + "月" + "收入分类报表";
            }

            // 创建图表的数据源对象
            ObservableCollection<ChartData> collecion = new ObservableCollection<ChartData>();
            // 获取所有的记账记录
            IEnumerable<Voucher> allRecords = null;

            switch (type)
            {
                case 1://支出
                    allRecords = Common.GetThisMonthAllRecords(month, year)
                        .Where(c => c.Type == 1);

                    break;
                case 2://收入
                    allRecords = Common.GetThisMonthAllRecords(month, year)
                        .Where(c => c.Type == 2);
                    break;
                default:
                    break;
            }
            // 获取所有记账记录里面的类别
            IEnumerable<string> enumerable2 = (from c in allRecords select c.Category).Distinct<string>();
            // 按照类别来统计记账的数目
            foreach (var item in enumerable2)
            {
                // 获取该类别下的钱的枚举集合
                IEnumerable<double> enumerable3 = from c in allRecords.Where<Voucher>(c => c.Category == item) select c.Money;
                // 添加一条图表的数据
                ChartData data = new ChartData
                {
                    Sum = enumerable3.Sum(),
                    TypeName = item
                };
                collecion.Add(data);
            }
            // 新建一个饼状图表的控件对象
            PieSeries series = new PieSeries();
            // 新建一个柱形图表的控件对象
            ColumnSeries series2 = new ColumnSeries();
            // 绑定数据源
            series.ItemsSource = collecion;
            series.DependentValueBinding = new Binding("Sum");
            series.IndependentValueBinding = new Binding("TypeName");
            series2.ItemsSource = collecion;
            series2.DependentValueBinding = new Binding("Sum");
            series2.IndependentValueBinding = new Binding("TypeName");
            // 添加到图表里面
            this.chart1.Series.Clear();
            this.chart1.Series.Add(series);
            this.chart2.Series.Clear();
            this.chart2.Series.Add(series2);

            double total = collecion.Select(c => c.Sum).Sum();
            List<CategorySumTable> lcs = new List<CategorySumTable>();
            foreach(var item in collecion)
            {
                double a = item.Sum / total * 100;
                double b=Convert.ToDouble(String.Format("{0:f2}",a));
                CategorySumTable cs = new CategorySumTable()
                {
                    Name = item.TypeName,
                    Amount = item.Sum,
                    Percentage = b + "%"
                };
                lcs.Add(cs);
            }

            listMouthReport.ItemsSource = lcs;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch ((sender as ApplicationBarIconButton).Text)
                {
                    case "上一月":
                        this.month--;
                        if (this.month <= 0)
                        {
                            this.year--;
                            this.month = 12;
                        }
                        break;
                    case "下一月":
                        this.month++;
                        if (this.month >= 12)
                        {
                            this.year++;
                            this.month = 1;
                        }
                        break;
                }
                DrawChart();
            }
            catch
            {
            }
        }
    }
}