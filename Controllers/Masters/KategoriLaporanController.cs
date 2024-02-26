using LoghanAPI.Models.Masters.Application;
using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Services.UnitOfWork;
using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriLaporanController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<KategoriLaporan> _repository;

        public KategoriLaporanController(IUnitOfWork unitOfWork, IRepository<KategoriLaporan> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultViewModel> Get()
        {
            var categories = await _repository.Get();
            return categories;
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<ResultViewModel> GetById(int Id)
        {
            var data = await _repository.Get(Id);
            return data;
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public async Task<ResultViewModel> Delete(int Id)
        {
            var data = await _repository.Delete(Id);
            return data;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ResultViewModel> Post(KategoriLaporan kategori)
        {
            var data = await _repository.Create(kategori);
            return data;
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public async Task<ResultViewModel> Update(int Id, KategoriLaporan kategori)
        {
            var data = await _repository.Update(Id, kategori);
            return data;
        }
    }
}
