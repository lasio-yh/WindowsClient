using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class ResponseStopVoteModel
    {
        public string RESULT { get; set; }
        public List<ResponseStopVoteDetailModel> DATA { get; set; }
    }

    public class ResponseStopVoteDetailModel
    {
        public string VOTEKEY { get; set; }
        public string SUBKEY { get; set; }
        public string STATUS { get; set; }
    }
}
