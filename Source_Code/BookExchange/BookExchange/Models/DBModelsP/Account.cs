using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Models.DBModels
{
    public partial class Account
    {
        public Account(string username, string password)
        {
            this.TaiKhoan = username;
            this.MatKhau = password;
        }
    }
}
