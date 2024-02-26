using LoghanAPI.Models.Masters.Status;
using LoghanAPI.Repository.Base;
using LoghanAPI.Services.UnitOfWork;

namespace LoghanAPI.Repository.Masters
{
    public class StatusLaporanRepository : RepositoryBase<StatusLaporan>
    {
        public StatusLaporanRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
