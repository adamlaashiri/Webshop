using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop
{
    class Admin
    {
        // Singleton pattern to ensure that only one user is currently accessable throughout the whole code
        private static Admin _instance = null;
        
        private User _user;
        private Admin()
        {
        
        }

        public static Admin getInstance()
        {
            if (_instance == null)
            {
                _instance = new Admin();
            }
            return _instance;
        }

        public void setUser(int userId)
        {
            using (var db = new webshopContext())
            {
                // Because userId is already guaranteed to exist (from login window), no exception catching to do here
                _user = db.Users.Single(u => u.UserId == userId);
            }
        }

        public User getUser()
        {
            return this._user;
        }
    }
}
