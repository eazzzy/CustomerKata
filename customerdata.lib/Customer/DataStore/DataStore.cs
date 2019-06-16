using customerdata.lib.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace customerdata.lib
{
    public class DataStore : IDataStore
    {
        private string _dataFileName { get; set; }

        public DataStore(string dataFileName)
        {
            _dataFileName = !string.IsNullOrWhiteSpace(dataFileName) ? dataFileName : throw new ArgumentNullException("Missing required field not specified");
        }
        public async Task<IEnumerable<CustomerDto>> Select()
        {
            try
            {
                string[] csvlines = await File.ReadAllLinesAsync(_dataFileName);

                var customers = from csvline in csvlines
                                let data = Regex.Split(csvline, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")
                                select new CustomerDto
                                {
                                    first_name = data?[0],
                                    last_name = data?[1],
                                    company_name = data?[2].RemoveSpecialCharacters(),
                                    address = data?[3],
                                    city = data?[4],
                                    state = data?[5],
                                    post = data?[6],
                                    phone1 = data?[7],
                                    phone2 = data?[8],
                                    email = data?[9],
                                    web = data?[10]
                                };
                return customers.Skip(1);
            }
            catch (FileNotFoundException fnf)
            {
                throw new FileNotFoundException($"File {_dataFileName} could not be found", fnf);
            }
        }
    }
}
