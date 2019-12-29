using LibraryWithTests.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithTests.Services
{
    public class UserBookStorage : IStore<UserBook>
    {
        public void Add(UserBook item)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserBook item)
        {
            throw new NotImplementedException();
        }

        public List<UserBook> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
