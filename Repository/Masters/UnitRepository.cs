using LoghanAPI.Data;
using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Repository.Base;
using LoghanAPI.Repository.Interface;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.EntityFrameworkCore;

namespace LoghanAPI.Repository.Masters
{
    public class UnitRepository : IUnitRepository
    {
        protected AppDbContext _appDbContext;
        public UnitRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public async Task<ResultViewModel> GetAll()
        {
            var result = new ResultViewModel();

            var data = _appDbContext.Units
                .Include(x=>x.Kelompok)
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

        public async Task<ResultViewModel> GetById(int id)
        {
            var result = new ResultViewModel();

            var data = _appDbContext.Units
                .Include(x => x.Kelompok)
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

        public async Task<ResultViewModel> Delete(int id)
        {
            var result = new ResultViewModel();

            var getData = _appDbContext.Units.Where(x => x.Id == id).FirstOrDefault();
            _appDbContext.Remove(getData);
            _appDbContext.SaveChanges();

            result.IsSuccess = true;
            result.Message = "Success Deleting User";

            return result;
        }
        public async Task<ResultViewModel> Post(UnitVM datas)
        {
            try
            {
                if (datas.Id == null)
                {
                    var newData = new Unit
                    {
                        Nama = datas.Nama,
                        KelompokId = datas.KelompokId,
                    };
                    _appDbContext.Add(newData);
                    _appDbContext.SaveChanges();

                    var result = new ResultViewModel();
                    result.IsSuccess = true;
                    result.Message = "Success Add Unit";
                    return result;
                }
                else
                {
                    var editData = _appDbContext.Units.Where(x=>x.Id == datas.Id).FirstOrDefault();
                    editData.Nama = datas.Nama;
                    editData.KelompokId = datas.KelompokId;

                    _appDbContext.Entry(editData).State = EntityState.Modified;
                    _appDbContext.SaveChanges();

                    var result = new ResultViewModel();
                    result.IsSuccess = true;
                    result.Message = "Success Edit Unit";

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
