using LoghanAPI.Models.Masters.UserManagement;
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
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        IRoleRepository _Repository;

        public RoleController(IUnitOfWork unitOfWork, IRoleRepository Repository)
        {
            _unitOfWork = unitOfWork;
            _Repository = Repository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResultViewModel> Get()
        {
            var categories = await _Repository.GetAll();
            return categories;
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<ResultViewModel> GetById(Guid Id)
        {
            var data = await _Repository.GetById(Id);
            return data;
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public async Task<ResultViewModel> Delete(Guid Id)
        {
            var data = await _Repository.Delete(Id);
            return data;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ResultViewModel> PostApplication(MasterVM datas)
        {
            var data = await _Repository.Post(datas);
            return data;
        }
    }
}
