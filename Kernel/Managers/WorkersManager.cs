using Projects.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projects.Managers
{
    public class WorkersManager : IManager<Worker>
    {
        public WorkersManager() { }

        public IEnumerable<Worker> GetAll() => Operation(context => context.WorkersBase.ToList());
        public Worker Find(long id) => Operation(context => context.WorkersBase.FirstOrDefault(w => id == w.Id));

        public Worker Add(Worker worker) => Operation(context => context.WorkersBase.Add(worker));
        public Worker Update(Worker worker)
        {
            return Operation(context =>
            {
                var entity = context.WorkersBase.Find(worker.Id);

                return entity.Update(worker);
            });
        }
        public Worker Remove(long id)
        {
            return Operation(context =>
            {
                var remove = context.WorkersBase.FirstOrDefault(w => id == w.Id);

                var projects = context.ProjectsBase.Where(p => id == p.LeaderId);
                foreach (var leader in projects)
                {
                    leader.Leader = null;
                }

                projects = context.ProjectsBase.Where(p => id == p.EmployeeId);
                foreach (var employee in projects)
                {
                    employee.Employee = null;
                }

                foreach (var project in context.ProjectsBase)
                {
                    var worker = project.Workers.FirstOrDefault(w => id == w.Id);

                    if (null != worker)
                    {
                        project.Workers.Remove(worker);
                    }
                }

                return context.WorkersBase.Remove(remove);
            });
        }

        private TDataType Operation<TDataType>(Func<ProjectsEntities, TDataType> action)
        {
            var result = default(TDataType);

            using (var context = new ProjectsEntities())
            {
                result = action(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
