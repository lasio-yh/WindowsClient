using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class ResponseDeleteVoteModel
    {
        public string RESULT { get; set; }
        public List<ResponseDeleteVoteDetailModel> DATA { get; set; }
    }

    public class ResponseDeleteVoteDetailModel
    {
        public string VOTEKEY { get; set; }
        public string SUBKEY { get; set; }
    }
}
