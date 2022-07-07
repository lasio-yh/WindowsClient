using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class ResponseListVoteModel
    {
        public string RESULT { get; set; }
        public List<ResponseListVoteDetailModel> DATA { get; set; }
    }

    public class ResponseListVoteDetailModel
    {
        public string VOTEKEY { get; set; }
        public string STATUS { get; set; }
        public string COUNT { get; set; }
        public List<ResponseListVoteSubDetailModel> SUB { get; set; }
    }

    public class ResponseListVoteSubDetailModel
    {
        public string MEDIA { get; set; }
        public string VALUES { get; set; }
    }
}
