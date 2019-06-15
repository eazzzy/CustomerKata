using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer.api.Models
{
    public class AppSettings
    {
        public Swashbuckle swashbuckle { get; set; }
        public string datafile { get; set; }
    }

    public class Swashbuckle
    {
        public string endpointUrl { get; set; }
        public string endpointName { get; set; }
        public string title { get; set; }
        public string version { get; set; }
        public string description { get; set; }
        public string host { get; set; }
    }
}
