using LoghanAPI.Data;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Services;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace LoghanAPI.Repository.Masters
{
    public class AuthRepository : IAuthRepository
    {
        protected AppDbContext _appDbContext;
        protected PasswordServices _passService;
        protected JwtServices _jwtService;
        public AuthRepository(AppDbContext appDbContext, PasswordServices passService, JwtServices jwtService)
        {
            _appDbContext = appDbContext;
            _passService = passService;
            _jwtService = jwtService;
        }
        public ResultViewModel Login([FromBody] AuthVM data)
        {
            var result = new ResultViewModel();

            try
            {
                if (data.Username != null)
                {
                    var dataLogin = _appDbContext.Users.Where(x => x.Username == data.Username).FirstOrDefault();

                    if (dataLogin != null)
                    {
                        bool isMatched = _passService.VerifyPassword(data.Password, dataLogin.Password);

                        if (isMatched)
                        {
                            var TokenVM = new TokenGeneratorVM
                            {
                                Username = dataLogin.Username,
                                Roles = _appDbContext.UserRoles.Where(r => r.Username == dataLogin.Username).ToList().Select(r => r.RoleId).ToList(),
                            };
                            var token = _jwtService.GenerateToken(TokenVM);

                            result.Message = token;
                            result.IsSuccess = true;
                            result.IsRedirect = true;
                            result.RedirectUrl = "Home/Index";
                            return result;
                        }
                        else
                        {
                            result.Message = "Wrong Password";
                            result.IsSuccess = false;
                            result.IsRedirect = false;
                            result.RedirectUrl = "Home/Login";
                            return result;
                        }
                    }
                    else
                    {
                        result.Message = "User Not Registered";
                        result.IsSuccess = false;
                        result.IsRedirect = false;
                        result.RedirectUrl = "Home/Login";
                        return result;
                    }
                }
                else
                {
                    result.Message = "Username Not Valid";
                    result.IsSuccess = false;
                    result.IsRedirect = false;
                    result.RedirectUrl = "Home/Login";
                    return result;
                }
            }
            catch (Exception e)
            {

                result.Message = e.InnerException.Message;
                result.IsSuccess = false;
                result.IsRedirect = false;
                result.RedirectUrl = "Home/Login";
                return result;
            }
        }
    }
}
