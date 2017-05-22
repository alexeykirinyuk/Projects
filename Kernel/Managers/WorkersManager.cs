using Projects.Context;
using System.Collections.Generic;
using System.Linq;

namespace Projects.Managers
{
    public class WorkersManager : BaseManager<Worker>
    {
        protected override string Tag => "WorkersManager";

        public WorkersManager() { }

        public override IEnumerable<Worker> GetAll() => WOperation(context => context.WorkersBase.ToList());
        public override Worker Find(long id) => WOperation(context => context.WorkersBase.FirstOrDefault(w => id == w.Id));

        public override Worker Add(Worker worker)
        {
            var result = WOperation<Worker>(context => context.WorkersBase.Add(worker));

            ManagerFactory.Logger.Info(Tag, $"Add new worker #{result.Id}");

            return result;
        }
        public override Worker Update(Worker worker)
        {
            var result = WOperation<Worker>(context =>
            {
                var entity = context.WorkersBase.Find(worker.Id);

                return entity.Update(worker);
            });

            ManagerFactory.Logger.Info(Tag, $"Update worker #{worker.Id}");

            return result;
        }
        public override Worker Remove(long id)
        {
            var result = WOperation<Worker>(context =>
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

            ManagerFactory.Logger.Info(Tag, $"Remove worker #{id}");

            return result;
        }
    }
}
