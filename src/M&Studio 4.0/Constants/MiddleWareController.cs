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
using System.Net.Http;
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
                Task.Factory.StartNew(() =>
                {
                    var uri = App.Current.Properties["MiddleWareUri"].ToString();
                    var convert = new ConvertService();
                    var jss = new JavaScriptSerializer();
                    var stream = jss.Serialize(content);
                    var client = new HttpService();
                    var result = client.PostRequest(uri, stream, string.Empty);
                    result.ContinueWith(item =>
                    {
                        var data = jss.Deserialize<ResponseRenderModel>(item.Result);
                        switch (data.resultid)
                        {
                            case "0x00": NotifyPush.Notify(NOTIFYCODE.RESINIT, data); break;
                            case "0x01": NotifyPush.Notify(NOTIFYCODE.RESDISPOSE, data); break;
                            case "0x02": NotifyPush.Notify(NOTIFYCODE.RESDISPLAY, data); break;
                            case "0x03": NotifyPush.Notify(NOTIFYCODE.RESRENDER, data); break;
                            case "0x04": NotifyPush.Notify(NOTIFYCODE.RESCLEAR, data); break;
                        }
                    });
                });
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