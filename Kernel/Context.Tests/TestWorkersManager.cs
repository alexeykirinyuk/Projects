using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projects.Context;
using Projects.Managers;
using System.Linq;

namespace Kernel.Tests
{
    [TestClass]
    public class TestWorkersManager : BaseTest
    {
        [TestMethod]
        public void GetAll()
        {
            var all = WorkersManager.GetAll();
            Assert.IsNotNull(all);
            Assert.AreEqual(2, all.Count());
        }

        [TestMethod]
        public void Find()
        {
            var finded = WorkersManager.Find(100);
            Assert.IsNull(finded);

            finded = WorkersManager.Find(Worker1.Id);
            Assert.IsNotNull(finded);
        }

        [TestMethod]
        public void Add()
        {
            var worker = new Worker("ln3", "fn3", "md3", "em3");

            var added = WorkersManager.Add(worker);
            Assert.IsNotNull(added);

            added = WorkersManager.Find(added.Id);
            Assert.IsNotNull(added);

            Assert.AreEqual(added.FirstName, worker.FirstName);
            Assert.AreEqual(added.LastName, worker.LastName);
            Assert.AreEqual(added.MiddleName, worker.MiddleName);
            Assert.AreEqual(added.Email, worker.Email);
        }

        [TestMethod]
        public void Remove()
        {
            var worker = WorkersManager.Remove(Worker1.Id);
            Assert.IsNotNull(worker);

            worker = WorkersManager.Find(Worker1.Id);
            Assert.IsNull(worker);
        }
    }
}
