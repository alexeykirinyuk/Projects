using System.Collections.Generic;

namespace Projects.Managers
{
    public interface IManager<TDataType>
    {
        IEnumerable<TDataType> GetAll();
        TDataType Find(long id);

        TDataType Add(TDataType element);
        TDataType Update(TDataType element);
        TDataType Remove(long id);
    }
}
