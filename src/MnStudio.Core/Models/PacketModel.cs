using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace MnStudio.Core.Models
{
    /// <summary>
    /// CharSet Ansi
    /// sizeconst 255
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]
    public struct PacketModel
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string Content;
        public PacketModel(string data)
        {
            this.Content = data;
        }
    }
}
