using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Models;
namespace DataAccessLayer
{
    public class FunctionalityDAL
    {
        private NetFSDContext _context; 
        public FunctionalityDAL()
        {
            _context = new NetFSDContext();
        }
        public IEnumerable<TbTask> getProjTable (int i)
        {
            return _context.TbTasks.Where(t => t.PId == i).ToList();
        }
    }
}
