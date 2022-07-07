using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.MiddleWare
{
    public class RequestRenderCrawModel : RequestRenderDisplayModel
    {
        public int speed { get; set; }
        public int margin { get; set; }
        public int width { get; set; }
        public int isshow { get; set; }
    }
}
