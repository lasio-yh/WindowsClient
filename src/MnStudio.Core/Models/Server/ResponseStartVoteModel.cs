using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class ResponseStartVoteModel
    {
        public string RESULT { get; set; }
        public List<ResponseStartVoteDetailModel> DATA { get; set; }
    }

    public class ResponseStartVoteDetailModel
    {
        public string VOTEKEY { get; set; }
        public string SUBKEY { get; set; }
        public string STATUS { get; set; }
        public string TITLE { get; set; }
    }
}
