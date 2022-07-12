using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MnStudio.Constants
{
    class ProcessController
    {
        public static bool StartUp()
        {
            var psMiddleWare = Process.GetProcessesByName(App.Current.Properties["MiddleWareName"].ToString());
            if (psMiddleWare.Length > 0)
                return false;

            var psObj = new Process();
            psObj.StartInfo.FileName = App.Current.Properties["MiddleWareName"].ToString();
            psObj.StartInfo.WorkingDirectory = @App.Current.Properties["MiddleWarePath"].ToString();
            psObj.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            psObj.Start();
            return true;
        }
        public static bool IsWatcher()
        {
            if (App.Current == null)
                return false;

            var psMiddleWare = Process.GetProcessesByName(App.Current.Properties["MiddleWareName"].ToString());
            if (psMiddleWare.Length > 0)
                return true;

            return false;
        }
    }
}
