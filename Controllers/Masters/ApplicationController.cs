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
    public class ApplicationController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        IRepository<Application> _applicationRepository;

        public ApplicationController(IUnitOfWork unitOfWork, IRepository<Application> applicationRepository)
        {
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultViewModel> GetApplication()
        {
            var categories = await _applicationRepository.Get();
            return categories;
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<ResultViewModel> GetApplicationById(int Id)
        {
            var data = await _applicationRepository.Get(Id);
            return data;
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public async Task<ResultViewModel> DeleteApplication(int Id)
        {
            var data = await _applicationRepository.Delete(Id);
            return data;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ResultViewModel> PostApplication(Application application)
        {
            var data = await _applicationRepository.Create(application);
            return data;
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public async Task<ResultViewModel> UpdateApplication(int Id, Application application)
        {
            var data = await _applicationRepository.Update(Id, application);
            return data;
        }
    }
}
