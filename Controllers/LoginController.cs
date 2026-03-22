using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelRepoManager;
using Cls_ResLib;
using Cls_Model;
using ILoggerContract;
using EmployeeManagementSystem.Cls_Extensiton;
using Cls_RequestPayload;
using Enum;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IManager _IManager;
        private ILoggerManager _ILoggerManager;
        private IConfiguration _Config;

        public LoginController(IManager IManager, ILoggerManager ILoggerManager, IConfiguration IConfig)
        {
            _IManager = IManager;
            _ILoggerManager = ILoggerManager;
            _Config = IConfig;
        }

        [HttpPost("Login")]
        public IActionResult Login(Cls_LoginReq Cls_PostPayload)
        {
            Cls_LoginRes cls_LoginRes = new Cls_LoginRes();
            CommonRes cls_CommRes = new CommonRes();
            string FullName = "";
            string errLogMsg = "";

            try
            {
                if(Convert.ToInt32(Cls_PostPayload.Type) == (int)LoginType.admin)
                {
                    List<AdminInfo> Res = _IManager.adminInfo.AdminLogin(Cls_PostPayload.LoginId, Cls_PostPayload.LoginPass);
                    if (Res.Count == 0)
                    {
                        cls_CommRes.StatusCode = 404;
                        cls_CommRes.StatusMsg = "Login Failed, Wrong Credentials Given!";
                        errLogMsg = $"Login --- Exception:- Login Failed, Wrong Credentials Given!";
                        _ILoggerManager.Error_Log(errLogMsg);
                        return NotFound(cls_CommRes);
                    }
                    cls_CommRes.StatusCode = 200;
                    cls_CommRes.StatusMsg = "Login Successful.";
                    cls_LoginRes.commonRes = cls_CommRes;
                    FullName = Res[0].FName + " " + Res[0].LName;
                    cls_LoginRes.Id = Res[0].Id;
                    cls_LoginRes.Name = FullName;
                    cls_LoginRes.Dept = Res[0].DeptName;
                    cls_LoginRes.JoiningDate = Res[0].JoiningDate.ToString();
                    cls_LoginRes.AuthToken = Cls_Extension.GenerateAuthToken(_Config, FullName, Res[0].Id.ToString(), Res[0].DeptName);
                    cls_LoginRes.LoginType = (int)LoginType.admin;
                }
                else if(Convert.ToInt32(Cls_PostPayload.Type) == (int)LoginType.employee)
                {
                    //
                }
                else
                {
                    cls_CommRes.StatusCode = 404;
                    cls_CommRes.StatusMsg = "Login Failed, Wrong Credentials Given!";
                    errLogMsg = $"Login --- Exception:- Login Failed, Wrong Credentials Given!";
                    _ILoggerManager.Error_Log(errLogMsg);
                    return NotFound(cls_CommRes);
                }
                
                
     
                return Ok(cls_LoginRes);
            }
            catch (Exception ex) 
            {
                cls_CommRes.StatusCode =500;
                cls_CommRes.StatusMsg = ex.Message;
                errLogMsg = $"Login --- Exception:- {ex.Message}";
                _ILoggerManager.Error_Log(errLogMsg);
                return StatusCode(500, cls_CommRes);
            }
        }


    }
}
