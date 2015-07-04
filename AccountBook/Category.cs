//using System.Collections.Generic;
using System;

namespace AccountBook
{
    /// <summary>
    /// 类别实体类
    /// </summary>
    public class Category
    {
        //唯一id
        public Guid ID { get; set; }
        //账单类型 1表示支出 2表示收入
        public short Type { get; set; }
        //类别名称
        public string Name { get; set; }      
    }
}
