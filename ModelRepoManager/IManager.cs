using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceContract;


namespace ModelRepoManager
{
    public interface IManager
    {
        public IAdminInfo adminInfo { get; }
        public IEmpTypeMaster empTypeMaster { get; }
        public IEmpMaster empMaster { get; }
        public void saveEntity();
    }
}
