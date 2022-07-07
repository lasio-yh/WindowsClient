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
        CRAW = 0x04,
        TICKER = 0x08,
        TEXTURE = 0xAF
    }

    /// <summary>
    /// Enum Value
    /// </summary>
    /// <param name="ITEM1">parameter by default of 0x01</param>
    /// <param name="ITEM2">parameter by default of 0x02</param>
    [Flags]
    public enum NOTIFYCODE 
    {
        SUCCESSFILEOPEN = 0x01,
        SUCCESSFILECLEAR = 0x02, 
        UNDOSLIDE = 0x03,
        REDOSLIDE = 0x04,
        CHANGEDPLAYTYPE = 0x05,
        APPLYDISPLAY = 0x06,
        CONNECTSERVER = 0x07,
        DISCONNECTSERVER = 0x08,
        SENDSERVER = 0x09,
        RESLOGIN = 0x0A,
        RESMESSAGESETTING = 0x0B,
        RESMESSAGEDATA = 0x0C,
        RESVOTELIST= 0x0D,
        RESVOTEEDIT = 0x0E,
        RESVOTEDELETE = 0x0F,
        RESVOTESTATUS = 0x10,
        RESVOTERESULT = 0x11,
        RESVOTESTART = 0x12,
        RESVOTESTOP = 0x13
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
