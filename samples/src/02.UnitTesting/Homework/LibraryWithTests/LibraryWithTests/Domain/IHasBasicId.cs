using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithTests.Domain
{
    public interface IHasBasicId
    {
        int Id { get; set; }
    }
}
