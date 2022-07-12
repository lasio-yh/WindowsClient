using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Windows.Controls;

namespace MnStudio.Constants
{
    class NotifyPush
    {
        public static event Action<object> OpenFile;
        public static event Action<object> ClearFile;
        public static event Action<object> UndoSlide;
        public static event Action<object> RedoSlide;
        public static event Action<object> ApplyStanBy;
        public static event Action<object> ConnectServer;
        public static event Action<object> DisconnectServer;
        public static event Action<object> ReceiveStart;
        public static event Action<object> ReceiveStop;
        public static event Action<object> ReceiveInitialize;
        public static event Action<object> ReceiveDispose;
        public static event Action<object> ReceiveDisplay;
        public static event Action<object> ReceiveRender;
        public static event Action<object> ReceiveClear;
        public static event Action<object> ReceiveLogin;
        public static event Action<object> ReceiveMessageSetting;
        public static event Action<object> ReceiveMessageData;
        public static event Action<object> ReceiveVoteList;
        public static event Action<object> ReceiveVoteEdit;
        public static event Action<object> ReceiveVoteDelete;
        public static event Action<object> ReceiveVoteStatus;
        public static event Action<object> ReceiveVoteResult;
        public static event Action<object> ReceiveVoteStart;
        public static event Action<object> ReceiveVoteStop;
       
        public static void Notify(NOTIFYCODE param, object obj)
        {
            switch (param)
            {
                case NOTIFYCODE.SUCCESSFILEOPEN:
                    {
                        if (OpenFile != null)
                            OpenFile(obj);

                        break;
                    }
                case NOTIFYCODE.SUCCESSFILECLEAR:
                    {
                        if (ClearFile != null)
                            ClearFile(obj);

                        break;
                    }
                case NOTIFYCODE.UNDOSLIDE:
                    {
                        if (UndoSlide != null)
                            UndoSlide(obj);

                        break;
                    }
                case NOTIFYCODE.REDOSLIDE:
                    {
                        if (RedoSlide != null)
                            RedoSlide(obj);

                        break;
                    }
                case NOTIFYCODE.APPLYSTANBY:
                    {
                        if (ApplyStanBy != null)
                            ApplyStanBy(obj);

                        break;
                    }
                case NOTIFYCODE.CONNECTSERVER:
                    {
                        if (ConnectServer != null)
                            ConnectServer(obj);

                        break;
                    }
                case NOTIFYCODE.DISCONNECTSERVER:
                    {
                        if (DisconnectServer != null)
                            DisconnectServer(obj);

                        break;
                    }
                case NOTIFYCODE.RECEIVESTART:
                    {
                        if (ReceiveStart != null)
                            ReceiveStart(obj); 
                        
                        break;
                    }
                case NOTIFYCODE.RECEIVESTOP:
                    {
                        if (ReceiveStop != null)
                            ReceiveStop(obj);

                        break;
                    }
                case NOTIFYCODE.RESINIT:
                    {
                        if (ReceiveInitialize != null)
                            ReceiveInitialize(obj);

                        break;
                    }
                case NOTIFYCODE.RESDISPOSE:
                    {
                        if (ReceiveDispose != null)
                            ReceiveDispose(obj);

                        break;
                    }
                case NOTIFYCODE.RESDISPLAY:
                    {
                        if (ReceiveDisplay != null)
                            ReceiveDisplay(obj);

                        break;
                    }
                case NOTIFYCODE.RESRENDER:
                    {
                        if (ReceiveRender != null)
                            ReceiveRender(obj);

                        break;
                    }
                case NOTIFYCODE.RESCLEAR:
                    {
                        if (ReceiveClear != null)
                            ReceiveClear(obj);

                        break;
                    }
                case NOTIFYCODE.RESLOGIN:
                    {
                        if (ReceiveLogin != null)
                            ReceiveLogin(obj);

                        break;
                    }
                case NOTIFYCODE.RESMESSAGESETTING:
                    {
                        if (ReceiveMessageSetting != null)
                            ReceiveMessageSetting(obj);

                        break;
                    }
                case NOTIFYCODE.RESMESSAGEDATA:
                    {
                        if (ReceiveMessageData != null)
                            ReceiveMessageData(obj);

                        break;
                    }
                case NOTIFYCODE.RESVOTELIST:
                    {
                        if (ReceiveVoteList != null)
                            ReceiveVoteList(obj);

                        break;
                    }
                case NOTIFYCODE.RESVOTEEDIT:
                    {
                        if (ReceiveVoteEdit != null)
                            ReceiveVoteEdit(obj);

                        break;
                    }
                case NOTIFYCODE.RESVOTEDELETE:
                    {
                        if (ReceiveVoteDelete != null)
                            ReceiveVoteDelete(obj);

                        break;
                    }
                case NOTIFYCODE.RESVOTESTATUS:
                    {
                        if (ReceiveVoteStatus != null)
                            ReceiveVoteStatus(obj);

                        break;
                    }
                case NOTIFYCODE.RESVOTERESULT:
                {
                    if (ReceiveVoteResult != null)
                        ReceiveVoteResult(obj);

                    break;
                }
                case NOTIFYCODE.RESVOTESTART:
                {
                    if (ReceiveVoteStart != null)
                        ReceiveVoteStart(obj);

                    break;
                }
                case NOTIFYCODE.RESVOTESTOP:
                {
                    if (ReceiveVoteStop != null)
                        ReceiveVoteStop(obj);

                    break;
                }
                default : break;
            }
        }
    }
}

