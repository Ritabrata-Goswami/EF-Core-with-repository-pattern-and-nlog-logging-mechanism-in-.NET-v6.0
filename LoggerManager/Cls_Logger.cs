using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;
using NLog;
using ILoggerContract;

//Install Nlog Nuget package
namespace LoggerManager
{
    public class Cls_Logger : ILoggerManager
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger(); 

        public void Error_Log(string message)
        {
            _logger.Error(message);
        }
        public void Debug_Log(string message)
        {
            _logger.Debug(message);
        }
        public void Info_Log(string message) 
        {
            _logger.Info(message);
        }
        public void Warn_Log(string message) 
        {
            _logger.Warn(message);
        }
    }
}
