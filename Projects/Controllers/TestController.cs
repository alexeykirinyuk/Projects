using Projects.Context;
using System;
using System.Collections.Generic;

namespace Projects.Server.Controllers
{
    public class TestController : BaseController
    {
        public string Index()
        {
            var worker1 = new Worker("Alexey", "Kirinyuk", "Dmitrievich", "alexey.kirinyuk@gmail.com");
            var worker2 = new Worker("Kristina", "Koreneva", "Gaiist", "kristina.gaiist@yandex.ru");

            var project1 = new Project("sibers/projects", "sibers", "kirinyuk")
            {
                Comment = "test work",
                Employee = worker1,
                Leader = worker2,
                Priority = 10,
                Start = DateTime.Now,
                End = DateTime.Now,
                Workers = new List<Worker>() { worker1, worker2 }
            };
            var project2 = new Project("project two", "4peoplesoft", "sibers")
            {
                Comment = "test",
                Employee = worker1,
                Leader = worker2,
                Priority = 10,
                Start = DateTime.Now,
                End = DateTime.Now,
                Workers = new List<Worker>() { worker1, worker2 }
            };

            _workers.Add(worker1);
            _workers.Add(worker2);
            _projects.Add(project1);
            _projects.Add(project2);

            return "Success";
        }
    }
}