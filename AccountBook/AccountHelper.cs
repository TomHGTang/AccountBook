using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBook
{
    /// <summary>
    /// 账户帮助类
    /// </summary>
    public class AccountHelper
    {
        private List<Account> _data;

        public AccountHelper()
        {
            if (!this.LoadFromFile())
            {
                this._data = new List<Account>()
                {
                    new Account()
                    {
                        ID=Guid.NewGuid(),
                        Name = "现金",
                        Balance = 0
                    },
                    new Account()
                    {
                        ID=Guid.NewGuid(),
                        Name = "饭卡",
                        Balance = 0
                    },
                    new Account()
                    {
                        ID=Guid.NewGuid(),
                        Name = "银行卡",
                        Balance = 0
                    },
                    new Account()
                    {
                        ID=Guid.NewGuid(),
                        Name = "支付宝",
                        Balance = 0
                    },
                    new Account()
                    {
                        ID=Guid.NewGuid(),
                        Name = "公交卡",
                        Balance = 0
                    },
                    new Account()
                    {
                        ID=Guid.NewGuid(),
                        Name = "应付款项",
                        Balance = 0
                    },
                    new Account()
                    {
                        ID=Guid.NewGuid(),
                        Name = "应收款项",
                        Balance = 0
                    }
                };
            }
        }

        public void AddNew(Account item)
        {
            item.ID = Guid.NewGuid();
            this._data.Add(item);
        }

        public void Update(Account item, double balance)
        {
            item.Balance = balance;
        }

        public void Remove(Account item)
        {
            this._data.Remove(item);
        }

        public bool LoadFromFile()
        {
            this._data = IsolatedStorageHelper.ReadObjectFromFile("Account.dat", typeof(List<Account>)) as List<Account>;
            return (this._data != null);
        }

        public bool SaveToFile()
        {
            return IsolatedStorageHelper.WriteObjectToFile("Account.dat", typeof(List<Account>), this._data);
        }

        public void UpdateBalanceIn(string name, double balance)
        {
            Account item = data.Where(c => c.Name == name).FirstOrDefault();
            item.Balance += balance;
        }

        public void UpdateBalanceOut(string name,double balance)
        {
            Account item = data.Where(c => c.Name == name).FirstOrDefault();
            item.Balance -= balance;
        }

        public void UpdateBalanceTrans(string account1,string account2, double balance)
        {
            UpdateBalanceOut(account1,balance);
            UpdateBalanceIn(account2, balance);
        }

        public List<Account> data
        {
            get
            {
                if (this._data == null)
                {
                    this.LoadFromFile();
                }
                if (this._data == null)
                {
                    this._data = new List<Account>()
                    {
                        new Account()
                        {
                            ID=Guid.NewGuid(),
                            Name = "现金",
                            Balance = 0
                        },
                        new Account()
                        {
                            ID=Guid.NewGuid(),
                            Name = "饭卡",
                            Balance = 0
                        },
                        new Account()
                        {
                            ID=Guid.NewGuid(),
                            Name = "银行卡",
                            Balance = 0
                        },
                        new Account()
                        {
                            ID=Guid.NewGuid(),
                            Name = "支付宝",
                            Balance = 0
                        },
                        new Account()
                        {
                            ID=Guid.NewGuid(),
                            Name = "公交卡",
                            Balance = 0
                        },
                        new Account()
                        {
                            ID=Guid.NewGuid(),
                            Name = "应付款项",
                            Balance = 0
                        },
                        new Account()
                        {
                            ID=Guid.NewGuid(),
                            Name = "应收款项",
                            Balance = 0
                        }
                    };
                }
                return this._data;
            }
        }       

    }
}
