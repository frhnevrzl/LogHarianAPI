using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Repository.Masters;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserRepository _repository;

        public UsersController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        [HttpGet]
        [Route("Get")]
        public ResultViewModel GetUser()
        {
            var result = _repository.Get();
            return result;
        }

        [HttpGet]
        [Route("Get/{npp}")]
        public IActionResult Get(string npp)
        {
            var data = _repository.GetById(npp);
            return Ok(data);
        }

        [HttpDelete]
        [Route("Delete/{npp}")]
        public IActionResult Delete(string npp)
        {
            var data = _repository.Delete(npp);

            return Ok(data);
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Insert([FromBody] UsersViewModel model)
        {
            var data = _repository.Post(model);
            return Ok(data);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] UsersViewModel model)
        {
            var data = _repository.Post(model);
            return Ok(data);
        }
    }
}
