using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManager.DL.DO;
using TaskManagerPortal.BL;

namespace TaskManagerPortal.Controllers
{  
    public class TaskController : ApiController
    {
        ITaskManagerBL taskManagerBL = null;

        public TaskController(ITaskManagerBL _taskManagerBL)
        {
            taskManagerBL = _taskManagerBL;
        }

        // GET api/<controller>
        /// <summary>
        /// To Get All The Tasks
        /// </summary>
        /// <returns></returns>        
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, taskManagerBL.GetAllTasks());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET api/<controller>/5
        /// <summary>
        /// /// To Get Task by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, taskManagerBL.GetTask(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // POST api/<controller>        
        /// <summary>
        /// To Add a new Task
        /// </summary>
        /// <param name="taskDO"></param>
        public HttpResponseMessage Post([FromBody]TaskDO taskDO)
        {
            try
            {
                taskManagerBL.AddTask(taskDO);
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
                
        // PUT api/<controller>/5
        /// <summary>
        /// To Update an existing Task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskDO"></param>
        /// <returns></returns>                
        public HttpResponseMessage Put(int id, [FromBody]TaskDO taskDO)
        {
            try
            {
                taskManagerBL.UpdateTask(taskDO);
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}