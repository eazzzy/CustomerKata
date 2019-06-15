using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace customerdata.lib
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerReadDataStore _customerReadStore;

        public CustomerService(ICustomerReadDataStore customerReadStore)
        {
            _customerReadStore = customerReadStore;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                var records = await _customerReadStore.SelectAll();
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> Search(string query)
        {
            try
            {
                var records = await _customerReadStore.Search(query);
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
