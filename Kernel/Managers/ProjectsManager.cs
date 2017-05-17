using Projects.Context;
using Projects.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projects.Managers
{
    public class ProjectsManager
    {
        public readonly string[] Includes = new string[] { "Employee", "Leader" };

        public IEnumerable<Project> GetAll() => Operation((projects) => projects.ToList());
        public Project Find(long id) => Operation((projects) => projects.FirstOrDefault(p => id == p.Id));

        private TDataType Operation<TDataType>(Func<IEnumerable<Project>, TDataType> action)
        {
            var result = default(TDataType);

            using (var context = new CurrentContext())
            {
                result = action(context.ProjectsBase.Include("Employee").Include("Leader"));
            }

            return result;
        }
    }
}
