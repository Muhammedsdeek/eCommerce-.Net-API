using AutoMapper;
using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Category;
using eCommerce._Application.Services.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Implementations
{
	public class CategoryService(Igeneric<Category> categoryService,IMapper mapper) : ICategoryService
	{
		public async Task<ServiceResponse> AddAsync(CreateCategory category)
		{

			var MappedData = mapper.Map<Category>(category);


			  int Result=await categoryService.AddAsync(MappedData);

			if(Result>0)
				return new ServiceResponse(true, "Category Added successfully.");

			return new ServiceResponse(false, "Category Added failed.");

		}
		public async Task<ServiceResponse> DeleteAsync(Guid id)
		{
			

		  int Result= await categoryService.DeleteAsync(id);

			if (Result > 0)
				return new ServiceResponse(true, "Category Deleted successfully.");

			return new ServiceResponse(false, "Category Deleted failed.");
		}

		public async Task<IEnumerable<GetCategory>> GetAllAsync()
		{
			
			 

			 var Data= await categoryService.GetAllAsync();
			if (!Data.Any())
				return [];

			return mapper.Map<IEnumerable<GetCategory>>(Data);

		}

		public async Task<GetCategory> GetByIdAsync(Guid id)
		{
			
			 var Data= await categoryService.GetByIdAsync(id);
			if (Data == null)
				return null;

			return mapper.Map<GetCategory>(Data);

		}

		public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
		{
			

			var mappedData=mapper.Map<Category>(category);
			var Result = await categoryService.UpdateAsync(mappedData);

			if (Result > 0)
				return new ServiceResponse(true, "Category Updated successfully.");

			return new ServiceResponse(false, "Category Updated failed.");
		}
	}
}
