using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer.api.Models
{
    public class AppSettings
    {
        public Swashbuckle Swashbuckle { get; set; }
        public string Datafile { get; set; }
    }

    public class Swashbuckle
    {
        public string EndpointUrl { get; set; }
        public string EndpointName { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }
}
