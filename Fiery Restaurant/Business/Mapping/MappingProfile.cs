using AutoMapper;
using Domain.DTO;
using Domain.Entity;

namespace Business.Mapping
{
    public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			this.CreateMap<Product, ProductDto>().ReverseMap();
			//this.CreateMap<SupplierDTO, Supplier>();
		}
	}
}