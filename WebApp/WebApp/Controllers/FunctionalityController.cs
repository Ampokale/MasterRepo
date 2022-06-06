using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Models;
using DataAccessLayer;
namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionalityController : ControllerBase
    {

        private FunctionalityDAL _repository;
        public FunctionalityController()
        {
            _repository = new FunctionalityDAL();
        }


        [HttpGet("{id}")]


        public IEnumerable<TbTask> getProjectDetails(int id)
        {
            return _repository.getProjTable(id);
        }


    }
}
