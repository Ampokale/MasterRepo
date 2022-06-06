using DataAccessLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }
        [HttpPost("/register")]
        public IActionResult RegisterUser([FromBody]User u)
        {
            try
            {
                 if(_repository.Add(u))
                    return Ok("Done");
                 else
                    return BadRequest("not added");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }




        [HttpPut("/Update")]
        public IActionResult UpdateUser(User u)
        {
            try
            {
                if (_repository.Update(u))
                    return Ok("Done");
                else
                    return BadRequest("Not Updated");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpDelete("/Delete")]
        public IActionResult DeleteUser(int u)
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


        [HttpGet("/getAll")]
        [Authorize]
        public IEnumerable<User> GetAllUser()
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



        [HttpGet("{id}")]
        public User GetUserByID(int id)
        {
            return _repository.GetByID(id);
        }




    }
}
