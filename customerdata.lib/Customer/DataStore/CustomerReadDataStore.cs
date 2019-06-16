using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace customerdata.lib
{
    public class CustomerReadDataStore : ICustomerReadDataStore
    {
        public string DataStoreFileName { get; set; }
        public CustomerReadDataStore(string dataStoreFileName)
        {
            DataStoreFileName = dataStoreFileName;
        }

        public async Task<IEnumerable<Customer>> SelectAll()
        {
            var items = await new DataStore(DataStoreFileName).Select();

            return items?.Select(cust => (Customer)cust);
        }

        public async Task<IEnumerable<Customer>> Search(string query)
        {
            var items = await SelectAll();
            
            return items?.Where(i => i.FirstName.Contains(query)
             || i.LastName.Contains(query)
             || i.Email.Contains(query)
             || i.Phone1.Contains(query));
        }
    }
}
