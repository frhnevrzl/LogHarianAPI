using LoghanAPI.Models.Masters.UserManagement;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Services.UnitOfWork;
using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class JabatanController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Jabatan> _jabatanRepository;

        public JabatanController(IUnitOfWork unitOfWork, IRepository<Jabatan> jabatanRepository)
        {
            _unitOfWork = unitOfWork;
            _jabatanRepository = jabatanRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultViewModel> Get()
        {
            var categories = await _jabatanRepository.Get();
            return categories;
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<ResultViewModel> GetById(int Id)
        {
            var data = await _jabatanRepository.Get(Id);
            return data;
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public async Task<ResultViewModel> Delete(int Id)
        {
            var data = await _jabatanRepository.Delete(Id);
            return data;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ResultViewModel> Post(Jabatan datas)
        {
            var data = await _jabatanRepository.Create(datas);
            return data;
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public async Task<ResultViewModel> Update(int Id, Jabatan jabatan)
        {
            var data = await _jabatanRepository.Update(Id, jabatan);
            return data;
        }
    }
}
