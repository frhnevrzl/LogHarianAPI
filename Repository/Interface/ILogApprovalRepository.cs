using LoghanAPI.ViewModels.Masters;
using LoghanAPI.ViewModels;

namespace LoghanAPI.Repository.Interface
{
    public interface ILogApprovalRepository
    {
        ResultViewModel GetById(int id);
        ResultViewModel Post(LogApprovalVM datas);
    }
}
