using DataAccessLayer.DataAccessLayer;
using DataAccessLayer.Repository.Interface;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Implemetation
{
	public class SupplierRepository : ISupplier
	{
		private SupplierDBContext db = new SupplierDBContext();


		public bool AddNewSupplier(Supplier supplier)
		{
			db.Suppliers.Add(supplier);
			db.SaveChanges();
			return true;

		}


		public Supplier GetSupplier(Guid supplierId)
		{
			try
			{
				return db.Suppliers.Find(supplierId);

			}
			catch
			{
				return new Supplier();
			}

		}

		public List<Supplier> GetSuppliers()
		{
			try
			{
				return db.Suppliers.ToList();
			}
			catch
			{
				return new List<Supplier>();

			}
		}
	}
}