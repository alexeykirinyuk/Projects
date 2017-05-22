using Projects.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projects.Managers
{
    public class ProjectsManager : IManager<Project>
    {
        public ProjectsManager() { }

        public IEnumerable<Project> GetAll() => OperationGet((projects) => projects.ToList());
        public Project Find(long id)
        {
            return OperationGet(projects =>
            {
                return projects.FirstOrDefault(p => id == p.Id);
            });
        }

        public Project Add(Project project) => OperationSet(context => context.ProjectsBase.Add(project));
        public Project Update(Project project)
        {
            return OperationSet(context =>
            {
                var entity = context.ProjectsBase.Find(project.Id);
                entity.Update(project);

                entity.Employee = context.WorkersBase.Find(project.EmployeeId);
                entity.Leader = context.WorkersBase.Find(project.LeaderId);
                entity.Workers.Clear();

                foreach (var id in project.WorkerIds)
                {
                    entity.Workers.Add(context.WorkersBase.Find(id));
                }

                return entity;
            });
        }
        public Project Remove(long id)
        {
            return OperationSet(context =>
            {
                var element = context.ProjectsBase.Find(id);

                element.Employee = null;
                element.Leader = null;
                element.Workers.Clear();

                context.SaveChanges();

                return context.ProjectsBase.Remove(element);
            });
        }

        private TDataType OperationGet<TDataType>(Func<IEnumerable<Project>, TDataType> action)
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
        private TDataType OperationSet<TDataType>(Func<ProjectsEntities, TDataType> action)
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
