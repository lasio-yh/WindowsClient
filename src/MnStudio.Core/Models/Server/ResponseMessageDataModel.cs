using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class ResponseMessageDataModel
    {
        public string RESULT { get; set; }
        public List<ResponseMessageDataDetailModel> DATA { get; set; }
    }

    public class ResponseMessageDataDetailModel
    {
        public string SEQ { get; set; }
        public string TO { get; set; }
        public string FROM { get; set; }
        public string USERID { get; set; }
        public string TIME { get; set; }
        public string TEXT { get; set; }
        public string ATTPATH { get; set; }
        public string MEDIA { get; set; }
        public string MHIDDEN { get; set; }
        public string NICK { get; set; }
        public string FEEDID { get; set; }
        public string COMMID { get; set; }
        public string UHIDDEN { get; set; }
        public string USERGRADE { get; set; }
        public string USERPIC { get; set; }
    }
}
