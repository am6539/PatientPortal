using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.SearchEngine
{
    public class ElasticConfig
    {
        /// URI 
        private string ES_URI = ConfigurationManager.AppSettings["elastic:search"].ToString();

        /// Elastic settings
        private ConnectionSettings _settings;

        /// Current instantiated client
        public ElasticClient Current { get; set; }
    }
}
