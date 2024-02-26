using LoghanAPI.ViewModels.Masters;
using LoghanAPI.ViewModels;

namespace LoghanAPI.Repository.Interface
{
    public interface ILaporanHarianRepository
    {
        ResultViewModel Get(DokumenFilter filters);
        ResultViewModel GetById(int id);
        ResultViewModel Post(LaporanVM datas);
        ResultViewModel Delete(int id);
    }
}
