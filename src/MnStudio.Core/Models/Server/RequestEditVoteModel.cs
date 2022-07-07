using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class RequestEditVoteModel
    {
        public string UID { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string CHN { get; set; }
        public string PGM { get; set; }
        public string COUNT { get; set; }
        public RequestEditVoteDetailModel DATA { get; set; }
    }

    public class RequestEditVoteDetailModel
    {
        public string VOTEKEY { get; set; }
        public string SUBKEY { get; set; }
        public string START { get; set; }
        public string END { get; set; }
        public string COUNT { get; set; }
        public string TITLE { get; set; }
        public string ITEMS { get; set; }
        public string KWRD { get; set; }
        public string DESC { get; set; }
        public string IMAGE { get; set; }
        public string DEFAULT { get; set; }
        public string VOTEDATA { get; set; }
        public string UDUP { get; set; }
        public string KDUP { get; set; }
        public string ETC { get; set; }
        public string ADBACK { get; set; }
        public string RESTART { get; set; }
        public string MCOUNT { get; set; }
        public string MEDIA { get; set; }
    }
}
