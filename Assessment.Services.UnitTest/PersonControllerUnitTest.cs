using Moq;
using NUnit.Framework;
using Assessment.BusinessEntity;
using Assessment.BusinessLogicLayer.interfaces;
using Assessment.Services.Controllers;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Assessment.Services.UnitTest
{
    public class PersonControllerUnitTest
    {
        public Mock<IPersonProcessor> mockPersonProcessor { get; private set; }
        public Mock<ILogger<PersonController>> mockLogger { get; private set; }

        [SetUp]
        public void Setup()
        {
            mockPersonProcessor = new Mock<IPersonProcessor>();
            mockLogger = new Mock<ILogger<PersonController>>();
        }

       

        [Test]
        public void TestPost()
        {
            //Arrange

            PersonBE expectedPerson = new PersonBE() { FirstName = "Hello", LastName = "Bangalore", CityName = "Bangalore", PhoneNumber = "123467890" };
            object mockPerson = mockPersonProcessor.Setup(p => p.Post(expectedPerson));
            //Act
            PersonController personController = new PersonController(mockPersonProcessor.Object, mockLogger.Object);
            personController.Post(expectedPerson);

            //Assert

           
            Assert.Pass();
        }
    }
}