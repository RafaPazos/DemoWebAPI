using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace simpleaspnetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private const string V = "me";

        // In this service we're using an in-memory list to store tasks, just to keep things simple.
        // All of your tasks will be lost each time you run the service
        private static List<Models.Task> db = new List<Models.Task>();
        private static int taskId;

        /*
         * GET all tasks for user
         */
        [HttpGet]
        public IEnumerable<Models.Task> Get()
        {
            IEnumerable<Models.Task> userTasks = db.Where(t => t.Owner == V);
            return userTasks;
        }

        /*
        * POST a new task for user
        */
        [HttpPost]
        public IActionResult Post([FromBody] Models.Task task)
        {
            if (String.IsNullOrEmpty(task.Text))
            {
                return BadRequest("Please provide a task description");
            }

            task.Id = taskId++;
            task.Owner = V;
            task.Completed = false;
            task.DateModified = DateTime.UtcNow;
            db.Add(task);
            return Ok();
        }

        /*
         * DELETE a task for user
         */
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            Models.Task task = db.Where(t => t.Owner.Equals(V) && t.Id.Equals(id)).FirstOrDefault();
            db.Remove(task);
        }
    }
}
