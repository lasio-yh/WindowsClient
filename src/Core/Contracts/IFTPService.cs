using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IFTPService
    {
        string Host { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }
}
