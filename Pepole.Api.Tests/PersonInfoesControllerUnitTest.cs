using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using People.Data.Entities;
using PeopleAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using Microsoft.EntityFrameworkCore.Update;

namespace Pepole.Api.Tests
{
	public class PersonInfoesControllerUnitTest
	{

		public Task<PersonInfo> GetTestPersonInfoAsync()
		{
			return Task.Run(() => new PersonInfo()
			{
				IdPeople = 1,
				Surname = "Ivanov",
				Name = "Ivan",
				Patronymic = "Ivanovich",
				Gender = "f",
				DateBirthday = DateTime.MinValue,
				DateDeath = DateTime.MaxValue,
				IdCountryBirthday = 100,
				IdRegionBirthday = 200,
				IdTownBirthday = 300,
				DatetimeAdded = DateTime.MaxValue,
				IdPeopleNavigation = new Person(),
				IdCountryBirthdayNavigation = new Country(),
				IdRegionBirthdayNavigation = new Region(),
				IdTownBirthdayNavigation = new Town()
			});
		}

		[Fact]
		public async Task GetPersonInfo_return_PersonInfo_wrapped_OkObjectResault_When_Success()
		{
			//Arrange
			var trueId = 1;
			var testPersonInfo = GetTestPersonInfoAsync();
			var _contextMock = new Mock<PeopleDWContext>();
			_contextMock
				.Setup(context => context.PersonInfo.FindAsync(It.IsAny<long>()))
				.Returns(testPersonInfo);

			//Act
			var personInfoesController = new PersonInfoesController(_contextMock.Object);
			var actionResult = await personInfoesController.GetPersonInfo(trueId);

			//Assert
			var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
			Assert.IsAssignableFrom<PersonInfo>(okObjectResult.Value);

		}

		[Fact]
		public async Task GetPersonInfo_returned_Id_people_equals_Id_people_found_When_Success()
		{
			//Arrange
			var trueId = 1;
			var testPersonInfo = GetTestPersonInfoAsync();
			var _contextMock = new Mock<PeopleDWContext>();
			_contextMock
				.Setup(context => context.PersonInfo.FindAsync(It.IsAny<long>()))
				.Returns(testPersonInfo);

			//Act
			var personInfoesController = new PersonInfoesController(_contextMock.Object);
			var returnPersonInfo = 
				(PersonInfo)
				((OkObjectResult)await personInfoesController.GetPersonInfo(trueId))
				.Value;

			//Assert
			Assert.True(testPersonInfo.Result.IdPeople.Equals(returnPersonInfo.IdPeople));

		}

		[Fact]
		public async Task GetPersonInfo_NotFoundResult_404_When_PersonInfo_not_found()
		{
			//Arrange
			var fakeId = 88;
			var _contextMock = new Mock<PeopleDWContext>();
			_contextMock
				.Setup(context => context.PersonInfo.FindAsync(It.IsAny<long>()))
				.Returns(Task.FromResult((PersonInfo)null));

			//Act
			var personInfoesController = new PersonInfoesController(_contextMock.Object);
			var actionResult = await personInfoesController.GetPersonInfo(fakeId);

			//Assert
			var notFoundResult = Assert.IsType<NotFoundResult>(actionResult);
			Assert.Equal(404, notFoundResult.StatusCode);

		}

