using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{

	public interface ISupplier
	{
		public bool AddNewSupplier(Supplier supplier);
		public Supplier GetSupplier(Guid supplierId);
		public List<Supplier> GetSuppliers();

	}
}
	

