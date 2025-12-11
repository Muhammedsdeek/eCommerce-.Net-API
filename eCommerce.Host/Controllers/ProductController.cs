using eCommerce._Application.DTOs.Product;
using eCommerce._Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Host.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController(IproductService Service) : ControllerBase
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

			return (Data!=null)? Ok(Data) : NotFound(Data);


		}

		[HttpPost("add")]

		public async Task<IActionResult> Add(CreateProduct createProduct)
		{


			if(!ModelState.IsValid)
				return BadRequest(ModelState);


			var  Result= await Service.AddAsync(createProduct);

			return Result.Success? Ok(Result) : BadRequest(Result);
					
			
		}



		[HttpPut("Update")]

		public async Task<IActionResult> Update(UpdateProduct Product)
		{


	
			if(!ModelState.IsValid)
				return BadRequest(ModelState);
			var Result = await Service.UpdateAsync(Product);

			return Result.Success ? Ok(Result) : BadRequest(Result);


		}


		[HttpDelete("Delete/{id}")]

		public async Task<IActionResult> Delete(Guid id)
		{

			var product= await Service.GetByIdAsync(id);
			if(product==null)
				return NotFound(product);


			var Result = await Service.DeleteAsync(id);


			return Result.Success ? Ok(Result) : BadRequest(Result);


		}


	}
}
