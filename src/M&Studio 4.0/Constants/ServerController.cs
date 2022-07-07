using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MnStudio.Core.Services;
using MnStudio.Core.Models;
using MnStudio.Core.Models.Server;
using System.Web.Script.Serialization;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;

namespace MnStudio.Constants
{
    public class ServerController
    {
        public static SocketService Core;
        public static bool Status { get; set; }
        public static string IpAddress = string.Empty;
        public static int Port = -1;
        public static int Size = -1;

        public static void Create()
        {
            try
            {
                Core = new SocketService(OnReceive);
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

        public static void Open()
        {
            try
            {
                Core.Open(App.Current.Properties["ServerIp"].ToString(), Convert.ToInt32(App.Current.Properties["ServerPort"]), 0x1000000);
                Status = true;
                NotifyPush.Notify(NOTIFYCODE.CONNECTSERVER, Status);
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                Status = false;
                NotifyPush.Notify(NOTIFYCODE.DISCONNECTSERVER, Status);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                Status = false;
                NotifyPush.Notify(NOTIFYCODE.DISCONNECTSERVER, Status);
            }
        }

        public static void Close()
        {
            try
            {
                Core.Close();
                Status = false;
                NotifyPush.Notify(NOTIFYCODE.DISCONNECTSERVER, Status);
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

        public static byte[] OnCreatePacket<T>(T content, string id)
        {
            try
            {
                var convert = new ConvertService();
                var jss = new JavaScriptSerializer();
                var request = jss.Serialize(content);
                var obj = new RequestModel { ID = id, REQUEST = request };
                var stream = jss.Serialize(obj);
                var packet = new PacketModel(stream);
                var data = convert.StructureToByte(packet);
                return data;
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                return null;
            }
        }

        public static void OnSend(byte[] data)
        {
            try
            {
                Core.Send(data);
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

        public static void OnReceive(string data)
        {
            try
            {
                var jss = new JavaScriptSerializer();
                var obj = jss.Deserialize<ResponseModel>(data);
                if(obj == null)
                    return;

                if(string.IsNullOrEmpty(obj.ID))
                    return;

                if (obj.RESPONSE == null)
                    return;

                switch(obj.ID)
                {
                    case "102":
                        {
                            var entity = jss.Deserialize<ResponseLoginModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESLOGIN, entity); 
                            break;
                        }
                    case "216":
                        {
                            var entity = jss.Deserialize<ResponseMessageSettingModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESMESSAGESETTING, entity);
                            break;
                        }
                    case "202":
                        {
                            var entity = jss.Deserialize<ResponseMessageDataModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESMESSAGEDATA, entity);
                            break;
                        }
                    case "502":
                        {
                            var entity = jss.Deserialize<ResponseStartVoteModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESVOTESTART, entity);
                            break;
                        }
                    case "504":
                        {
                            var entity = jss.Deserialize<ResponseStopVoteModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESVOTESTOP, entity);
                            break;
                        }
                    case "506":
                        {
                            var entity = jss.Deserialize<ResponseResultVoteModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESVOTERESULT, entity);
                            break;
                        }
                    case "5081":
                        {
                            var entity = jss.Deserialize<ResponseListVoteModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESVOTELIST, entity);
                            break;
                        }
                    case "510":
                        {
                            var entity = jss.Deserialize<ResponseEditVoteModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESVOTEEDIT, entity);
                            break;
                        }
                    case "512":
                        {
                            var entity = jss.Deserialize<ResponseDeleteVoteModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESVOTEDELETE, entity);
                            break;
                        }
                    case "514":
                        {
                            var entity = jss.Deserialize<ResponseStatusVoteModel>(obj.RESPONSE);
                            NotifyPush.Notify(NOTIFYCODE.RESVOTESTATUS, entity);
                            break;
                        }
                    default: break;
                }
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
