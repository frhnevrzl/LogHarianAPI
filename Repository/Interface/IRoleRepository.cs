using LoghanAPI.ViewModels.Masters;
using LoghanAPI.ViewModels;

namespace LoghanAPI.Repository.Interface
{
    public interface IRoleRepository
    {
        Task<ResultViewModel> GetAll();
        Task<ResultViewModel> GetById(Guid id);
        Task<ResultViewModel> Delete(Guid id);
        Task<ResultViewModel> Post(MasterVM datas);
    }
}
