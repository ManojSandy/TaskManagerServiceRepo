using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManager.BL;
using TaskManager.Entities;

namespace TaskManager.WebAPI.Controllers
{
    public class TaskManagerController : ApiController
    {
        private BusinessLayer task = new BusinessLayer();

        // GET: api/GetTasks
        [HttpGet]
        [Route("api/GetAllTasks")]
        public IQueryable<TaskTable> GetAllTasks()
        {
            return task.GetAllTask();
        }

        // GET: api/GetTasks/5
        [HttpGet]
        [ResponseType(typeof(TaskTable))]
        [Route("api/GetTask/{id}")]
        public IHttpActionResult GetTasks(int id)

        {
            List<TaskTable> tasks = task.GetAllTask().Where(i => i.TaskId.Equals(id)).ToList();
            if (tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks[0]);
        }

        // PUT: api/UpdateTask
        [HttpPut]
        [Route("api/UpdateTask")]
        public IHttpActionResult UpdateTask(TaskTable tasks)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    task.Update(tasks.TaskId, tasks);
                }
                catch (Exception)
                {
                    return Ok("Error is occured during updated !");
                }
                return Ok("Record is updated Sucessfully !");

            }
            return Ok();
        }

        // POST: api/AddTask
        [HttpPost]
        [Route("api/AddTask")]
        public IHttpActionResult AddTask(TaskTable tasks)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    task.Add(tasks);
                }
                catch (Exception)
                {
                    return Ok("Error is occured during inserted !");
                }
                return Ok("Record is added Sucessfully !");

            }
            return Ok();
        }

        // Delete: api/AddTask
        [HttpDelete]
        [Route("api/DeleteTask/{id}")]
        public IHttpActionResult DeleteTask(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    task.Delete(id);
                }
                catch (Exception)
                {
                    return Ok("Error is occured during deleted !");
                }
                return Ok("Record is deleted Sucessfully !");

            }
            return Ok();
        }
    }
}
