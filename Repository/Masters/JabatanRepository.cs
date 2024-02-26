using LoghanAPI.Models.Masters.UserManagement;
using LoghanAPI.Repository.Base;
using LoghanAPI.Services.UnitOfWork;

namespace LoghanAPI.Repository.Masters
{
    public class JabatanRepository : RepositoryBase<Jabatan>
    {
        public JabatanRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
