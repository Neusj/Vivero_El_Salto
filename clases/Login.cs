﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ViveroElSalto.clases
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Login(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}
