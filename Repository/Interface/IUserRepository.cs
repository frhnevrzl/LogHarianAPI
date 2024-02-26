using LoghanAPI.ViewModels.Masters;
using LoghanAPI.ViewModels;

namespace LoghanAPI.Repository.Interface
{
    public interface IUserRepository
    {
        ResultViewModel Get();
        ResultViewModel GetById(string npp);
        ResultViewModel Post(UsersViewModel users);
        ResultViewModel Delete(string npp);
    }
}
