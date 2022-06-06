using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class taskDAL : IRepository<TbTask>
    {
        private NetFSDContext context;
        public taskDAL()
        {
            context = new NetFSDContext();
        }
        public bool Add(TbTask entity)
        {

            {
                context.TbTasks.Add(entity);
                int affectedRecords = context.SaveChanges();
                if (affectedRecords > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public TbTask GetByID(int id)
        {
            return context.TbTasks.Find(id);
        }

        public IEnumerable<TbTask> GetAll()
        {
            return context.TbTasks.ToList();
        }

        public bool Delete(int id)
        {
            var tsk = context.TbTasks.Find(id);
            context.TbTasks.Remove(tsk);
            int affectedRecords = context.SaveChanges();
            if (affectedRecords > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(TbTask t)
        {
            bool op = false;
            try
            {
                context.TbTasks.Update(t);
                context.SaveChanges();
                op = true;
            }
            catch (Exception)
            {

                throw new Exception("Not Updated");
            }
            return op;
        }


    }
}
