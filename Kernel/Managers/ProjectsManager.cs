using Projects.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projects.Managers
{
    public class ProjectsManager
    {
        public ProjectsManager() { }

        public IEnumerable<Project> GetAll() => Operation((projects) => projects.ToList());
        public Project Find(long id)
        {
            return Operation(projects =>
            {
                return projects.FirstOrDefault(p => id == p.Id);
            });
        }

        public Project Add(Project project) => Operation(projects => projects.Add(project));

        private TDataType Operation<TDataType>(Func<IEnumerable<Project>, TDataType> action)
        {
            var result = default(TDataType);

            using (var context = new ProjectsEntities())
            {
                var projects = context.ProjectsBase
                    .Include(p => p.Employee)
                    .Include(p => p.Leader)
                    .Include(p => p.Workers);

                result = action(projects);
            }

            return result;
        }
        private TDataType Operation<TDataType>(Func<DbSet<Project>, TDataType> action)
        {
            var result = default(TDataType);

            using (var context = new ProjectsEntities())
            {
                result = action(context.ProjectsBase);
                context.SaveChanges();
            }

            return result;
        }
    }
}
