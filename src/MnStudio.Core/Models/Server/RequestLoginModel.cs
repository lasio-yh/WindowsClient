using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class RequestLoginModel
    {
        public string UID { get; set; }
        public string PW { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string COUNT { get; set; }
    }
}
