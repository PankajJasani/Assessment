using Moq;
using NUnit.Framework;
using Assessment.BusinessEntity;
using Assessment.BusinessLogicLayer.interfaces;
using Assessment.Services.Controllers;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;

namespace Assessment.Services.UnitTest
{
    public class PersonControllerUnitTest
    {
        public Mock<IPersonProcessor> mockPersonProcessor { get; private set; }
        public Mock<ILogger<PersonController>> mockLogger { get; private set; }
        public PersonController personController { get; private set; }

        [SetUp]
        public void Setup()
        {
            mockPersonProcessor = new Mock<IPersonProcessor>();
            mockLogger = new Mock<ILogger<PersonController>>();
            personController = new PersonController(mockPersonProcessor.Object, mockLogger.Object);
        }


        [Test]
        public void GetPeopleInformatin_WhenPeopleExists()
        {
            //Arrange
            List<PersonBE> expectedPeople = new List<PersonBE>()
            {
            new PersonBE(){ FirstName = "Hello", LastName = "Bangalore", CityName = "Bangalore", PhoneNumber = "123467890" },
            new PersonBE(){ FirstName = "Hello", LastName = "Bangalore", CityName = "Bangalore", PhoneNumber = "123467890" }
            };
            //int personId = 1;
            object mockPeople = mockPersonProcessor.Setup(p => p.Get()).Returns(expectedPeople);

            //Act           
            List<PersonBE> actualPeople = personController.Get().ToList();

            //Assert
            Assert.AreEqual(expectedPeople.Count, actualPeople.Count);
            for (int i = 0; i < actualPeople.Count; i++)
            {
                Assert.AreEqual(actualPeople[i].FirstName,expectedPeople[i].FirstName);
                Assert.AreEqual(actualPeople[i].LastName, expectedPeople[i].LastName);
                Assert.AreEqual(actualPeople[i].CityName, expectedPeople[i].CityName);
                Assert.AreEqual(actualPeople[i].PhoneNumber, expectedPeople[i].PhoneNumber);
            }
            Assert.Pass();

        }

        [Test]
        public void GetPersonInformatin_WhenPersonExists()
        {
            //Arrange
            PersonBE expectedPerson = new PersonBE() { FirstName = "Hello", LastName = "Bangalore", CityName = "Bangalore", PhoneNumber = "123467890" };
            int personId = 1;
            object mockPerson = mockPersonProcessor.Setup(p => p.Get(personId)).Returns(expectedPerson);

            //Act           
            PersonBE actualPerson = personController.Get(personId);

            //Assert
            Assert.AreEqual(actualPerson.FirstName, expectedPerson.FirstName);
            Assert.AreEqual(actualPerson.LastName, expectedPerson.LastName);
            Assert.AreEqual(actualPerson.CityName, expectedPerson.CityName);
            Assert.AreEqual(actualPerson.PhoneNumber, expectedPerson.PhoneNumber);
            mockLogger.Verify(x => x.LogInformation("Get Start {id}", personId));
            Assert.Pass();

        }

        [Test]
        public void GetPersonInformatin_WhenPersonDoesNotExists()
        {
            //Arrange
           // PersonBE expectedPerson = new PersonBE() { FirstName = "Hello", LastName = "Bangalore", CityName = "Bangalore", PhoneNumber = "123467890" };
            int personId = 0;
            object mockPerson = mockPersonProcessor.Setup(p => p.Get(personId)).Throws(new ArgumentException());

            //Act           
            

            //Assert
            Assert.Throws<ArgumentException>(() => personController.Get(personId)); 
           // mockLogger.Verify(x => x.LogInformation("Get Start {id}", personId));
            Assert.Pass();

        }


       


        [Test]
        public void TestPost()
        {
            //Arrange
            PersonBE expectedPerson = new PersonBE() { FirstName = "Hello", LastName = "Bangalore", CityName = "Bangalore", PhoneNumber = "123467890" };
            mockPersonProcessor.Setup(p => p.Post(expectedPerson)).Verifiable();

            //Act          
            

            //Assert           
            Assert.Pass();
        }
    }
}