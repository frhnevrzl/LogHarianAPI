using LoghanAPI.Repository.Interface;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Controllers.Transactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaporanHarianController : ControllerBase
    {
        protected ILaporanHarianRepository _repository;

        public LaporanHarianController(ILaporanHarianRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Get")]
        public ResultViewModel Get([FromBody]DokumenFilter filters)
        {
            var data = _repository.Get(filters);
            return data;
        }

        [HttpGet]
        [Route("GetById")]
        public ResultViewModel GetById(int id)
        {
            var data = _repository.GetById(id);
            return data;
        }

        [HttpDelete]
        [Route("Delete")]
        public ResultViewModel Delete(int id)
        {
            var data = _repository.Delete(id);
            return data;
        }

        [HttpPost]
        [Route("Insert")]
        public ResultViewModel Post(LaporanVM datas)
        {
            var data = _repository.Post(datas);
            return data;
        }
    }
}
