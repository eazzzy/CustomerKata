using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace customerdata.lib
{
    public interface ICustomerReadDataStore
    {
        Task<IEnumerable<Customer>> SelectAll();
        Task<IEnumerable<Customer>> Search(string query);
    }
}
