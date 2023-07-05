using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWebApp.Entity.Models;
using DatabaseContext = ReactWebApp.Entity.Conf.DatabaseContext;

namespace ReactWebApp.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
	private readonly DatabaseContext _databaseContext;

	public CategoryController(DatabaseContext databaseContext)
	{
		_databaseContext = databaseContext;
	}
	
	[HttpGet]
	public async Task<ActionResult<List<Category>>> GetCategory()
	{
		return Ok(await _databaseContext.Categories.ToListAsync());
	}

	[HttpPost]
	public async Task<ActionResult<Category>> AddCategory(Category category)
	{
		_databaseContext.Categories.Add(category);
		await _databaseContext.SaveChangesAsync();
		return Ok(category);
	}
}