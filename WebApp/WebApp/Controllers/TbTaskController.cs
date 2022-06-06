using DataAccessLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbTaskController : ControllerBase
    {
        private IRepository<TbTask> repository;

        public TbTaskController(IRepository<TbTask> repository)
        {
            this.repository = repository;
        }
        // GET: api/<TaskApiController>
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(repository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // GET api/<TaskApiController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(repository.GetByID(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST api/<TaskApiController>
        [HttpPost]
        public ActionResult Add([FromBody] TbTask task)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isAdded = repository.Add(task);
                    if (isAdded)
                    {
                        return Ok("Task Added");
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<TaskApiController>/5
        [HttpPut]
        public ActionResult UpdateTask([FromBody] TbTask task)
        {

            try
            {
                //var tsk = repository.GetByID(task.TId);
                //if (tsk == null)
                //{
                //    return NotFound("Project not Found");
                //}

                bool isUpdated = repository.Update(task);
                if (isUpdated)
                {
                    return Ok("Task Updated Successfully");
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/<TaskApiController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                {
                    return Ok("Task deleted Successfully");
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}