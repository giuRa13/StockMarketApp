﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public InvalidPasswordException(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public InvalidPasswordException(string message, string username, string password) : base(message)
        {
            Username = username;
            Password = password;
        }
        public InvalidPasswordException(string message, Exception innerException, string username, string password) : base(message, innerException)
        {
            Username = username;
            Password = password;
        }
    }

}
