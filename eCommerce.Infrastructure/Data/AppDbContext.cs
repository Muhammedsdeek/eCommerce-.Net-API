using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Entities.Cart;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Data
{
	public class AppDbContext :  IdentityDbContext<AppUser>         // DbContext(options)
	{

		public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }	
		
		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<RefreshToken> RefreshTokens { get; set; }


		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<Achive> Achives { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{



			builder.Entity<PaymentMethod>().
			   HasData(

				new PaymentMethod
				{
					ID = Guid.NewGuid(),
					Name = "Credet Cart",
				
				}

				
			   );


			builder.Entity<IdentityRole>().
				HasData(

				 new IdentityRole
				{
					Id=Guid.NewGuid().ToString(),
					Name = "Admin",
					NormalizedName = "ADMIN"
				},

				 new IdentityRole
				{
					 Id = Guid.NewGuid().ToString(),
					Name = "User",
					NormalizedName = "USER"
				}
				);
			base.OnModelCreating(builder);
		}


	}
}
