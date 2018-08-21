using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DL.DO;
using TaskManager.DL.EF;

namespace TaskManager.DL.DL
{
    public class TaskManagerDL
    {
        public TaskManagerEntities taskManagerContext = new TaskManagerEntities();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TaskData> GetAllTasks()
        {
            return taskManagerContext.TaskDatas.ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public TaskData GetTask(int taskId)
        {
            return taskManagerContext.TaskDatas.Where(x => x.TaskId == taskId).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(TaskData taskData)
        {
            taskManagerContext.TaskDatas.Add(taskData);
            taskManagerContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTask(TaskData taskData)
        {
            TaskData task = taskManagerContext.TaskDatas.Where(x => x.TaskId == taskData.TaskId).FirstOrDefault();
            task.TaskInfo = taskData.TaskInfo;
            task.ParentTask = string.IsNullOrEmpty(taskData.ParentTask) ? null : taskData.ParentTask;
            task.Priority = taskData.Priority;
            task.StartDate = taskData.StartDate;
            task.EndDate = taskData.EndDate;
            task.IsTaskEnded = taskData.IsTaskEnded;

            taskManagerContext.SaveChanges();
        }
    }
}
