using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cls_Model;
using Cls_ResLib;

namespace InterfaceContract
{
    public interface IAdminInfo : ICrudMethods<AdminInfo>
    {
        public List<AdminInfo> AdminLogin(string UId, string UPass);
    }
    public interface IEmpTypeMaster : ICrudMethods<EmployeeTypeMaster>
    {
        public List<EmployeeTypeMaster> GetEmpTypeMaster();
    }

    public interface IEmpMaster : ICrudMethods<EmployeeMaster>
    {
        public List<EmployeeMaster> GetEmpList();
    }
}
