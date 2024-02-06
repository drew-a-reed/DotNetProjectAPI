using DotNetProjectAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetProjectAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetUser([FromRoute] string id)
		{
			var user = await _abApiDbContext.AspNetUsers.FirstOrDefaultAsync(x => x.Id == id);

			if (user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}
	}
}
