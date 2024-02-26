using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Repository.Interface
{
    public interface IAttachmentRepository
    {
        string InsertAttachmentLaporan(int laporamId, IFormFile file);
        ResultViewModel AddAttachmentLaporan(int laporanId, List<IFormFile> files);
        ResultViewModel GetListAttachmentLaporan(int laporamId);
        ResultViewModel GetAttachmentLaporanById(int id);
        ResultViewModel DeleteAttachmentById(int id);
    }
}
