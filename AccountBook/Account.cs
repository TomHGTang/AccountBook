using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBook
{
    /// <summary>
    /// 账户实体
    /// </summary>
    public class Account
    {
        //唯一id
        public Guid ID { get; set; }        
        //账户名称
        public string Name { get; set; }
        //金额
        public double Balance { get; set; }
    }
}
