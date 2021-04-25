using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApi.Models
{
	public class IdentityContext:DbContext
	{
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<User_Role> UserRoles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				new User { Id=1,Username="admin",Email="admin@gmail.com",Password="123"  },
				new User { Id = 2, Username = "Zyad", Email = "zyad.tarek175@gmail.com", Password = "456" }
				);
			modelBuilder.Entity<Role>().HasData(
				new Role { Id=1,Name="user" },
				new Role { Id=2,Name="admin" }
				);
			modelBuilder.Entity<User_Role>().HasData(
				new User_Role { Id = 1, UserId= 1,RoleId=2 },
				new User_Role { Id = 2, UserId= 2,RoleId=1 }
	);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=IdentityApi;Trusted_Connection=True;MultipleActiveResultSets=true");
		}
	}

}
