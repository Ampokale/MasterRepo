using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ProjectsDAL : IRepository<Project>
    {

        private NetFSDContext context = new NetFSDContext();

        public List<ProjectMember> GetProjects(int uid)
        {

            //var projects = new List<Project>();
            List<ProjectMember> projects = context.ProjectMembers.Where(t => t.UserId == uid).ToList();
            return projects;
        }


        public List<Project> GetProjectsByUid(int sid)
        {

            var projects = new List<Project>();
            List<ProjectMember> p = context.ProjectMembers.Where(t => t.UserId == sid).ToList();

            foreach (var item in p)
            {

                var name = context.Projects.Where(t => t.ProjectId == Convert.ToInt32(item.ProjectId)).FirstOrDefault();
                projects.Add(name);


            }
            return projects;
        }

        public List<Project> GetProjectsByPid(int pid)
        {

            //var projects = new List<Project>();
            List<Project> projects = context.Projects.Where(t => t.ProjectId == pid).ToList();
            return projects;
        }

        public bool Add(Project entity)
        {
            context.Projects.Add(entity);
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

        public Project GetByID(int id)
        {
            return context.Projects.AsNoTracking().FirstOrDefault(
                e => e.ProjectId == id);
        }

        public IEnumerable<Project> GetAll()
        {
            IEnumerable<Project> p= context.Projects.ToList();
            return p;
        }

        public bool Delete(int id)
        {
            var proj = context.Projects.Find(id);
            context.Projects.Remove(proj);
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

        public bool Update(Project entity)
        {
            //context
            context.Projects.Update(entity);
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

