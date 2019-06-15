using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace customerdata.lib
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<IEnumerable<Customer>> Search(string query);

    }
}
