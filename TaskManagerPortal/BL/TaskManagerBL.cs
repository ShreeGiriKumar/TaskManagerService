using System.Collections.Generic;
using System.Linq;
using TaskManager.DL.DL;
using TaskManager.DL.DO;
using TaskManager.DL.EF;

namespace TaskManagerPortal.BL
{
    public class TaskManagerBL : ITaskManagerBL
    {
        TaskManagerDL taskManagerDL = new TaskManagerDL();

        /// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        public List<TaskDO> GetAllTasks()
        {
            List<TaskDO> lstTaskDO = new List<TaskDO>();

            taskManagerDL.GetAllTasks().ToList().ForEach(x =>
            {
                lstTaskDO.Add(new TaskDO()
                {
                    TaskId = x.TaskId,
                    TaskInfo = x.TaskInfo,
                    ParentTask = x.ParentTask,
                    Priority = x.Priority,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsTaskEnded = x.IsTaskEnded
                });
            });

            return lstTaskDO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public TaskDO GetTask(int taskId)
        {
            var taskData = taskManagerDL.GetTask(taskId);

            return new TaskDO() {
                TaskId = taskData.TaskId,
                TaskInfo = taskData.TaskInfo,
                ParentTask = taskData.ParentTask,
                Priority = taskData.Priority,
                StartDate = taskData.StartDate,
                EndDate = taskData.EndDate,
                IsTaskEnded = taskData.IsTaskEnded
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(TaskDO task)
        {   
            taskManagerDL.AddTask(new TaskData()
            {                
                TaskInfo = task.TaskInfo,
                ParentTask = string.IsNullOrEmpty(task.ParentTask) ? null : task.ParentTask,
                Priority = task.Priority,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                IsTaskEnded = task.IsTaskEnded
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTask(TaskDO task)
        {
            taskManagerDL.UpdateTask(new TaskData()
            {
                TaskId = task.TaskId,
                TaskInfo = task.TaskInfo,
                ParentTask = string.IsNullOrEmpty(task.ParentTask) ? null : task.ParentTask,
                Priority = task.Priority,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                IsTaskEnded = task.IsTaskEnded
            });
        }
    }
}