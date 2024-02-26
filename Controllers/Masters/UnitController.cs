using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Services.UnitOfWork;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        IUnitRepository _unitRepository;

        public UnitController(IUnitOfWork unitOfWork, IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultViewModel> GetUnit()
        {
            var categories = await _unitRepository.GetAll();
            return categories;
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<ResultViewModel> GetUnitById(int Id)
        {
            var data = await _unitRepository.GetById(Id);
            return data;
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public async Task<ResultViewModel> DeleteUnit(int Id)
        {
            var data = await _unitRepository.Delete(Id);
            return data;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ResultViewModel> PostUnit(UnitVM datas) 
        { 
            var data = await _unitRepository.Post(datas);
            return data;
        }
    }
}
