using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class ResponseResultVoteModel
    {
        public string RESULT { get; set; }
        public List<ResponseResultVoteDetailModel> DATA { get; set; }
    }

    public class ResponseResultVoteDetailModel
    {
        public string VOTEKEY { get; set; }
        public string STATUS { get; set; }
        public string COUNT { get; set; }
        public List<ResponseResultVoteSubDetailModel> SUB { get; set; }
    }

    public class ResponseResultVoteSubDetailModel
    {
        public string MEDIA { get; set; }
        public string VALUES { get; set; }
    }
}
