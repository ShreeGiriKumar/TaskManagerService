using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DL.DO
{
    public class TaskDO
    {
        public int TaskId { get; set; }
        public string TaskInfo { get; set; }
        public string ParentTask { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsTaskEnded { get; set; }
    }
}
