﻿using Projects.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projects.Managers
{
    public class ProjectsManager : BaseManager<Project>
    {
        protected override string Tag => "ProjectsManager";

        public ProjectsManager() { }

        public override IEnumerable<Project> GetAll() => WOperationGet((projects) => projects.ToList());
        public override Project Find(long id) => WOperationGet(projects => projects.FirstOrDefault(p => id == p.Id));

        public override Project Add(Project project)
        {
            var result = WOperation(context =>
            {
                project.Employee = context.WorkersBase.Find(project.EmployeeId);
                project.Leader = context.WorkersBase.Find(project.LeaderId);

                var ids = project.Workers.Select(w => w.Id);
                project.ClearWorkers();

                foreach (var id in ids)
                {
                    var worker = context.WorkersBase.Find(id);

                    if (null != worker)
                    {
                        project.AddWorkers(worker);
                    }
                }

                return context.ProjectsBase.Add(project);
            });

            ManagerFactory.Logger.Info(Tag, $"Add new project #{result.Id}");

            return result;
        }
        public override Project Update(Project project)
        {
            var result = WOperation(context =>
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

            ManagerFactory.Logger.Info(Tag, $"Update project #{result.Id}");

            return result;
        }
        public override Project Remove(long id)
        {
            var result = WOperation(context =>
            {
                var element = context.ProjectsBase.Find(id);

                element.Employee = null;
                element.Leader = null;
                element.Workers.Clear();

                context.SaveChanges();

                return context.ProjectsBase.Remove(element);
            });

            ManagerFactory.Logger.Info(Tag, $"Remove project #{id}");

            return result;
        }

        private TDataType WOperationGet<TDataType>(Func<IEnumerable<Project>, TDataType> action)
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
    }
}
