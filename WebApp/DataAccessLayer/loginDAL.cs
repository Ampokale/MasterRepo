using System;
using System.Collections.Generic;
using System.Linq;
using EntityLayer.Models;
namespace DataAccessLayer
{
    public class loginDAL
    {
        private NetFSDContext db;
        public loginDAL()
        {
            db = new NetFSDContext();
        }


        public User loginUser(User u)
        {
            User? op = null;
            User logged = db.Users.Where(t => t.Email == u.Email && t.Password == u.Password).FirstOrDefault();
            if(logged != null)
            {
                 op = logged;
            }
            
            return op;
        }


       
    }
}
