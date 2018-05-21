using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICustumRepository<T>
    {
        IEnumerable<T> GetAllItems();

        T GetFirstOrDefault(Func<T, bool> predicate);

        IEnumerable<T> Get(Func<T, bool> predicate);

        T GetItemById(int itemId);
        void CreateItem(T item);
        void UpdateItem(T item);
        void DeleteItem(T item);
    }
}
