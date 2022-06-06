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
    public class ReportController : ControllerBase
    {
        private IRepository<Report> _repository;
        private reportDAL _reportDAL = new reportDAL();
        public ReportController(IRepository<Report> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        
        public IEnumerable<Report> GetReport()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost("{pid}")]

        public IEnumerable<Report> GetReportByPid(int pid)
        {
            //return Ok( new { projects = _projectDAL.GetProjectsByUid(uid) } );
            return _reportDAL.GetReportByid(pid);
        }


    }
}
