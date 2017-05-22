using Projects.Context;

namespace Projects.Managers
{
    public static class ManagerFactory
    {
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
