using AutoMapper;
using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Product;
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
	public class ProductService(Igeneric<Product> ProductInterface, IMapper mapper) : IproductService
	{
		public async Task<ServiceResponse> AddAsync(CreateProduct product)
		{


			var MappedData = mapper.Map<Product>(product);
			int Result = await ProductInterface.AddAsync(MappedData);

			if (Result > 0)
				return new ServiceResponse(true, "Product Added successfully.");

			return new ServiceResponse(false, "Product Added failed.");

		}

		public async Task<ServiceResponse> DeleteAsync(Guid id)
		{
			

			var Result= await ProductInterface.DeleteAsync(id);

			if (Result > 0)
				return new ServiceResponse(true, "Product deleted successfully.");

			return new ServiceResponse(false, "Product deletion failed.");

		}

		public async Task<IEnumerable<GetProduct>> GetAllAsync()
		{
			
			 var RawData=await ProductInterface.GetAllAsync();


			if (!RawData.Any())
				return [];

		
			return mapper.Map<IEnumerable<GetProduct>>(RawData);
		}

		public async Task<GetProduct> GetByIdAsync(Guid id)
		{
			
			var rawData=  await  ProductInterface.GetByIdAsync(id);

			if (rawData == null)
				return new GetProduct();

			return mapper.Map<GetProduct>(rawData);
		}

		public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
		{

			var MappedData= mapper.Map<Product>(product);
			int Result = await ProductInterface.UpdateAsync(MappedData);

			if(Result>0)
			 return new ServiceResponse(true, "Product Updated successfully");


			return new ServiceResponse(true, "Product Updated failed");

		}
	}
}
