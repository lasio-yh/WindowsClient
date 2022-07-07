﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Models.Server
{
    public class RequestListVoteModel
    {
        public string UID { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string CHN { get; set; }
        public string PGM { get; set; }
        public string COUNT { get; set; }
        public RequestLIstVoteDetailModel DATA { get; set; }
    }

    public class RequestLIstVoteDetailModel
    {
        public string COUNT { get; set; }
        public string STATUS { get; set; }
    }
}
