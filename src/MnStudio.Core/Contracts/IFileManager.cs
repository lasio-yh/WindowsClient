using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MnStudio.Core.Models.File;

namespace MnStudio.Core.Contracts
{
    public interface IFIleManager
    {
        Document OnOpenFile(string path, string encoding);
        void OnSaveFile();
        void OnApplyFile();
    }
}