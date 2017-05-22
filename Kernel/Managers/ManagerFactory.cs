using Projects.Context;
using Projects.Managers.Logging;

namespace Projects.Managers
{
    public static class ManagerFactory
    {
        public static bool Debug = false;
        public static Log Logger { get; } = new Log();

        public static IManager<TDataType> Get<TDataType>()
        {
            var type = typeof(TDataType);

            if (type == typeof(Project))
            {
                return new ProjectsManager() as IManager<TDataType>;
            }
            else if (type == typeof(Worker))
            {
                return new WorkersManager() as IManager<TDataType>;
            }
            else
            {
                return null;
            }
        }
    }
}
