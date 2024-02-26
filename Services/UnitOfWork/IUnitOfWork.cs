using LoghanAPI.Data;

namespace LoghanAPI.Services.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        AppDbContext Context { get; }
        public Task SaveChangesAsync();
    }
}
