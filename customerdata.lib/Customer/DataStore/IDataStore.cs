using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace customerdata.lib
{
    public interface IDataStore
    {
        Task<IEnumerable<CustomerDto>> Select();
    }
}
