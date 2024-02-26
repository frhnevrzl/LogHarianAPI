using LoghanAPI.Models.Masters.Application;
using LoghanAPI.Repository.Base;
using LoghanAPI.Services.UnitOfWork;

namespace LoghanAPI.Repository.Masters
{
    public class KategoriLaporanRepository : RepositoryBase<KategoriLaporan>
    {
        public KategoriLaporanRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
