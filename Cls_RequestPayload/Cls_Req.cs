using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cls_RequestPayload
{
    public class Cls_LoginReq
    {
        public string LoginId { get; set; }
        public string LoginPass { get; set; }
        public string Type { get; set; }
    }
}
