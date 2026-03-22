using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cls_Model;


/*=================Infrastructure Layer===================*/
namespace Cls_DbContext
{
    public class Cls_EmployeeDbContext : DbContext
    {
        public DbSet<EmployeeTypeMaster>? EmpTypeMasters { get; set; }
        public DbSet<EmployeeMaster>? EmpMaster { get; set; }
        public DbSet<AdminInfo>? AdminInfo { get; set; }

        public Cls_EmployeeDbContext(DbContextOptions<Cls_EmployeeDbContext> Options) : base(Options) 
        {
            
        }
    }
}
