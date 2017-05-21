using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projects.Context;
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
            var project = new Project("n3", "c3", "c3");

            var added = ProjectsManager.Add(project);
            Assert.IsNotNull(added);

            added = ProjectsManager.Find(added.Id);
            Assert.IsNotNull(added);

            Assert.AreEqual(added.Name, project.Name);
            Assert.AreEqual(added.CustomerCompany, project.CustomerCompany);
            Assert.AreEqual(added.ConstractorCompany, project.ConstractorCompany);
        }
    }
}
