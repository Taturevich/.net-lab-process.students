using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithTests.Domain
{
    public class UserBook
    {
        public int BookId { get; set; }

        public int UserId { get; set; }

        public DateTime RentDateStart { get; set; }

        public DateTime RentDateEnd { get; set; }
    }
}
