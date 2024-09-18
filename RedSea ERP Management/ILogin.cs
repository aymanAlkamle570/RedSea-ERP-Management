using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSea_ERP_Management
{
    public interface ILogin
    {
        /// <summary>
        /// returns true if username and password is exist in users table , otherwise returns false 
        /// </summary>
        /// <param name="username">compares username input with users.uname</param>
        /// <param name="password">compares password input with users.pwd</param>
        /// <returns></returns>
        public bool Login(string username, string password);
    }
}
