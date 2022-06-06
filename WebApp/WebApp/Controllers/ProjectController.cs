using DataAccessLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ProjectsDAL _projectDAL = new ProjectsDAL();
        private IRepository<Project> _repository;

        public ProjectController(IRepository<Project> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddProject(Project p)
        {
            try
            {
                _repository.Add(p);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Done");
        }




        [HttpPut]
        public IActionResult UpdateProject(Project p)
        {
            try
            {
                if (_repository.Update(p))
                    return Ok("Done");
                else
                    return BadRequest("Not Updated");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpDelete]
        public IActionResult DeleteProject(int u)
        {
            try
            {
                if (_repository.Delete(u))
                    return Ok("Done");
                else
                    return BadRequest("Not Deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpGet("/getAllProjects")]

        public IEnumerable<Project> GetAllProjects()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{pid}")]

        public IEnumerable<Project> GetProjectsByPid(int pid)
        {
            return _projectDAL.GetProjectsByPid(pid);
        }
        // only one get method


        [HttpPost("{uid}")]

        public IEnumerable<Project> GetProjects(int uid)
        {
            //return Ok( new { projects = _projectDAL.GetProjectsByUid(uid) } );
            return _projectDAL.GetProjectsByUid(uid);
        }
        //[HttpGet("{userID}")]

        //public IEnumerable<Project> Projects(int userID)
        //{
        //    return _projectDAL.GetProjectsByUid(userID);
        //}





    }
}
