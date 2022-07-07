using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MnStudio.Core.Services;
using MnStudio.Core.Models;
using MnStudio.Core.Models.MiddleWare;
using System.Web.Script.Serialization;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;
using System.Net;

namespace MnStudio.Constants
{
    public class MiddleWareController
    {
        public static SocketService Core { get; set; }
        public static bool Status { get; set; }
       
        public static void Send<T>(T content)
        {
            try
            {
                //var uri = App.Current.Properties["MiddleWareUri"].ToString();
                //var convert = new ConvertService();
                //var jss = new JavaScriptSerializer();
                //var stream = jss.Serialize(content);
                //var client = new HttpService();
                //var result = client.PostRequest(uri, stream, string.Empty);
                //result.ContinueWith(item =>
                //{
                //    if(item.IsCompleted && item.Result.StatusCode.Equals(HttpStatusCode.OK))
                //        NotifyPush.Notify(NOTIFYCODE.APPLYDISPLAY, null);
                //});
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }
    }
}