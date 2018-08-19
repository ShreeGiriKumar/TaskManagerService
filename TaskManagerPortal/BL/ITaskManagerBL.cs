using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.DL.DO;

namespace TaskManagerPortal.BL
{
    public interface ITaskManagerBL
    {
        List<TaskDO> GetAllTasks();
        TaskDO GetTask(int taskId);
        void AddTask(TaskDO task);
        void UpdateTask(TaskDO task);
    }
}