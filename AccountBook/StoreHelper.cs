using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBook
{
    /// <summary>
    /// 商家辅助类
    /// </summary>
    public class StoreHelper
    {
        private List<Store> _data;

        public StoreHelper()
        {
            if (!this.LoadFromFile())
            {
                this._data = new List<Store>()
                    {
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "无"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "超市"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "银行"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "公交"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "淘宝"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "其他"
                        }
                    };
            }
        }

        public void AddNew(Store item)
        {
            item.ID = Guid.NewGuid();
            this._data.Add(item);
        }

        public void Update(Store item, string name)
        {
            item.Name = name;
        }

        public void Remove(Store item)
        {
            this._data.Remove(item);
        }

        public bool LoadFromFile()
        {
            this._data = IsolatedStorageHelper.ReadObjectFromFile("Store.dat", typeof(List<Store>)) as List<Store>;
            return (this._data != null);
        }

        public bool SaveToFile()
        {
            return IsolatedStorageHelper.WriteObjectToFile("Store.dat", typeof(List<Store>), this._data);
        }

        public List<Store> data
        {
            get
            {
                if (this._data == null)
                {
                    this.LoadFromFile();
                }
                if (this._data == null)
                {
                    this._data = new List<Store>()
                    {
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "无"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "超市"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "银行"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "公交"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "淘宝"
                        },
                        new Store()
                        {
                            ID=Guid.NewGuid(),
                            Name = "其他"
                        }
                    };
                }
                return this._data;
            }
        }       
    }
}
