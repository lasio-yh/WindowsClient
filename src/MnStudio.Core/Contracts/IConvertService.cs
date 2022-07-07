using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Contracts
{
    public interface IConvertService
    {
        byte[] StructureToByte(object obj);
        object ByteToStructure(byte[] data, Type type);
    }
}