using Projects.Context;
using System;
using System.Collections.Generic;

namespace Projects.Managers
{
    public abstract class BaseManager<TDataType> : IManager<TDataType>
    {
        protected abstract string Tag { get; }

        public abstract TDataType Add(TDataType element);
        public abstract TDataType Find(long id);
        public abstract IEnumerable<TDataType> GetAll();

        public abstract TDataType Remove(long id);
        public abstract TDataType Update(TDataType element);

        protected TResult WOperation<TResult>(Func<ProjectsEntities, TResult> action)
        {
            var result = default(TResult);

            using (var context = new ProjectsEntities())
            {
                try
                {
                    result = action(context);
                    context.SaveChanges();
                }
                catch (Exception exception)
                {
                    ManagerFactory.Logger.Error(Tag, exception);
                }
            }

            return result;
        }
    }
}
