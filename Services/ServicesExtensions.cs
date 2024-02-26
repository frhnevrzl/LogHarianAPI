using LoghanAPI.Models.Logs;
using LoghanAPI.Models.Masters.Application;
using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Models.Masters.Status;
using LoghanAPI.Models.Masters.UserManagement;
using LoghanAPI.Repository;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Repository.Masters;
using LoghanAPI.Repository.Transactions;
using Microsoft.Data.SqlClient;

namespace LoghanAPI.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Kelompok>,KelompokRepository>();
            services.AddScoped<IRepository<KategoriLaporan>,KategoriLaporanRepository>();
            services.AddScoped<IRepository<Application>,ApplicationRepository>();
            services.AddScoped<IRepository<StatusLaporan>,StatusLaporanRepository>();
            services.AddScoped<IRepository<StatusPegawai>,StatusPegawaiRepository>();
            services.AddScoped<IRepository<Jabatan>,JabatanRepository>();

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUnitRepository,UnitRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<ILogApprovalRepository,LogApprovalRepository>();
            services.AddScoped<IAttachmentRepository,AttachmentRepository>();
            services.AddScoped<ILaporanHarianRepository,LaporanHarianRepository>();
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddScoped<PasswordServices>();
            services.AddScoped<JwtServices>();
            services.AddScoped<SqlConnection>();
            services.AddScoped<QueryServices>();
            return services;
        }
    }
}
