using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cls_Model;
using InterfaceContract;
using Cls_DbContext;
using Cls_ResLib;
using Microsoft.EntityFrameworkCore;

namespace ContractImplement
{
    public class AdminInfoRepo : Cls_ImplementCrud<AdminInfo>, IAdminInfo
    {
        private Cls_EmployeeDbContext _Cls_EmpContext;
        public AdminInfoRepo(Cls_EmployeeDbContext Cls_EmpContext) : base(Cls_EmpContext)
        {
            _Cls_EmpContext = Cls_EmpContext;
        }

        public List<AdminInfo> AdminLogin(string UId, string UPass)
        {
            var Res = _Cls_EmpContext?.AdminInfo?.FromSqlRaw("SELECT * FROM AdminInfo WHERE LoginId={0} AND LoginPass={1} AND Active='Y'", UId, UPass).ToList();
            return Res;
        }
    }
    public class EmployeeTypeMasterRepo : Cls_ImplementCrud<EmployeeTypeMaster>, IEmpTypeMaster
    {
        private Cls_EmployeeDbContext _Cls_EmpContext;
        public EmployeeTypeMasterRepo(Cls_EmployeeDbContext Cls_EmpContext) : base(Cls_EmpContext)
        {
            _Cls_EmpContext = Cls_EmpContext;
        }

        public List<EmployeeTypeMaster> GetEmpTypeMaster()
        {
            List<EmployeeTypeMaster> Res = _Cls_EmpContext.EmpTypeMasters.ToList();
            return Res;
        }
    }

    public class EmployeeMasterRepo : Cls_ImplementCrud<EmployeeMaster>, IEmpMaster
    {
        public EmployeeMasterRepo(Cls_EmployeeDbContext Cls_EmpContext) : base(Cls_EmpContext)
        {

        }
    }
}
