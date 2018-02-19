using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data.Helpers
{
    public interface RaceDataStore<T>
    {
        Task<bool> InsertData(T item);
        Task<bool> DeleteData(string PK);
        Task<bool> UpdateData(string PK, T item);
        Task<T> GetItem(string PK);
        Task<IEnumerable<T>> GetItems();
    }
}
