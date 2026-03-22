using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoggerContract
{
    public interface ILoggerManager
    {
        public void Error_Log(string msg);
        public void Info_Log(string msg);
        public void Warn_Log(string msg);
        public void Debug_Log(string msg);
    }
}
