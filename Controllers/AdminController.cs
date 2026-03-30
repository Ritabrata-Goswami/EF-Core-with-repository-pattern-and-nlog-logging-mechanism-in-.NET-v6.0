using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelRepoManager;
using Cls_Model;
using Cls_ResLib;
using ILoggerContract;
using EmployeeManagementSystem.Cls_Extensiton;
using Microsoft.AspNetCore.Authorization;


namespace EmployeeManagementSystem.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IManager _IManager;
        private ILoggerManager _ILoggerManager;
        private IConfiguration _Config;
        public AdminController(IManager Imanager, ILoggerManager IloggerManager, IConfiguration Config) 
        {
            _IManager = Imanager;
            _ILoggerManager = IloggerManager;
            _Config = Config;
        }

        [Authorize(Roles = "Human Resource")]
        [HttpPost("AddEmpTypeMaster")]
        public IActionResult AddEmpTypeMaster(EmployeeTypeMaster TypeMaster)
        {
            CommonRes Cls_CommonRes = new CommonRes();
            string ErrMsg = "";
            try
            {
                _IManager.empTypeMaster.AddObject(TypeMaster);
                _IManager.saveEntity();
                Cls_CommonRes.StatusCode = 201;
                Cls_CommonRes.StatusMsg = "Employee type is saved successfully!";
                return Created("./api/v1/Employee/AddEmpTypeMaster", Cls_CommonRes);
            }
            catch (Exception ex) 
            {
                Cls_CommonRes.StatusCode = 500;
                Cls_CommonRes.StatusMsg = ex.Message;
                ErrMsg = $"(AddEmpTypeMaster) ---- Exception:- {ex.Message}";
                _ILoggerManager.Error_Log(ErrMsg);
                return StatusCode(500, Cls_CommonRes);
            }
            
        }

        [Authorize]
        [HttpGet("GetEmpTypeMaster")]
        public IActionResult GetEmpTypeMaster()
        {
            Cls_FetchEmpTypeList cls_FetchEmpTypeList = new Cls_FetchEmpTypeList();
            CommonRes cls_CommRes = new CommonRes();
            EmployeeTypeMaster EmpMaster = null;
            List<EmployeeTypeMaster> ListVal = new List<EmployeeTypeMaster>(); 
            string errLogMsg = "";
            try
            {
                List<EmployeeTypeMaster> Res = _IManager.empTypeMaster.GetEmpTypeMaster();
                if (Res.Count == 0)
                {
                    cls_CommRes.StatusCode = 404;
                    cls_CommRes.StatusMsg = "No data found!";
                    errLogMsg = $"GetEmpTypeMaster --- Exception:- No data found on GetEmpTypeMaster!";
                    _ILoggerManager.Error_Log(errLogMsg);
                    return NotFound(cls_CommRes);
                }
                foreach(EmployeeTypeMaster SingleRow in Res)
                {
                    EmpMaster = new EmployeeTypeMaster
                    {
                        Id = SingleRow.Id,
                        Name = SingleRow.Name,
                    };
                    ListVal.Add(EmpMaster);
                }
                cls_CommRes.StatusCode = 200;
                cls_CommRes.StatusMsg = "Data fetched successfully!";
                cls_FetchEmpTypeList.EmpMasterList = ListVal;
                cls_FetchEmpTypeList.commonRes = cls_CommRes;

                return Ok(cls_FetchEmpTypeList);
            }
            catch (Exception ex) 
            {
                cls_CommRes.StatusCode = 500;
                cls_CommRes.StatusMsg = ex.Message;
                errLogMsg = $"(GetEmpTypeMaster) ---- Exception:- {ex.Message}";
                _ILoggerManager.Error_Log(errLogMsg);
                return StatusCode(500, cls_CommRes);
            }
        }
        [Authorize]
        [HttpGet("GetEmpList")]
        public IActionResult GetEmpList()
        {
            CommonRes cls_CommRes = new CommonRes();
            string errLogMsg = "";
            List<EmployeeMaster> empMstrList = null;
            Cls_FetchEmpMaster cls_FetchEmpMaster = new Cls_FetchEmpMaster();
            try
            {
                empMstrList = _IManager.empMaster.GetEmpList();
                if(empMstrList.Count == 0)
                {
                    cls_CommRes.StatusCode = 404;
                    cls_CommRes.StatusMsg = "No employee list found!";
                    errLogMsg = "(GetEmpList) ---- Exception:- No employee list found!";
                    _ILoggerManager.Error_Log(errLogMsg);
                    cls_FetchEmpMaster.commonRes = cls_CommRes;
                    return NotFound(cls_FetchEmpMaster);
                }

                cls_CommRes.StatusCode = 200;
                cls_CommRes.StatusMsg = "Data fetched successfully!";
                cls_FetchEmpMaster.commonRes = cls_CommRes;
                cls_FetchEmpMaster.empMstrList = empMstrList;
                return Ok(cls_FetchEmpMaster);
            }
            catch (Exception ex) 
            {
                cls_CommRes.StatusCode = 500;
                cls_CommRes.StatusMsg = ex.Message;
                errLogMsg = $"(GetEmpList) ---- Exception:- {ex.Message}";
                _ILoggerManager.Error_Log(errLogMsg);
                return StatusCode(500, cls_CommRes);
            }
        }


    }
}
