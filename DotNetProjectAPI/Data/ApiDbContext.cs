//using DotNetProjectAPI.Models;

using DotNetProjectAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetProjectAPI.Data
{
	public class ApiDbContext : IdentityDbContext
	{

		public ApiDbContext(DbContextOptions options) : base(options) { }

		public DbSet<IdentityUser> AspNetUsers { get; set; }
	}
}
