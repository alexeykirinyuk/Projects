using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projects.Context;
using System.Collections.Generic;
using System.Linq;

namespace Kernel.Tests
{
    [TestClass]
    public class TestProjectsManager : BaseTest
    {
        [TestMethod]
        public void GetAll()
        {
            var all = ProjectsManager.GetAll();
            Assert.IsNotNull(all);
            Assert.AreEqual(2, all.Count());
        }

        [TestMethod]
        public void Find()
        {
            var project = ProjectsManager.Find(100);
            Assert.IsNull(project);

            project = ProjectsManager.Find(Project1.Id);

            Assert.IsNotNull(project);
            Assert.IsNotNull(project.Employee);
            Assert.IsNotNull(project.Leader);
            Assert.IsNotNull(project.Workers);
        }

        [TestMethod]
        public void Add()
        {
            var project = new Project("n3", "c3", "c3")
            {
                Workers = new List<Worker>() { Worker1, Worker2 }
            };

            var added = ProjectsManager.Add(project);
            Assert.IsNotNull(added);

            added = ProjectsManager.Find(added.Id);
            Assert.IsNotNull(added);

            Assert.AreEqual(added.Name, project.Name);
            Assert.AreEqual(added.CustomerCompany, project.CustomerCompany);
            Assert.AreEqual(added.ConstractorCompany, project.ConstractorCompany);
            Assert.AreEqual(added.Workers.Count(), project.Workers.Count());
        }
        [TestMethod]
        public void Update()
        {
            var worker = new Worker("ln3", "fn3", "md3", "em3");
            worker = WorkersManager.Add(worker);

            Project1.Name = "name2";
            Project1.EmployeeId = worker.Id;
            Project1.LeaderId = worker.Id;

            Project1.WorkerIds = Project1.Workers.Select(p => p.Id).ToList();
            Project1.WorkerIds.Add(worker.Id);

            ProjectsManager.Update(Project1);

            Assert.AreEqual(2, ProjectsManager.GetAll().Count());

            var element = ProjectsManager.Find(Project1.Id);
            Assert.AreEqual(Project1.Name, element.Name);
            Assert.AreEqual(Project1.EmployeeId, element.EmployeeId);
            Assert.AreEqual(Project1.LeaderId, element.LeaderId);
            Assert.AreEqual(Project1.WorkerIds.Count(), element.Workers.Count());

            Project1.WorkerIds.RemoveAt(0);
            ProjectsManager.Update(Project1);
            element = ProjectsManager.Find(Project1.Id);

            Assert.AreEqual(Project1.WorkerIds.Count(), element.Workers.Count());
        }
        [TestMethod]
        public void Remove()
        {
            var project = ProjectsManager.Remove(Project1.Id);
            Assert.IsNotNull(project);

            project = ProjectsManager.Find(Project1.Id);
            Assert.IsNull(project);
        }
    }
}
