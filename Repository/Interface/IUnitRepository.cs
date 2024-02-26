using LoghanAPI.ViewModels.Masters;
using LoghanAPI.ViewModels;
using LoghanAPI.Models.Masters.Main;

namespace LoghanAPI.Repository.Interface
{
    public interface IUnitRepository
    {
        Task<ResultViewModel> GetAll();
        Task<ResultViewModel> GetById(int id);
        Task<ResultViewModel> Delete(int id);
        Task<ResultViewModel> Post(UnitVM datas);
    }
}
