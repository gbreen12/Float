using Float.Models;
using Float.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Float.Test
{
    [TestClass]
    public class PeopleTest
    {
        private readonly IPeopleServiceV3 _peopleService;
        public PeopleTest()
        {
            _peopleService = new PeopleServiceV3();
        }

        [TestMethod]
        public void GetPeopleTest()
        {
            var people = _peopleService.GetCollection();

            Assert.IsNotNull(people);
            Assert.IsTrue(people.Count() >= 1);
        }

        [TestMethod]
        public void GetPeopleLimit1Test()
        {
            var people = _peopleService.GetCollection(1);

            Assert.IsNotNull(people);
            Assert.IsTrue(people.Count() == 1);
        }

        [TestMethod]
        public void GetPeoplePaginatedTest()
        {
            var people = _peopleService.GetCollection(1, 1);

            Assert.IsNotNull(people);
            Assert.IsTrue(people.Count() == 1);
        }

        [TestMethod]
        public void GetPersonTest()
        {
            var person = _peopleService.GetCollection(1).Single();
            person = _peopleService.GetInstance(person.ID);

            Assert.IsNotNull(person);
        }

        [TestMethod]
        public void CreatePersonTest()
        {
            var now = DateTime.Now;
            var newPerson = new Person
            {
                Active = true,
                AutoEmail = true,
                Contractor = true,
                Department = new Department
                {
                    DepartmentId = TestConstants.DepartmentId,
                    Name = TestConstants.DepartmentName
                },
                Email = "unit@test.float",
                EmployeeType = EmployeeType.PartTime,
                JobTitle = "Title",
                EndDate = now.AddDays(1),
                Name = "Unit Test User",
                NonWorkDays = new List<WeekDay> { WeekDay.Sunday, WeekDay.Saturday, WeekDay.Wednesday },
                Notes = "A note",
                StartDate = now,
                Tags = new List<PersonTag>
                {
                    new PersonTag
                    {
                        Name = "Tag 1",
                        Type = TagType.Gray
                    },
                    new PersonTag
                    {
                        Name = "Tag 2",
                        Type = TagType.Yellow
                    },
                    new PersonTag
                    {
                        Name = "Tag 3",
                        Type = TagType.Green
                    }
                },
                WorkDayHours = 5.5m
            };

            try
            {
                newPerson = _peopleService.Create(newPerson);

                Assert.IsNotNull(newPerson);
                Assert.IsTrue(newPerson.Active);
                Assert.IsTrue(newPerson.AutoEmail);
                Assert.IsTrue(newPerson.Contractor);
                Assert.IsNotNull(newPerson.Department);
                Assert.AreEqual(TestConstants.DepartmentName, newPerson.Department.Name);
                Assert.AreEqual("unit@test.float", newPerson.Email);
                Assert.AreEqual(EmployeeType.PartTime, newPerson.EmployeeType);
                Assert.AreEqual("Title", newPerson.JobTitle);
                Assert.IsNotNull(newPerson.EndDate);
                Assert.AreEqual("Unit Test User", newPerson.Name);
                Assert.IsNotNull(newPerson.NonWorkDays);
                Assert.IsTrue(newPerson.NonWorkDays.Contains(WeekDay.Sunday));
                Assert.IsTrue(newPerson.NonWorkDays.Contains(WeekDay.Saturday));
                Assert.IsTrue(newPerson.NonWorkDays.Contains(WeekDay.Wednesday));
                Assert.AreEqual("A note", newPerson.Notes);
                Assert.IsNotNull(newPerson.StartDate);
                Assert.IsNotNull(newPerson.Tags);
                Assert.IsTrue(newPerson.Tags.Any(x => x.Name == "Tag 1" && x.Type == TagType.Gray));
                Assert.IsTrue(newPerson.Tags.Any(x => x.Name == "Tag 2" && x.Type == TagType.Yellow));
                Assert.IsTrue(newPerson.Tags.Any(x => x.Name == "Tag 3" && x.Type == TagType.Green));
                Assert.AreEqual(5.5m, newPerson.WorkDayHours);
            }
            finally
            {
                _peopleService.Delete(newPerson.ID);
            }
        }

        [TestMethod]
        public void CreatePersonSimpleTest()
        {
            var newPerson = new Person
            {
                Name = "Unit Test User"
            };

            try
            {
                newPerson = _peopleService.Create(newPerson);

                Assert.IsNotNull(newPerson);
                Assert.AreEqual("Unit Test User", newPerson.Name);
                Assert.IsFalse(newPerson.Active);
                Assert.IsTrue(newPerson.AutoEmail);
                Assert.IsFalse(newPerson.Contractor);
                Assert.IsNull(newPerson.Department);
                Assert.AreEqual(EmployeeType.FullTime, newPerson.EmployeeType);
                Assert.IsNull(newPerson.JobTitle);
                Assert.IsNull(newPerson.EndDate);
                Assert.IsNull(newPerson.NonWorkDays);
                Assert.IsNull(newPerson.Notes);
                Assert.IsNull(newPerson.StartDate);
                Assert.AreEqual(0, newPerson.Tags.Count);
            }
            finally
            {
                _peopleService.Delete(newPerson.ID);
            }
        }

        [TestMethod]
        public void UpdatePersonTest()
        {
            var now = DateTime.Now;
            var newPerson = new Person
            {
                Name = "Unit Test User"
            };

            try
            {
                newPerson = _peopleService.Create(newPerson);

                newPerson = new Person
                {
                    ID = newPerson.ID,
                    Active = true,
                    AutoEmail = true,
                    Contractor = true,
                    Department = new Department
                    {
                        DepartmentId = TestConstants.DepartmentId,
                        Name = TestConstants.DepartmentName
                    },
                    Email = "unit@test.float",
                    EmployeeType = EmployeeType.PartTime,
                    JobTitle = "Title",
                    EndDate = now.AddDays(1),
                    Name = "Unit Test User",
                    NonWorkDays = new List<WeekDay> { WeekDay.Sunday, WeekDay.Saturday, WeekDay.Wednesday },
                    Notes = "A note",
                    StartDate = now,
                    Tags = new List<PersonTag>
                {
                    new PersonTag
                    {
                        Name = "Tag 1",
                        Type = TagType.Gray
                    },
                    new PersonTag
                    {
                        Name = "Tag 2",
                        Type = TagType.Yellow
                    },
                    new PersonTag
                    {
                        Name = "Tag 3",
                        Type = TagType.Green
                    }
                },
                    WorkDayHours = 5.5m
                };

                newPerson = _peopleService.Update(newPerson.ID, newPerson);

                Assert.IsNotNull(newPerson);
                Assert.IsTrue(newPerson.Active);
                Assert.IsTrue(newPerson.AutoEmail);
                Assert.IsTrue(newPerson.Contractor);
                Assert.IsNotNull(newPerson.Department);
                Assert.AreEqual(TestConstants.DepartmentName, newPerson.Department.Name);
                Assert.AreEqual("unit@test.float", newPerson.Email);
                Assert.AreEqual(EmployeeType.PartTime, newPerson.EmployeeType);
                Assert.AreEqual("Title", newPerson.JobTitle);
                Assert.IsNotNull(newPerson.EndDate);
                Assert.AreEqual("Unit Test User", newPerson.Name);
                Assert.IsNotNull(newPerson.NonWorkDays);
                Assert.IsTrue(newPerson.NonWorkDays.Contains(WeekDay.Sunday));
                Assert.IsTrue(newPerson.NonWorkDays.Contains(WeekDay.Saturday));
                Assert.IsTrue(newPerson.NonWorkDays.Contains(WeekDay.Wednesday));
                Assert.AreEqual("A note", newPerson.Notes);
                Assert.IsNotNull(newPerson.StartDate);
                Assert.IsNotNull(newPerson.Tags);
                Assert.IsTrue(newPerson.Tags.Any(x => x.Name == "Tag 1" && x.Type == TagType.Gray));
                Assert.IsTrue(newPerson.Tags.Any(x => x.Name == "Tag 2" && x.Type == TagType.Yellow));
                Assert.IsTrue(newPerson.Tags.Any(x => x.Name == "Tag 3" && x.Type == TagType.Green));
                Assert.AreEqual(5.5m, newPerson.WorkDayHours);
            }
            finally
            {
                _peopleService.Delete(newPerson.ID);
            }
        }

        [TestMethod]
        public void DeletePersonTest()
        {
            var newPerson = new Person
            {
                Name = "Unit Test User"
            };

            newPerson = _peopleService.Create(newPerson);

            Assert.IsNotNull(newPerson);

            Assert.IsTrue(_peopleService.Delete(newPerson.ID));
        }
    }
}
