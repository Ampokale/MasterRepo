using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class userDAL : IRepository<User>
    {
        private NetFSDContext db = new NetFSDContext();


        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = db.Users.ToList();



            foreach (User u in users)
            {
                u.Password = "********";
            }
            return users;


        }



        public bool Add(User t)
        {
            bool op = false;
            try
            {
                db.Users.Add(t);
                db.SaveChanges();
                op = true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return op;
        }

        public bool Delete(int t)
        {
            bool op = false;
            try
            {
                User u = db.Users.Find(t);
                db.Users.Remove(u);
                if (db.SaveChanges() > 0)
                    op = true;


            }
            catch (Exception)
            {

                throw new Exception("Not Deleted");
            }
            return op;
        }



        public bool Update(User t)
        {
            bool op = false;
            try
            {
                db.Users.Update(t);
                db.SaveChanges();
                op = true;
            }
            catch (Exception)
            {

                throw new Exception("Not Updated");
            }
            return op;
        }

        public User GetByID(int t)
        {
            User u = new User();
            u = db.Users.Find(t);
            return u;
        }
    }
}
