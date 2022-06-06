using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class reportDAL : IRepository<Report>
    {
        private NetFSDContext context;
        public reportDAL()
        {
            context = new NetFSDContext();
        }
        public bool Add(Report entity)
        {

            {
                context.Reports.Add(entity);
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

        public Report GetByID(int id)
        {
            return context.Reports.Find(id);
        }

        public IEnumerable<Report> GetAll()
        {
            return context.Reports.ToList();
        }

        public bool Delete(int id)
        {
            var tsk = context.Reports.Find(id);
            context.Reports.Remove(tsk);
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

        public bool Update(Report t)
        {
            bool op = false;
            try
            {
                context.Reports.Update(t);
                context.SaveChanges();
                op = true;
            }
            catch (Exception)
            {

                throw new Exception("Not Updated");
            }
            return op;
        }

        public IEnumerable<Report> GetReportByid(int i) {
            return context.Reports.Where(t => t.PId == i);
        }


    }
}
