using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.MiddleWare
{
    public class RequestRenderDisplayModel : RequestRenderModel
    {
        public int action { get; set; }
        public string content { get; set; }
    }
}
