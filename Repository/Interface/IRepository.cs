using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace LoghanAPI.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        public Task<ResultViewModel> Get();
        public Task<ResultViewModel> Get(int Id);
        public Task<ResultViewModel> Create(T entity);
        public Task<ResultViewModel> Update(int Id, T entity);
        public Task<ResultViewModel> Delete(int id);
    }
}
