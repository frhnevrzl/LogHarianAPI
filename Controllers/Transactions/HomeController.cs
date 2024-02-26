using LoghanAPI.Repository.Interface;
using LoghanAPI.Repository.Masters;
using LoghanAPI.Services.UnitOfWork;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Controllers.Transactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
       IAuthRepository _repository;

        public HomeController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthVM model)
        {
            var data = _repository.Login(model);
            return Ok(data);
        }
    }
}
