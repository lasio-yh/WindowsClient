using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.MiddleWare
{
    public class RequestRenderInitModel : RequestRenderModel
    {
        public string filename { get; set; }
        public string filepath { get; set; }
        public int fileindex { get; set; }
        public int displaymode { get; set; }
    }
}
