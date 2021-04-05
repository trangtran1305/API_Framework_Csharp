﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment06.Model
{
    public class User
    {
        public long id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public int userStatus { get; set; }
    }
}
