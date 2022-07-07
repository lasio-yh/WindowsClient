using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class ResponseLoginModel
    {
        public string RESULT { get; set; }
        public string COUNT { get; set; }
        public List<ResponseLoginDetailModel> DATA { get; set; }
    }

    public class ResponseLoginDetailModel
    {
        public string GRP { get; set; }
        public string CHN { get; set; }
        public string PGM { get; set; }
        public string NAME { get; set; }
        public string SMEDIA { get; set; }
        public string UMEDIA { get; set; }
        public string MEDIACD { get; set; }
        public string MEDIANM { get; set; }
        public string TIME { get; set; }
        public string UNAME { get; set; }
        public string PW { get; set; }
    }
}
