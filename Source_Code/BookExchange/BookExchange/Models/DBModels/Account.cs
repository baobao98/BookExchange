﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.DBModels
{
    public partial class Account
    {
        public Account()
        {
            User = new HashSet<User>();
        }

        public int MaTk { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
