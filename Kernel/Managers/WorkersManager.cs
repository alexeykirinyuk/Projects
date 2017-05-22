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

        public IEnumerable<Worker> GetAll() => Operation(workers => workers.ToList());
        public Worker Find(long id) => Operation(workers => workers.FirstOrDefault(w => id == w.Id));

        public Worker Add(Worker worker) => Operation(workers => workers.Add(worker));
        public Worker Update(Worker worker)
        {
            return Operation(workers =>
            {
                var entity = workers.Find(worker.Id);

                return entity.Update(worker);
            });
        }
        public Worker Remove(long id)
        {
            return Operation(workers =>
            {
                return workers.Remove(workers.FirstOrDefault(w => id == w.Id));
            }
            );
        }

        private TDataType Operation<TDataType>(Func<DbSet<Worker>, TDataType> action)
        {
            var result = default(TDataType);

            using (var context = new ProjectsEntities())
            {
                result = action(context.WorkersBase);
                context.SaveChanges();
            }

            return result;
        }
    }
}
