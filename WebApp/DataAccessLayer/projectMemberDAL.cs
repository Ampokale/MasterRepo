using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class projectMemberDAL : IRepository<ProjectMember>
    {
        private NetFSDContext context;

        public projectMemberDAL(NetFSDContext context)
        {
            this.context = context;
        }
        public bool Add(ProjectMember entity)
        {
            context.ProjectMembers.Add(entity);
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


        public ProjectMember GetByID(int id)
        {
            return context.ProjectMembers.AsNoTracking().FirstOrDefault(
                e => e.ProjectId == Convert.ToInt32(id));
        }

        public IEnumerable<ProjectMember> GetAll()
        {
            return context.ProjectMembers.ToList();
        }

        public bool Delete(int id)
        {
            var proj = context.ProjectMembers.Find(id);
            context.ProjectMembers.Remove(proj);
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

        public bool Update(ProjectMember entity)
        {
            //context
            context.ProjectMembers.Update(entity);
            int affectedrecords = context.SaveChanges();
            if (affectedrecords > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
