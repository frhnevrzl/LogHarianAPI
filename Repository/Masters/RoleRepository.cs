using LoghanAPI.Data;
using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Models.Masters.UserManagement;
using LoghanAPI.Repository.Base;
using LoghanAPI.Repository.Interface;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.EntityFrameworkCore;

namespace LoghanAPI.Repository.Masters
{
    public class RoleRepository : IRoleRepository
    {
        protected AppDbContext _appDbContext;
        public RoleRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public async Task<ResultViewModel> Delete(Guid id)
        {
            var result = new ResultViewModel();

            var getData = _appDbContext.Roles.Where(x => x.Id == id).FirstOrDefault();
            _appDbContext.Remove(getData);
            _appDbContext.SaveChanges();

            result.IsSuccess = true;
            result.Message = "Success Deleting User";

            return result;
        }

        public async Task<ResultViewModel> GetAll()
        {
            var result = new ResultViewModel();

            var data = _appDbContext.Roles
                //.Where(x => x.IsDeleted == false)
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

        public async Task<ResultViewModel> GetById(Guid id)
        {
            var result = new ResultViewModel();

            var data = _appDbContext.Roles
                .Where(x => x.Id == id)
                .FirstOrDefault();
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

        public async Task<ResultViewModel> Post(MasterVM datas)
        {
            try
            {
                if (datas.Id == null)
                {
                    var newData = new Role
                    {
                        Nama = datas.Nama,
                    };
                    _appDbContext.Add(newData);
                    _appDbContext.SaveChanges();

                    var result = new ResultViewModel();
                    result.IsSuccess = true;
                    result.Message = "Success Add Role";
                    return result;
                }
                else
                {
                    var editData = _appDbContext.Roles.Where(x => x.Id == datas.Id).FirstOrDefault();
                    editData.Nama = datas.Nama;

                    _appDbContext.Entry(editData).State = EntityState.Modified;
                    _appDbContext.SaveChanges();

                    var result = new ResultViewModel();
                    result.IsSuccess = true;
                    result.Message = "Success Edit Role";

                    return result;
                }

            }
            catch (Exception e)
            {

                var result = new ResultViewModel();
                result.IsSuccess = false;
                result.Message = e.InnerException.Message;

                return result;
            }
        }
    }
}
