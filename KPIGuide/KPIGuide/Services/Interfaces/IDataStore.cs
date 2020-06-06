using System.Collections.Generic;
using System.Threading.Tasks;

namespace KPIGuide.Services.Interfaces
{
    public interface IDataStore<T>
    {
        bool AddItem(T item);
        bool UpdateItem(T item);
        bool DeleteItem(string id);
        T GetItem(string id);
        IEnumerable<T> GetItems(bool forceRefresh = false);
    }
}
