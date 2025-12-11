using eCommerce._Application.DTOs.Category;
using eCommerce._Application.DTOs.Product;
using eCommerce._Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Host.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController(ICategoryService Service)  : ControllerBase
	{



		[HttpGet("all")]

		public async Task<IActionResult> GetAll()
		{



			var Data = await Service.GetAllAsync();

			return (Data.Any()) ? Ok(Data) : NotFound(Data);


		}
		[HttpGet("single/{id}")]

		public async Task<IActionResult> Getsingle(Guid id)
		{



			var Data = await Service.GetByIdAsync(id);

			return (Data != null) ? Ok(Data) : NotFound(Data);


		}

		[HttpPost("add")]

		public async Task<IActionResult> Add(CreateCategory CreateCategory)
		{


			if (!ModelState.IsValid)
				return BadRequest(ModelState);


			var Result = await Service.AddAsync(CreateCategory);

			return Result.Success ? Ok(Result) : BadRequest(Result);


		}



		[HttpPut("Update")]

		public async Task<IActionResult> Update(UpdateCategory Category)
		{



			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var Result = await Service.UpdateAsync(Category);

			return Result.Success ? Ok(Result) : BadRequest(Result);


		}


		[HttpDelete("Delete/{id}")]

		public async Task<IActionResult> Delete(Guid id)
		{

			var product = await Service.GetByIdAsync(id);
			if (product == null)
				return NotFound(product);


			var Result = await Service.DeleteAsync(id);


			return Result.Success ? Ok(Result) : BadRequest(Result);


		}
	}
}
