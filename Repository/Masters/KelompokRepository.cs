using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Repository.Base;
using LoghanAPI.Services.UnitOfWork;

namespace LoghanAPI.Repository.Masters
{
    public class KelompokRepository : RepositoryBase<Kelompok>
    {
        public KelompokRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
