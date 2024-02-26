using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Repository.Masters;
using LoghanAPI.Services.UnitOfWork;
using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class KelompokController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Kelompok> _kelompokRepository;

        public KelompokController(IUnitOfWork unitOfWork, IRepository<Kelompok> kelompokRepository)
        {
            _unitOfWork = unitOfWork;
            _kelompokRepository = kelompokRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultViewModel> GetKelompok()
        {
            var categories = await _kelompokRepository.Get();
            return categories;
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<ResultViewModel> GetKelompokById(int Id)
        {
            var data = await _kelompokRepository.Get(Id);
            return data;
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public async Task<ResultViewModel> DeleteKelompok(int Id)
        {
            var data = await _kelompokRepository.Delete(Id);
            return data;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ResultViewModel> PostKelompok(Kelompok kelompok)
        {
            var data = await _kelompokRepository.Create(kelompok);
            return data;
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public async Task<ResultViewModel> UpdateKelompok(int Id, Kelompok kelompok)
        {
            var data = await _kelompokRepository.Update(Id, kelompok);
            return data;
        }
    }
}
