using Projects.Context;
using Projects.DataTypes;
using System.Collections.Generic;

namespace Projects.Managers
{
    public class ProjectsManager
    {
        public IEnumerable<Project> GetAll()
        {
            var result = default(IEnumerable<Project>);

            using (var context = new CurrentContext())
            {
                result = context.ProjectsBase as IEnumerable<Project>;
            }

            return result;
        }

        public Project Find(long id)
        {
            var result = default(Project);

            using (var context = new CurrentContext())
            {
                result = context.ProjectsBase.Find(id);
            }

            return result;
        }
    }
}
