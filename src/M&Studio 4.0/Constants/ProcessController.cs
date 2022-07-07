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
        public static void StartUp()
        {
            //Process Validate
            var ps = new Process();
            ps.StartInfo.FileName = App.Current.Properties["MiddleWareName"].ToString();
            ps.StartInfo.WorkingDirectory = @App.Current.Properties["MiddleWarePath"].ToString();
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            ps.PriorityClass = ProcessPriorityClass.RealTime;
            ps.Start();
        }
    }
}
