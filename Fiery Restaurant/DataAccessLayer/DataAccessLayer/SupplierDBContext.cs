using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace DataAccessLayer.DataAccessLayer
{
		public class SupplierDBContext : DbContext
		{
			protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			{
				optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=supplierFR;Integrated Security=True;Pooling=False");
				//optionsBuilder.UseSqlServer("Provider = SQLOLEDB.1; Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = msdb");

			}
			public DbSet<Supplier> Suppliers { get; set; }
			public DbSet<Address> Address { get; set; }
			public DbSet<Business> Business { get; set; }
		}
	}



