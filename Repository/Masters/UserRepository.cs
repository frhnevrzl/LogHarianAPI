using LoghanAPI.Data;
using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Models.Masters.UserManagement;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Services;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoghanAPI.Repository.Masters
{
    public class UserRepository : IUserRepository
    {
        protected AppDbContext _appDbContext;
        protected PasswordServices _passService;
        public UserRepository(AppDbContext context, PasswordServices passService)
        {
            _appDbContext = context;
            _passService = passService;
        }

        public ResultViewModel Delete(string npp)
        {
            var result = new ResultViewModel();

            var getData = _appDbContext.Users.Where(x => x.NPP == npp).FirstOrDefault();
            getData.IsDeleted = true;
            _appDbContext.Entry(getData).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            result.IsSuccess = true;
            result.Message = "Success Deleting User";

            return result;
        }

        public ResultViewModel Get()
        {
            var result = new ResultViewModel();

            var data = _appDbContext.Users
                .Include(x => x.Unit)
                .Include(x => x.Unit.Kelompok)
                .Include(x => x.StatusPegawai)
                .Include(x =>x.UserRole)
                .ThenInclude(x=>x.Role)
                .Where(x => x.IsDeleted == false)
                .ToList();
            try
            {
                result.IsSuccess = true;
                result.Data = data;
                result.Message = "Success";
                result.ItemsCount = data.Count;
                return result;
            }
            catch (Exception e)
            {

                result.IsSuccess = false;
                result.Message = e.InnerException.Message;
                return result;
            }

        }

        public ResultViewModel GetById(string npp)
        {
            var result = new ResultViewModel();

            var data = _appDbContext.Users.Include(x => x.Unit)
                .Include(x => x.StatusPegawai)
                .Include(x => x.UserRole)
                .ThenInclude(x=>x.Role)
                .Where(x => x.NPP == npp)
                .ToList();
            try
            {
                result.IsSuccess = true;
                result.Data = data;
                result.Message = "Success";
                return result;
            }
            catch (Exception e)
            {

                result.IsSuccess = false;
                result.Message = e.Message;
                return result;
            }
        }

        public ResultViewModel Post(UsersViewModel users)
        {
            try
            {
                bool isExist = _appDbContext.Users.Where(x=>x.Username == users.NPP).ToList().Any();
                if (!isExist)
                {
                    var data = new User
                    {
                        NPP = users.NPP,
                        Nama = users.Nama,
                        Email = users.Email,
                        Username = users.NPP,
                        JabatanId = users.JabatanId,
                        Ext = users.Ext,
                        Password = _passService.HashPassword(users.Password),
                        StatusPegawaiId = users.StatusPegawaiId,
                        UnitId = users.UnitId,
                        IsDeleted = false
                    };
                    _appDbContext.Users.Add(data);
                    _appDbContext.SaveChanges();

                    if (users.Roles.Count != 0)
                    {
                        foreach (var role in users.Roles)
                        {
                            var userRole = new UserRole
                            {
                                Username = data.Username,
                                RoleId = role.RoleId
                            };
                            _appDbContext.UserRoles.Add(userRole);
                            _appDbContext.SaveChanges();
                        }
                    }

                    var result = new ResultViewModel();
                    result.IsSuccess = true;
                    result.Message = "Success Add User";

                    return result;
                }
                else
                {
                    var data = _appDbContext.Users.Where(x => x.NPP == users.NPP).FirstOrDefault();
                    if (data == null)
                    {
                        throw new Exception("No Matching Record");
                    }
                    else
                    {
                        data.Ext = users.Ext;
                        data.Nama = users.Nama;
                        data.Email = users.Email;
                        data.JabatanId = users.JabatanId;
                        data.UnitId = users.UnitId;
                        _appDbContext.Entry(data).State = EntityState.Modified;
                        _appDbContext.SaveChanges();

                        if (users.Roles.Count != 0)
                        {
                            //Reset UserRoles by Username
                            var currRoles = _appDbContext.UserRoles.Where(x=>x.Username == data.NPP).ToList();
                            _appDbContext.RemoveRange(currRoles);
                            _appDbContext.SaveChanges();

                            //InsertNewUserRoles
                            foreach (var role in users.Roles)
                            {
                                var userRole = new UserRole
                                {
                                    Username = data.Username,
                                    RoleId = role.RoleId
                                };
                                _appDbContext.UserRoles.Add(userRole);
                                _appDbContext.SaveChanges();
                            }
                        }

                        var result = new ResultViewModel();
                        result.IsSuccess = true;
                        result.Message = "Success Updating User";

                        return result;
                    }

                }

            }
            catch (Exception e)
            {

                var result = new ResultViewModel();
                result.IsSuccess = false;
                result.Message = e.Message;

                return result;
            }

        }


    }
}
