using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceContract
{
    public interface ICrudMethods<T>
    {
        public void AddObject(T ClsObj);
        public void UpdateObject(T ClsObj);
        public void DeleteObject(T ClsObj);
    }
}
