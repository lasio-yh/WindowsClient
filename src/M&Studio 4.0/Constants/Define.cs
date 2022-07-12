using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Constants
{
    /// <summary>
    /// Enum Value
    /// </summary>
    /// <param name="CHECKED">parameter by default of 0x01</param>
    /// <param name="UNCHECKED">parameter by default of 0x02</param>
    [Flags]
    public enum CONFIGCODE 
    {
        UNCHECKED = 0x00, 
        CHECKED = 0x01 
    }

    /// <summary>
    /// Enum Value
    /// </summary>
    /// <param name="CHECKED">parameter by default of 0x01</param>
    /// <param name="UNCHECKED">parameter by default of 0x02</param>
    [Flags]
    public enum EDITORCODE
    {
        ADD = 0x00,
        EDIT = 0x01
    }

    /// <summary>
    /// DRAWRULES Value
    /// </summary>
    /// <param name="Animation">parameter by default of 0x01</param>
    /// <param name="Bitmap">parameter by default of 0x02</param>
    /// <param name="Craw">parameter by default of 0x03</param>
    /// <param name="Grow">parameter by default of 0x04</param>
    /// <param name="Count">parameter by default of 0x05</param>
    /// <param name="Pie">parameter by default of 0x06</param>
    /// <param name="Sprite">parameter by default of 0x07</param>
    /// <param name="Text">parameter by default of 0x08</param>
    /// <param name="Ticker">parameter by default of 0x09</param>
    /// <param name="Typewirte">parameter by default of 0x10</param>
    [Flags]
    public enum DRAWRULES 
    { 
        NONE = 0x00, 
        CUT = 0x01,
        TYPEWRITE = 0x02, 
        CRAW = 0x03,
        TICKER = 0x04,
        TEXTURE = 0x05
    }

    /// <summary>
    /// Enum Value
    /// </summary>
    /// <param name="CHECKED">parameter by default of 0x01</param>
    /// <param name="UNCHECKED">parameter by default of 0x02</param>
    [Flags]
    public enum PACKETCOMMAND
    {
        MESSAGESETTING = 215,
        MESSAGEDATA = 2011
    }

    /// <summary>
    /// Enum Value
    /// </summary>
    /// <param name="ITEM1">parameter by default of 0x01</param>
    [Flags]
    public enum NOTIFYCODE 
    {
        SUCCESSFILEOPEN = 0x01,
        SUCCESSFILECLEAR = 0x02, 
        UNDOSLIDE = 0x03,
        REDOSLIDE = 0x04,
        APPLYSTANBY = 0x05,
        CONNECTSERVER = 0x06,
        DISCONNECTSERVER = 0x07,
        RECEIVESTART = 0x08,
        RECEIVESTOP = 0x09,
        SENDSERVER = 0x0A,
        RESINIT = 0x0B,
        RESDISPOSE = 0x0C,
        RESDISPLAY = 0x0D,
        RESRENDER = 0x0E,
        RESCLEAR = 0x0F,
        RESLOGIN = 0x10,
        RESMESSAGESETTING = 0x11,
        RESMESSAGEDATA = 0x12,
        RESVOTELIST= 0x13,
        RESVOTEEDIT = 0x14,
        RESVOTEDELETE = 0x15,
        RESVOTESTATUS = 0x16,
        RESVOTERESULT = 0x17,
        RESVOTESTART = 0x18,
        RESVOTESTOP = 0x19
    }

    /// <summary>
    /// Enum Value
    /// </summary>
    /// <param name="CHECKED">parameter by default of 0x01</param>
    /// <param name="UNCHECKED">parameter by default of 0x02</param>
    [Flags]
    public enum LOGCADEGORI
    {
        [Description("SYSTEM")]
        SYSTEM = 0x01,
        [Description("APPLICATION")]
        APPLICATION = 0x02,
        [Description("COMMUNICATION")]
        COMMUNICATION = 0x03,
        [Description("ACTION")]
        ACTION = 0x04
    }

    /// <summary>
    /// Enum Value
    /// </summary>
    /// <param name="CHECKED">parameter by default of 0x01</param>
    /// <param name="UNCHECKED">parameter by default of 0x02</param>
    [Flags]
    public enum LOGLEVEL
    {
        DEBUG = 0x00,
        INFO = 0x01,
        ERROR = 0x02,
        WARN = 0x03,
        FATAL = 0x04
    }

}
