using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cls_DbContext;
using ContractImplement;
using InterfaceContract;


namespace ModelRepoManager
{
    public class Cls_Manager : IManager
    {
        private Cls_EmployeeDbContext _Cls_EmpDbContext;
        private Lazy<IAdminInfo> _adminInfo;
        private Lazy<IEmpTypeMaster> _empTypeMaster;
        private Lazy<IEmpMaster> _empMaster;

        public Cls_Manager(Cls_EmployeeDbContext Cls_EmpContext)
        {
            _Cls_EmpDbContext = Cls_EmpContext;
            _empTypeMaster = new Lazy<IEmpTypeMaster>(()=> new EmployeeTypeMasterRepo(Cls_EmpContext));
            _empMaster = new Lazy<IEmpMaster>(()=> new EmployeeMasterRepo(Cls_EmpContext));
            _adminInfo = new Lazy<IAdminInfo>(() => new AdminInfoRepo(Cls_EmpContext));
        }
        
        //Implementing the contracts
        public IEmpTypeMaster empTypeMaster => _empTypeMaster.Value;
        public IEmpMaster empMaster => _empMaster.Value;
        public IAdminInfo adminInfo => _adminInfo.Value;
        public void saveEntity() 
        {
            _Cls_EmpDbContext.SaveChanges();  //Save entity by reference.
        }
    }
}
