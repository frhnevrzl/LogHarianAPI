using LoghanAPI.Repository.Interface;
using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Controllers.Transactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogApprovalController : ControllerBase
    {
        protected ILogApprovalRepository _logApprovalRepository;

        public LogApprovalController(ILogApprovalRepository logApprovalRepository) => _logApprovalRepository = logApprovalRepository;

        [HttpPost]
        [Route("GetById")]
        public ResultViewModel GetResult(int id)
        {
            var data = _logApprovalRepository.GetById(id);
            return data;
        }
    }
}
