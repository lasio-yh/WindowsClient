using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class RequestStatusVoteModel
    {
        public string UID { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string CHN { get; set; }
        public string PGM { get; set; }
        public string COUNT { get; set; }
        public List<RequestStatusVoteDetailModel> DATA { get; set; }
    }

    public class RequestStatusVoteDetailModel
    {
        public string VOTEKEY { get; set; }
    }
}
