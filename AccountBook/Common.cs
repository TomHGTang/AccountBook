using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.Controls;

namespace AccountBook
{
    public class Common
    {
        #region 数据绑定辅助

        /// <summary>
        /// 将ListPicker控件绑定到收支分类
        /// </summary>
        /// <param name="listPicker">需要绑定的ListPicker控件</param>
        /// <param name="type">收支类别</param>
        public static void BuildListPicker(ListPicker listPicker,int type)
        {
            listPicker.ItemsSource = from c in App.categoryHelper.data
                                     where c.Type == type
                                     select c.Name into c
                                     select c;
        }

        /// <summary>
        /// 将ListPicker控件绑定到账户
        /// </summary>
        /// <param name="accountList">需要绑定的ListPicker控件</param>
        public static void BuildListPicker(ListPicker accountList)
        {
            accountList.ItemsSource = from c in App.accountHelper.data
                                     select c.Name into c
                                     select c;
        }

        /// <summary>
        /// 将ListPicker控件绑定到商家
        /// </summary>
        /// <param name="storeList">需要绑定的ListPicker控件</param>
        public static void BuildStoreList(ListPicker storeList)
        {
            storeList.ItemsSource = from c in App.storeHelper.data
                                    select c.Name into c
                                    select c;
        }

        /// <summary>
        /// 获取所有收支类别
        /// </summary>
        /// <param name="type">收支类型</param>
        /// <returns>类别集合</returns>
        public static IEnumerable<Category> GetCategory(int type)
        {
            return (from c in App.categoryHelper.data
                    where c.Type == type
                    select c);
        }

        /// <summary>
        /// 获取所有的账户
        /// </summary>
        /// <returns>账户集合</returns>
        public static IEnumerable<Account> GetAllAccount()
        {
            return (from c in App.accountHelper.data select c);
        }

        /// <summary>
        /// 获取所有的商家
        /// </summary>
        /// <returns>商家集合</returns>
        public static IEnumerable<Store> GetAllStore()
        {
            return (from c in App.storeHelper.data select c);
        }

        #endregion

        /// <summary>
        /// 获取预算的金额
        /// </summary>
        /// <param name="ItemName">类别名称</param>
        /// <returns></returns>
        public static double GetLimitOf(string ItemName)
        {
            IEnumerable<Budget> source = from c in App.budgetHelper.data
                                         where c.ItemName == ItemName
                                         select c;
            if (source.Count<Budget>() > 0)
            {
                return (double)source.FirstOrDefault<Budget>().Limit;
            }
            return -1.0;
        }

        /// <summary>
        /// 获取所有的记账记录
        /// </summary>
        /// <returns>记账记录集合</returns>
        public static IEnumerable<Voucher> GetAllRecords()
        {
            return (from c in App.voucherHelper.data select c);
        }

        /// <summary>
        /// 获取某月的所有记录
        /// </summary>
        /// <param name="month">月</param>
        /// <param name="year">年</param>
        /// <returns>记账记录枚举集合</returns>
        public static IEnumerable<Voucher> GetThisMonthAllRecords(int month, int year)
        {
            return (from c in App.voucherHelper.data
                    where (c.DT.Month == month) && (c.DT.Year == year)
                    select c);
        }

        /// <summary>
        /// 获取最近15天的所有记录
        /// </summary>
        /// <returns>记账记录枚举集合</returns>
        public static IEnumerable<Voucher> GetResent15DayAllRecords()
        {
            return (from c in App.voucherHelper.data
                    where c.DT.DayOfYear - DateTime.Today.DayOfYear > -16 && c.DT.DayOfYear - DateTime.Today.DayOfYear <= 0
                    orderby c.DT.ToUniversalTime() descending
                    select c);
        }

        /// <summary>
        /// 获取某天的所有记录
        /// </summary>
        /// <param name="day">日</param>
        /// <param name="month">月</param>
        /// <param name="year">年</param>
        /// <param name="source">记账数据源</param>
        /// <returns>某日记账记录枚举集合</returns>
        public static IEnumerable<Voucher> GetDayAllRecords(int day, int month, int year, List<Voucher> source)
        {
            return (from c in source
                    where c.DT.Day == day && c.DT.Month == month && c.DT.Year == year
                    orderby c.DT descending
                    select c);
        }

        /// <summary>
        /// 获取本年的所有记录
        /// </summary>
        /// <param name="year">年</param>
        /// <returns>记账记录枚举集合</returns>
        public static IEnumerable<Voucher> GetThisYearAllRecords(int year)
        {
            return (from c in App.voucherHelper.data
                    where c.DT.Year == year
                    select c);
        }

