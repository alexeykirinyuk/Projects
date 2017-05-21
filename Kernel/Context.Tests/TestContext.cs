using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projects.Context;
using System;
using System.Collections.Generic;

namespace Kernel.Tests
{
    [TestClass]
    public class TestContext 
    {
        [TestMethod]
        public void Context()
        {
            using (var context = new ProjectsEntities())
            {
                var worker = new Worker()
                {
                    FirstName = "alex",
                    LastName = "rob",
                    Email = "alex@rob",
                    MiddleName = "middle"
                };

                worker = context.WorkersBase.Add(worker);
                Assert.IsNotNull(worker);

                var worker1 = new Worker()
                {
                    FirstName = "alex1",
                    LastName = "rob1",
                    Email = "alex@rob1",
                    MiddleName = "middle1"
                };

                worker1 = context.WorkersBase.Add(worker1);
                Assert.IsNotNull(worker1);

                context.SaveChanges();

                Assert.IsNotNull(context.WorkersBase.Find(worker.Id));
                Assert.IsNotNull(context.WorkersBase.Find(worker1.Id));

                var project = new Project()
                {
                    Comment = "Comment",
                    ConstractorCompany = "Cons",
                    CustomerCompany = "cust",
                    Employee = worker,
                    Leader = worker1,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Workers = new List<Worker>
                    {
                        worker,
                        worker1
                    }
                };

                project = context.ProjectsBase.Add(project);
                Assert.IsNotNull(project);

                context.SaveChanges();
                Assert.IsNotNull(context.ProjectsBase.Find(project.Id));
            }
        }
    }
}
