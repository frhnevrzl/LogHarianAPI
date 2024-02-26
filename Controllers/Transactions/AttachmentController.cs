using LoghanAPI.Repository.Interface;
using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Controllers.Transactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        protected IAttachmentRepository _attachmentRepository;

        public AttachmentController(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        [HttpGet]
        [Route("GetAttachment")]
        public ResultViewModel Get(int laporamId)
        {
            var data = _attachmentRepository.GetListAttachmentLaporan(laporamId);
            return data;
        }

        [HttpGet]
        [Route("GetById")]
        public ResultViewModel GetById(int id)
        {
            var data = _attachmentRepository.GetAttachmentLaporanById(id);
            return data;
        }

        [HttpDelete]
        [Route("Delete")]
        public ResultViewModel DeleteAttachment(int id)
        {
            var data = _attachmentRepository.DeleteAttachmentById(id);
            return data;
        }

        [HttpPost]
        [Route("Post")]
        public ResultViewModel PostAttachment(int laporanId, List<IFormFile> files)
        {
            var data = _attachmentRepository.AddAttachmentLaporan(laporanId, files);
            return data;
        }
    }
}
