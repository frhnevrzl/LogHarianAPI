using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Repository.Interface
{
    public interface IAuthRepository
    {
        ResultViewModel Login([FromBody] AuthVM data);
    }
}
