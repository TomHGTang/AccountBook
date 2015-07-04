using System;
namespace AccountBook
{
    public class Voucher
    {
        //金额
        public double Money { get; set; }
        //账单类型 1表示支出 2表示收入 3表示转账
        public short Type { get; set; }
        //说明
        public string Desc { get; set; }        
        //时间
        public DateTime DT { get; set; }
        //唯一id
        public Guid ID { get; set; }
        //类别（收支用）
        public string Category { get; set; }
        //账户
        public string Account { get; set; }
        //账户1（仅转账时用）
        public string Account1 { get; set; }
        //账户2（仅转账时用）
        public string Account2 { get; set; }
        //商家（仅支出用）
        public string Store { get; set; }
    }
}
