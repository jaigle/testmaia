using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business
{
    public class ServiciosBase
    {
        public bool Offline
        {
            get
            {
                var offline = ConfigurationManager.AppSettings["offline"];
                return !string.IsNullOrEmpty(offline) && offline == "true";
            }
        }
    }
}
