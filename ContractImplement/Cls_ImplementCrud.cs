using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceContract;
using Cls_DbContext;


namespace ContractImplement
{
    public class Cls_ImplementCrud<T> : ICrudMethods<T> where T : class
    {
        private Cls_EmployeeDbContext _Cls_EmpContext;
        public Cls_ImplementCrud(Cls_EmployeeDbContext Cls_EmpContext)
        {
            _Cls_EmpContext = Cls_EmpContext;
        }

        public void AddObject(T obj) 
        {
            _Cls_EmpContext.Set<T>().Add(obj);
        }
        public void UpdateObject(T obj) 
        {
            _Cls_EmpContext.Set<T>().Update(obj);
        }
        public void DeleteObject(T obj)
        {
            _Cls_EmpContext.Set<T>().Remove(obj);
        }
    }
}
