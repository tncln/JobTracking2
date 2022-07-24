using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.Web.CustomLogger
{
    public class NLogLogger
    {
        public void LogWithNLog(string message)
        {
            var logger= LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