		//[Theory]
		[Fact]
		public async Task GetPersonInfo_BadRequestObjectResult_400_When_ModelState_not_valid()
		{
			//Arrange
			var anyId = 1;
			var _contextMock = new Mock<PeopleDWContext>();
			//_contextMock
			//	.Setup(context => context.PersonInfo.FindAsync(It.IsAny<long>()))
			//	.Returns(GetTestPersonInfoAsync());

			//Act
			var personInfoesController = new PersonInfoesController(_contextMock.Object);
			personInfoesController.ModelState.AddModelError("Key", "Test_Error");
			var actionResult = await personInfoesController.GetPersonInfo(anyId);

			//Assert
			var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(actionResult);
			Assert.Equal(400, badRequestObjectResult.StatusCode);

		}
		/*
		//[Fact]
		public async Task PutPersonInfo_Call_SaveChangesAsync_When_Success()
		{
			//Arrange
			var testPersonInfo = GetTestPersonInfoAsync().Result;
			var trueId = testPersonInfo.IdPeople;
			var _contextMock = new Mock<PeopleDWContext>();
			_contextMock
				.Setup(context => context.SaveChangesAsync(It.IsAny<CancellationToken>()));
			//_contextMock.Setup(context => context.Entry(testPersonInfo)).Returns(new Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry(new Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry());
			_contextMock.Setup< Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<PersonInfo>>(context => context.Entry(testPersonInfo) );	//== context.en new Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<PersonInfo>()
		//Act
		var personInfoesController = new PersonInfoesController(_contextMock.Object);
			await personInfoesController.PutPersonInfo(trueId, testPersonInfo);

			//Assert
			_contextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()));

		}
		//*/
		[Fact]
		public async Task PutPersonInfo_BadRequestObjectResult_400_When_ModelState_not_valid()
		{
			//Arrange
			var testPersonInfo = GetTestPersonInfoAsync().Result;
			var anyId = testPersonInfo.IdPeople;
			var _contextMock = new Mock<PeopleDWContext>();

			//Act
			var personInfoesController = new PersonInfoesController(_contextMock.Object);
			personInfoesController.ModelState.AddModelError("Key", "Test_Error");
			var actionResult = await personInfoesController
				.PutPersonInfo(anyId, testPersonInfo);

			//Assert
			var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(actionResult);
			Assert.Equal(400, badRequestObjectResult.StatusCode);

		}

		[Fact]
		public async Task PutPersonInfo_BadRequestResult_400_When_Id_not_equal_PersonInfo_Id()
		{
			//Arrange
			var testPersonInfo = GetTestPersonInfoAsync().Result;
			var otherId = 0;
			var _contextMock = new Mock<PeopleDWContext>();

			//Act
			var personInfoesController = new PersonInfoesController(_contextMock.Object);
			var actionResult = await personInfoesController
				.PutPersonInfo(otherId, testPersonInfo);

			//Assert
			var badRequestResult = Assert.IsType<BadRequestResult>(actionResult);
			Assert.Equal(400, badRequestResult.StatusCode);

		}
		
		[Fact]
		public async Task PutPersonInfo_NotFoundResult_404_When_Id_not_equal_PersonInfo_Id()
		//System.NotSupportedException : Unsupported expression: ... => ....AnyAsync<PersonInfo>(It.IsAny<Expression<Func<PersonInfo, bool>>>(), It.IsAny<CancellationToken>())
		//Extension methods(here: EntityFrameworkQueryableExtensions.AnyAsync) may not be used in setup / verification expressions.
		{
			//Arrange
			var testPersonInfo = GetTestPersonInfoAsync().Result;
			var trueId = testPersonInfo.IdPeople;
			var _contextMock = new Mock<PeopleDWContext>();
			_contextMock
				.Setup(context => context.SaveChangesAsync(It.IsAny<CancellationToken>()))
				.Throws(new DbUpdateConcurrencyException("TestException", new List<IUpdateEntry>() { Mock.Of<IUpdateEntry>() }));

			_contextMock
				.Setup(context => context.PersonInfo.AnyAsync(It.IsAny<Expression<Func<PersonInfo, bool>>>(), It.IsAny<CancellationToken>()))
			//	 .Callback<Expression<Func<PersonInfo, bool>>>(
			//expression =>
			//{
			//	var func = expression.Compile();
			//	//foo = func(new CustomerEntity() { Email = "foo@gmail.com" });
			//})
		.Returns(() => Task.FromResult(true));

			//Act
			var personInfoesController = new PersonInfoesController(_contextMock.Object);
			var actionResult = await personInfoesController
				.PutPersonInfo(trueId, testPersonInfo);

			//Assert
			var notFoundResult = Assert.IsType<NotFoundResult>(actionResult);
			Assert.Equal(404, notFoundResult.StatusCode);

		}
	}
}
