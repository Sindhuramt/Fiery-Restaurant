using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Service.Interfaces;
using Moq;
using Domain.DTO;
using Xunit;
using Business.Service.implement;
using Domain.Entity;
using System.Net;

namespace API.Controllers.Tests
{
	[TestClass()]
	public class SupplierControllerTests
	{
		//Get
		[Fact]
		public void Get_OnSuccess_ReturnStatusCode200()
		{
			//Arrangeh
			var MockSupplierService = new Mock<ISuppilerServices>();

			MockSupplierService
				.Setup(service => service.GetSuppliers())
				.Returns(new List<SupplierDTO>());

			var controller = new SupplierController(MockSupplierService.Object);

			//Act
			var result = controller.Get();

			//Assert
			MockSupplierService.Verify(service => service.GetSuppliers(), Times.Once());

		}

		[Fact]
		public void Task_Get_OnSuccess_ReturnListOfSupplier()
		{
			var MockSupplierService = new Mock<ISuppilerServices>();
			MockSupplierService
				.Setup(service => service.GetSuppliers())
				.Returns(new List<SupplierDTO>()
				{
					new()
					{
						SupplierID= new Guid(),
						SupplierName= "string",
						BuisnessName= "string",
						LicenseNumber= "string",
						LicesnseDate= DateTime.Now,
						StreetAddress= "string",
						City= "string",
						State= "string",
						Country= "string",
						ZipCode= 0,
						Latitude= 0,
						Longitude= 0,
						DateCreated= DateTime.Now,
						LastModifiedDate= DateTime.Now,
						LastModifiedBy= "string",
						Is_Active = true
					}
				});
			var controller = new SupplierController(MockSupplierService.Object);
			var result = controller.Get();
			MockSupplierService.Verify(service => service.GetSuppliers(), Times.Once());
		}

		//Add
		[Fact]
		public void Task_Add_ValidData_Return_OkResult()
		{
			//Arrange  
			var MockSupplierService = new Mock<ISuppilerServices>();

			var post = new SupplierDTO()
			{
				SupplierID = new Guid(),
				SupplierName = "string",
				BuisnessName = "string",
				LicenseNumber = "string",
				LicesnseDate = DateTime.Now,
				StreetAddress = "string",
				City = "string",
				State = "string",
				Country = "string",
				ZipCode = 0,
				Latitude = 0,
				Longitude = 0,
				DateCreated = DateTime.Now,
				LastModifiedDate = DateTime.Now,
				LastModifiedBy = "string",
				Is_Active = true
			};

			//Act  
			var controller = new SupplierController(MockSupplierService.Object);
			var result = controller.Post(post);
			MockSupplierService.Verify(service => service.AddNewSupplier(post), Times.Once());
		}

		//GetbyId
		[Fact]
		public void Task_GetSupplierById_Return_FoundSupplierResultOK()
		{
			//Arrange  
			var MockSupplierService = new Mock<ISuppilerServices>();

			var post = new SupplierDTO()
			{
				SupplierID = new Guid(),
				SupplierName = "string",
				BuisnessName = "string",
				LicenseNumber = "string",
				LicesnseDate = DateTime.Now,
				StreetAddress = "string",
				City = "string",
				State = "string",
				Country = "string",
				ZipCode = 0,
				Latitude = 0,
				Longitude = 0,
				DateCreated = DateTime.Now,
				LastModifiedDate = DateTime.Now,
				LastModifiedBy = "string",
				Is_Active = true
			};

			//Act  
			var sut = new SupplierController(MockSupplierService.Object);
			var result = sut.Get(new Guid());
			MockSupplierService.Verify(service => service.GetSupplier(new Guid()), Times.Once());
		}

	}
}