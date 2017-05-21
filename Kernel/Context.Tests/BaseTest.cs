using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projects.Context;
using Projects.Managers;
using System;

namespace Kernel.Tests
{
    public class BaseTest
    {
        protected Worker Worker1 { get; set; }
        protected Worker Worker2 { get; set; }

        protected Project Project1 { get; set; }
        protected Project Project2 { get; set; }

        protected ProjectsManager ProjectsManager { get; set; }
        protected WorkersManager WorkersManager { get; set; }

        public BaseTest()
        {
            Worker1 = new Worker("fn1", "ln1", "mn1", "e1");
            Worker2 = new Worker("fn2", "ln2", "mn2", "e2");

            Project1 = new Project("n1", "c1", "c1")
            {
                Comment = "c1",
                Employee = Worker1,
                Leader = Worker2,
                Priority = 10,
                Start = DateTime.Now,
                End = DateTime.Now
            };
            Project2 = new Project("n2", "c2", "c2")
            {
                Comment = "c2",
                Employee = Worker1,
                Leader = Worker2,
                Priority = 10,
                Start = DateTime.Now,
                End = DateTime.Now
            };

            ProjectsManager = new ProjectsManager();
            WorkersManager = new WorkersManager();
        }

        [TestInitialize]
        public void StartTest()
        {
            using (var context = new ProjectsEntities())
            {
                context.Database.ExecuteSqlCommand("truncate table ProjectsWorkersBase");

                context.ProjectsBase.RemoveRange(context.ProjectsBase);

                context.WorkersBase.RemoveRange(context.WorkersBase);

                context.SaveChanges();

                context.WorkersBase.Add(Worker1);
                context.WorkersBase.Add(Worker2);
                context.SaveChanges();
                
                context.ProjectsBase.Add(Project1);
                context.ProjectsBase.Add(Project2);
                context.SaveChanges();
            }
            Start();
        }

        protected virtual void Start()
        {

        }
    }
}
