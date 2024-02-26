using LoghanAPI.Models.Masters.Application;
using LoghanAPI.Repository.Base;
using LoghanAPI.Services.UnitOfWork;

namespace LoghanAPI.Repository.Masters
{
    public class ApplicationRepository : RepositoryBase<Application>
    {
        public ApplicationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
