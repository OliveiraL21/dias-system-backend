using Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace UserApplication.Context
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<Guid>, Guid>
    {
        DbSet<UsuarioEntity> usuarios { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext>options) : base (options) 
        {

        }

        protected async override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var admId = Guid.NewGuid();
            CustomIdentityUser  admin = new CustomIdentityUser()
            {
                Id = admId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin",
                NormalizedEmail = "admin",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = "d1f13107-9c43-4221-926d-6d0bdcf012b6",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123@!");

            builder.Entity<CustomIdentityUser>().HasData(admin);

            var roleAdmId = Guid.NewGuid();
            builder.Entity<IdentityRole<Guid>>().HasData(
                    new IdentityRole<Guid>
                    {
                        Id =roleAdmId,
                        Name = "admin",
                        NormalizedName = "ADMIN",
                    }
                );

            builder.Entity<IdentityRole<Guid>>().HasData(
              new IdentityRole<Guid>
              {
                  Id = Guid.NewGuid(),
                  Name = "regular",
                  NormalizedName = "REGULAR",
              }
          );

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                    new IdentityUserRole<Guid> { RoleId = roleAdmId, UserId = admId }
                );
        }
    }
}
