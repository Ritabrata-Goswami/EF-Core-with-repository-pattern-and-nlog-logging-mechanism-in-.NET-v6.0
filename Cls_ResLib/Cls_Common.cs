using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cls_Model;


namespace Cls_ResLib
{
    public class CommonRes
    {
        public int StatusCode { get; set; }
        public string StatusMsg { get; set; }
    }
    public class Cls_LoginRes
    {
        public CommonRes commonRes { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string JoiningDate { get; set; }
        public int LoginType { get; set; }
        public string AuthToken { get; set; }
    }
    public class Cls_FetchEmpTypeList
    {
        public CommonRes commonRes { get; set; }
        public List<EmployeeTypeMaster> EmpMasterList {  get; set; }
    }
}
