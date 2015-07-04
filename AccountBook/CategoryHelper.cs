using System;
using System.Collections.Generic;

namespace AccountBook
{
    /// <summary>
    /// 类别操作帮助类
    /// </summary>
    public class CategoryHelper
    {
        private List<Category> _data;

        public CategoryHelper()
        {
            if (!this.LoadFromFile())
            {
                this._data = new List<Category>()
                    {
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="食品酒水"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="早中晚餐"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="衣服饰品"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="居家物业"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="行车交通"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="交流通讯"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="休闲娱乐"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="学习进修"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="人情往来"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="医疗保健"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="其他杂项"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="工资收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="利息收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="加班收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="奖金收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="投资收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="兼职收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="经营所得"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="其他收入"
                        }
                    };
            }
        }

        public void AddNew(Category item)
        {
            item.ID = Guid.NewGuid();
            this._data.Add(item);
        }

        public void Update(Category item,string name)
        {
                item.Name = name;
        }

        public void Remove(Category item)
        {
            this._data.Remove(item);
        }

        public bool LoadFromFile()
        {
            this._data = IsolatedStorageHelper.ReadObjectFromFile("Category.dat", typeof(List<Category>)) as List<Category>;
            return (this._data != null);
        }

        public bool SaveToFile()
        {
            return IsolatedStorageHelper.WriteObjectToFile("Category.dat", typeof(List<Category>), this._data);
        }

        public List<Category> data
        {
            get
            {
                if (this._data == null)
                {
                    this.LoadFromFile();
                }
                if (this._data == null)
                {
                    this._data = new List<Category>()
                    {
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="食品酒水"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="早中晚餐"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="衣服饰品"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="居家物业"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="行车交通"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="交流通讯"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="休闲娱乐"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="学习进修"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="人情往来"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="医疗保健"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=1,
                            Name="其他杂项"
                        },
                        new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="工资收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="利息收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="加班收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="奖金收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="投资收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="兼职收入"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="经营所得"
                        },
                         new Category(){
                            ID=Guid.NewGuid(),
                            Type=2,
                            Name="其他收入"
                        }
                    };                
                }
                return this._data;
            }
        }       
    }
}
