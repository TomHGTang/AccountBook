using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBook
{
    /// <summary>
    /// 商家实体
    /// </summary>
    public class Store
    {
        //唯一id
        public Guid ID { get; set; }       
        //商家名称
        public string Name { get; set; }  
    }
}
