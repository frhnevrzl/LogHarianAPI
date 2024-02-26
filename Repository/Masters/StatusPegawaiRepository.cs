using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Repository.Base;
using LoghanAPI.Services.UnitOfWork;

namespace LoghanAPI.Repository.Masters
{
    public class StatusPegawaiRepository : RepositoryBase<StatusPegawai>
    {
        public StatusPegawaiRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
