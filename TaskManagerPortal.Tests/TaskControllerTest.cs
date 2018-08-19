using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using TaskManager.DL.DO;
using TaskManagerPortal.BL;
using TaskManagerPortal.Controllers;

namespace TaskManagerPortal.Tests
{
    [TestClass]
    public class TaskControllerTest
    {
        [TestMethod]
        public void GetAllTasks()
        {
            List<TaskDO> lstTaskDO = new List<TaskDO>()
            {
                new TaskDO()
                {
                    TaskId = 1,
                    TaskInfo = "Test Task 1",
                    ParentTask = "Parent Task 1",
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.Date.AddDays(3),
                    Priority = 1,
                    IsTaskEnded = false
                },
                new TaskDO()
                {
                    TaskId = 2,
                    TaskInfo = "Test Task 2",
                    ParentTask = "Parent Task 2",
                    StartDate = DateTime.Now.Date.AddDays(-3),
                    EndDate = DateTime.Now.Date.AddDays(-1),
                    Priority = 2,
                    IsTaskEnded = true
                },
            };

            var mock = new Mock<ITaskManagerBL>();
            mock.Setup(service => service.GetAllTasks()).Returns(lstTaskDO);

            var controller = new TaskController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualTasks = controller.Get();
            List<TaskDO> resp;
            actualTasks.TryGetContentValue(out resp);
            Assert.AreEqual(lstTaskDO.Count, resp.Count);
            Assert.AreEqual(lstTaskDO[0].ParentTask, resp[0].ParentTask);
        }

        [TestMethod]
        public void GetTask()
        {
            List<TaskDO> lstTaskDO = new List<TaskDO>()
            {
                new TaskDO()
                {
                    TaskId = 1,
                    TaskInfo = "Test Task 1",
                    ParentTask = "Parent Task 1",
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.Date.AddDays(3),
                    Priority = 1,
                    IsTaskEnded = false
                },
                new TaskDO()
                {
                    TaskId = 2,
                    TaskInfo = "Test Task 2",
                    ParentTask = "Parent Task 2",
                    StartDate = DateTime.Now.Date.AddDays(-3),
                    EndDate = DateTime.Now.Date.AddDays(-1),
                    Priority = 2,
                    IsTaskEnded = true
                },
            };

            var mock = new Mock<ITaskManagerBL>();
            mock.Setup(service => service.GetTask(1)).Returns(lstTaskDO[0]);

            var controller = new TaskController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualTasks = controller.Get(1);
            TaskDO resp;
            actualTasks.TryGetContentValue(out resp);
            Assert.IsNotNull(resp);
            Assert.AreEqual(lstTaskDO[0].ParentTask, resp.ParentTask);
            Assert.AreSame(lstTaskDO[0], resp);
        }

        [TestMethod]
        public void AddTask()
        {
            TaskDO task =
                  new TaskDO()
                  {
                      TaskId = 1,
                      TaskInfo = "Test Task 1",
                      ParentTask = "Parent Task 1",
                      StartDate = DateTime.Now.Date,
                      EndDate = DateTime.Now.Date.AddDays(3),
                      Priority = 1,
                      IsTaskEnded = false
                  };

            var mock = new Mock<ITaskManagerBL>();
            mock.Setup(service => service.AddTask(task));

            var controller = new TaskController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualTasks = controller.Post(task);

            Assert.AreEqual("OK", actualTasks.StatusCode.ToString());
        }


        [TestMethod]
        public void UpdateTask()
        {
            TaskDO task =
                  new TaskDO()
                  {
                      TaskId = 1,
                      TaskInfo = "Test Task 1",
                      ParentTask = "Parent Task 1",
                      StartDate = DateTime.Now.Date,
                      EndDate = DateTime.Now.Date.AddDays(3),
                      Priority = 1,
                      IsTaskEnded = false
                  };

            var mock = new Mock<ITaskManagerBL>();
            mock.Setup(service => service.UpdateTask(task));

            var controller = new TaskController(mock.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            HttpResponseMessage actualTasks = controller.Put(task.TaskId, task);

            Assert.AreEqual("OK", actualTasks.StatusCode.ToString());
        }
    }
}
