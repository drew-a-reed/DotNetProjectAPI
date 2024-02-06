using DotNetProjectAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetProjectAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : Controller
	{
		private readonly ApiDbContext _abApiDbContext;

		public UsersController(ApiDbContext dbContext)
		{
			_abApiDbContext = dbContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await _abApiDbContext.AspNetUsers.ToListAsync();

			return Ok(users);
		}
	}
}
