using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithTests.Services
{
    public interface IStore<T>
    {
        void Add(T item);

        List<T> GetAll();

        void Delete(T item);
    }
}
