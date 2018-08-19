using NBench;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using TaskManager.DL.DO;
using TaskManagerPortal.BL;
using TaskManagerPortal.Controllers;

namespace TaskManager.PerfTest
{
    public class TaskManagerPerfTester
    {
        private const int AcceptableMinAddThroughput = 50;

        private static TaskController controller = new TaskController(new TaskManagerBL())
        {
            Request = new System.Net.Http.HttpRequestMessage(),
            Configuration = new HttpConfiguration()
        };

        List<TaskDO> tasks = new List<TaskDO>();

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            for (var cnt = 0; cnt < 100; cnt++)
            {
                tasks.Add(new TaskDO()
                {
                    TaskId = 0,
                    TaskInfo = string.Format("{0}-{1}","Task Info",cnt),
                    ParentTask = string.Format("{0}-{1}", "Parent Task Info", cnt),
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.AddDays(2),
                    IsTaskEnded = false,
                    Priority = 1
                });
            }
        }

        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void AddTask_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < tasks.Count; i++)
            {
                HttpResponseMessage msg = controller.Post(tasks[i]);
            }
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Iterations, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void GetAllTask_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < AcceptableMinAddThroughput; i++)
            {
                HttpResponseMessage msg = controller.Get();                
            }
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]
        public void GetTaskById_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < AcceptableMinAddThroughput; i++)
            {
                HttpResponseMessage msg = controller.Get(1);
            }
        }
        

        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {

        }
    }
}
