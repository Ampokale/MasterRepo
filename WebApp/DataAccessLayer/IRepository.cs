using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    
    public interface IRepository<T>
    {
        //public T loginUser(T t);

        public bool Add(T t);

        public bool Update(T t);

        public bool Delete(int t);
        public T GetByID(int t);

        public IEnumerable<T> GetAll();


    }
}
