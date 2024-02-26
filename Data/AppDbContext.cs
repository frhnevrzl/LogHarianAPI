using LoghanAPI.Models.Logs;
using LoghanAPI.Models.Masters.Application;
using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Models.Masters.Status;
using LoghanAPI.Models.Masters.UserManagement;
using LoghanAPI.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LoghanAPI.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Kelompok> Kelompoks { get; set; }
        public DbSet<Jabatan> Jabatans { get; set; }
        public DbSet<StatusPegawai> StatusPegawais { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<KategoriLaporan> KategoriLaporans { get; set; }
        public DbSet<StatusLaporan> StatusLaporans { get; set; }
        public DbSet<LaporanHarian> LaporanHarians { get; set; }
        public DbSet<AttachmentLaporan> AttachmentLaporans { get; set; }
        public DbSet<LogApproval> LogApprovals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(b => b.Username)
                        .IsUnique();

            modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.Username, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRole)
                .HasForeignKey(ur => ur.Username);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRole)
                .HasForeignKey(ur => ur.RoleId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