        /// <summary>
        /// 获取本月的类别总金额
        /// </summary>
        /// <param name="ItemName">类别名称</param>
        /// <param name="type">类别类型</param>
        /// <returns>金额</returns>
        public static double GetThisMonthSummaryOf(string ItemName,short type)
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Month == DateTime.Now.Month) && (c.DT.Year == DateTime.Now.Year)) && (c.Type == type) && (c.Category == ItemName)
                                          select c.Money)).Sum();
        }

        /// <summary>
        ///  获取本月的类别总金额
        /// </summary>
        /// <param name="category">类别实体</param>
        /// <returns>金额</returns>
        public static double GetThisMonthSummaryOf(Category category)
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Month == DateTime.Now.Month) && (c.DT.Year == DateTime.Now.Year)) && (c.Type == category.Type) && (c.Category == category.Name)
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 获取总支出
        /// </summary>
        /// <returns>金额</returns>
        public static double GetSummaryExpenses()
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where c.Type == 1
                                          select c.Money)).Sum();
        }

        # region 账户信息处理

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="id">账户ID</param>
        /// <returns>账户</returns>
        public static Account GetAccount(string id)
        {
            return App.accountHelper.data.Where(c => c.ID.ToString() == id).FirstOrDefault();
        }

        /// <summary>
        /// 获取某个账户的流入金额
        /// </summary>
        /// <param name="accountName">账户名称</param>
        /// <returns>金额</returns>
        public  static double GetAccountInSummary(string accountName)
        {
            double incoumeAmmount = App.voucherHelper.data.Where(c => c.Type == 2 && c.Account == accountName)
                .Select(c => c.Money).Sum();
            double transInAmmount = App.voucherHelper.data.Where(c => c.Type == 3 && c.Account2 == accountName)
                .Select(c => c.Money).Sum();
            return incoumeAmmount + transInAmmount;
        }
 
        /// <summary>
        /// 获取某个账户的流出金额
        /// </summary>
        /// <param name="accountName">账户名称</param>
        /// <returns>金额</returns>
        public static double GetAccountOutSummary(string accountName)
        {
            double outcoumeAmmount = App.voucherHelper.data.Where(c => c.Type == 1 && c.Account == accountName)
                .Select(c => c.Money).Sum();
            double transOutAmmount = App.voucherHelper.data.Where(c => c.Type == 3 && c.Account1 == accountName)
                .Select(c => c.Money).Sum();
            return outcoumeAmmount + transOutAmmount;
        }

        /// <summary>
        /// 获取某个账户的所有流水记录
        /// </summary>
        /// <param name="accountName">账户名称</param>
        /// <returns>流水记录</returns>
        public static IEnumerable<Voucher> GetAccountItems(string accountName)
        {
            var inItems = App.voucherHelper.data.Where(c => c.Type == 2 && c.Account == accountName);
            var transInItems = App.voucherHelper.data.Where(c => c.Type == 3 && c.Account2 == accountName);
            var outItems = App.voucherHelper.data.Where(c => c.Type == 1 && c.Account == accountName);
            var transOutItems = App.voucherHelper.data.Where(c => c.Type == 3 && c.Account1 == accountName);

            return inItems.Union(transInItems).Union(outItems).Union(transOutItems).OrderByDescending(c => c.DT);
        }

        #endregion

        /// <summary>
        /// 获取本年的支出
        /// </summary>
        /// <returns>金额</returns>
        public static double GetThisYearSummaryExpenses()
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Year == DateTime.Now.Year)) && (c.Type == 1)
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 获取某年的支出
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static double GetYearSummaryExpenses(int year)
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Year == year)) && (c.Type == 1)
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 获取本月的支出
        /// </summary>
        /// <returns></returns>
        public static double GetThisMouthSummaryExpenses()
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Year == DateTime.Now.Year)) && ((c.DT.Month == DateTime.Now.Month)) && (c.Type == 1)
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 获取某月的支出
        /// </summary>
        /// <param name="mouth">月份</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static double GetMouthSummaryExpenses(int mouth, int year)
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Year == year)) && ((c.DT.Month == mouth)) && (c.Type == 1)
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 获取总收入
        /// </summary>
        /// <returns>金额</returns>
        public static double GetSummaryIncome()
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where c.Type == 2
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 获取本年的收入
        /// </summary>
        /// <returns>金额</returns>
        public static double GetThisYearSummaryIncome()
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Year == DateTime.Now.Year)) && (c.Type == 2)
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 获取某年的收入
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static double GetYearSummaryIncome(int year)
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Year == year)) && (c.Type == 2)
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 获取本月的收入
        /// </summary>
        /// <returns>金额</returns>
        public static double GetThisMouthSummaryIncome()
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Year == DateTime.Now.Year)) && ((c.DT.Month == DateTime.Now.Month)) && (c.Type == 2)
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 获取某月的收入
        /// </summary>
        /// <param name="mouth">月份</param>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static double GetMouthSummaryIncome(int mouth, int year)
        {
            return ((IEnumerable<double>)(from c in App.voucherHelper.data
                                          where ((c.DT.Year == year)) && ((c.DT.Month == mouth)) && (c.Type == 2)
                                          select c.Money)).Sum();
        }

        /// <summary>
        /// 检查流水中是否有账户记录，以验证账户是否可以删除
        /// </summary>
        /// <param name="accountName">账户名称</param>
        /// <returns>是否可以删除</returns>
        public static bool IsAccountDeleteable(string accountName)
        {
            return !(App.voucherHelper.data.Exists(c => c.Account == accountName || c.Account1 == accountName || c.Account2 == accountName));
        }

        /// <summary>
        /// 查询记账记录
        /// </summary>
        /// <param name="begin">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="keyWords">关键字</param>
        /// <returns>记账记录</returns>
        public static IEnumerable<Voucher> Search(DateTime? begin, DateTime? end, string keyWords)
        {
            if (keyWords == "")
            {
                return (from c in App.voucherHelper.data
                        where c.DT >= begin && c.DT <= end
                        select c);
            }
            else
            {
                return (from c in App.voucherHelper.data
                        where c.DT >= begin && c.DT <= end && c.Desc.IndexOf(keyWords) >= 0
                        select c);
            }
        }
    }
}
