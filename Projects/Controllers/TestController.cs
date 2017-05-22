using Projects.Context;
using System;
using System.Collections.Generic;

namespace Projects.Server.Controllers
{
    public class TestController : BaseController
    {
        public string Index()
        {
            Drop();
            Fill();

            return "Success";
        }
        private void Drop()
        {
            using (var context = new ProjectsEntities())
            {
                context.Database.ExecuteSqlCommand("truncate table ProjectsWorkersBase");
                context.ProjectsBase.RemoveRange(context.ProjectsBase);
                context.WorkersBase.RemoveRange(context.WorkersBase);

                context.SaveChanges();
            }
        }
        private void Fill()
        {
            var worker1 = new Worker("Alexey", "Kirinyuk", "Dmitrievich", "alexey.kirinyuk@gmail.com");
            var worker2 = new Worker("Kristina", "Koreneva", "Gaiist", "kristina.gaiist@yandex.ru");
            var worker3 = new Worker("Yakov", "Vins", "Eduardovich", "yakov-vins@gmail.com");
            var worker4 = new Worker("Gulzan", "Mucusheva", "Privet", "gix@yandex.ru");

            worker1 = _workers.Add(worker1);
            worker2 =_workers.Add(worker2);
            worker3 = _workers.Add(worker3);
            worker4 = _workers.Add(worker4);

            var project1 = new Project("sibers/projects", "sibers", "kirinyuk")
            {
                Comment = "test work",
                Employee = worker1,
                Leader = worker2,
                Priority = 10,
                Start = DateTime.Now,
                End = DateTime.Now,
                Workers = new List<Worker>() { worker1, worker4 }
            };
            var project2 = new Project("project two", "4peoplesoft", "sibers")
            {
                Comment = "test",
                Employee = worker3,
                Leader = worker4,
                Priority = 10,
                Start = DateTime.Now,
                End = DateTime.Now,
                Workers = new List<Worker>() { worker1, worker3 }
            };

            _projects.Add(project1);
            _projects.Add(project2);
        }
    }
}