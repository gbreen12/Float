using Float.Models;
using Float.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Float.Test
{
    [TestClass]
    public class TasksTest
    {
        IFloatTaskServiceV3 _taskService;
        public TasksTest()
        {
            _taskService = new FloatTaskServiceV3();
        }

        [TestMethod]
        public void GetTasksTest()
        {
            var tasks = _taskService.GetCollection(100);

            Assert.IsNotNull(tasks);
            Assert.IsTrue(tasks.Count() >= 1);
        }

        [TestMethod]
        public void GetTasksLimit1Test()
        {
            var tasks = _taskService.GetCollection(1);

            Assert.IsNotNull(tasks);
            Assert.IsTrue(tasks.Count() == 1);
        }

        [TestMethod]
        public void GetTasksPaginatedTest()
        {
            var tasks = _taskService.GetCollection(1, 1);

            Assert.IsNotNull(tasks);
            Assert.IsTrue(tasks.Count() == 1);
        }

        [TestMethod]
        public void GetTaskTest()
        {
            var task = _taskService.GetCollection(1).Single();
            task = _taskService.GetInstance(task.TaskId);

            Assert.IsNotNull(task);
        }

        [TestMethod]
        public void CreateTaskTest()
        {
            var now = DateTime.Now;
            var newTask = new FloatTask
            {
                EndDate = now,
                Hours = 5.5m,
                Name = "Unit Test Task",
                Notes = "A note",
                PeopleId = TestConstants.PersonId,
                Priority = true,
                ProjectId = TestConstants.ProjectId,
                RepeatEndDate = now.AddDays(1),
                RepeatState = RepeatState.Weekly,
                StartDate = now,
                StartTime = now
            };

            try
            {
                newTask = _taskService.Create(newTask);

                Assert.IsNotNull(newTask);
                Assert.IsNotNull(newTask.EndDate);
                Assert.AreEqual(5.5m, newTask.Hours);
                Assert.AreEqual("Unit Test Task", newTask.Name);
                Assert.AreEqual("A note", newTask.Notes);
                Assert.AreEqual(TestConstants.PersonId, newTask.PeopleId);
                Assert.IsTrue(newTask.Priority);
                Assert.AreEqual(TestConstants.ProjectId, newTask.ProjectId);
                //Assert.IsNotNull(newTask.RepeatEndDate);
                Assert.AreEqual(RepeatState.Weekly, newTask.RepeatState);
                Assert.IsNotNull(newTask.StartDate);
                Assert.IsNotNull(newTask.StartTime);
            }
            finally
            {
                _taskService.Delete(newTask.TaskId);
            }
        }

        [TestMethod]
        public void CreateTaskSimpleTest()
        {
            var now = DateTime.Now;
            var newTask = new FloatTask
            {
                ProjectId = TestConstants.ProjectId,
                StartDate = now,
                EndDate = now,
                Hours = 5.5m,
                PeopleId = TestConstants.PersonId
            };

            try
            {
                newTask = _taskService.Create(newTask);

                Assert.IsNotNull(newTask);
                Assert.IsNotNull(newTask.EndDate);
                Assert.AreEqual(5.5m, newTask.Hours);
                Assert.IsNull(newTask.Name);
                Assert.IsNull(newTask.Notes);
                Assert.AreEqual(TestConstants.PersonId, newTask.PeopleId);
                Assert.IsFalse(newTask.Priority);
                Assert.AreEqual(TestConstants.ProjectId, newTask.ProjectId);
                Assert.IsNull(newTask.RepeatEndDate);
                Assert.AreEqual(RepeatState.NoRepeat, newTask.RepeatState);
                Assert.IsNotNull(newTask.StartDate);
                Assert.IsNull(newTask.StartTime);
            }
            finally
            {
                _taskService.Delete(newTask.TaskId);
            }
        }

        [TestMethod]
        public void UpdateTaskTest()
        {
            var now = DateTime.Now;
            var newTask = new FloatTask
            {
                ProjectId = TestConstants.ProjectId,
                StartDate = now,
                EndDate = now,
                Hours = 5.5m,
                PeopleId = TestConstants.PersonId
            };

            try
            {
                newTask = _taskService.Create(newTask);

                Assert.IsNotNull(newTask);
                Assert.IsNotNull(newTask.EndDate);
                Assert.AreEqual(5.5m, newTask.Hours);
                Assert.IsNull(newTask.Name);
                Assert.IsNull(newTask.Notes);
                Assert.AreEqual(TestConstants.PersonId, newTask.PeopleId);
                Assert.IsFalse(newTask.Priority);
                Assert.AreEqual(TestConstants.ProjectId, newTask.ProjectId);
                Assert.IsNull(newTask.RepeatEndDate);
                Assert.AreEqual(RepeatState.NoRepeat, newTask.RepeatState);
                Assert.IsNotNull(newTask.StartDate);
                Assert.IsNull(newTask.StartTime);

                newTask = new FloatTask
                {
                    TaskId = newTask.TaskId,
                    EndDate = now,
                    Hours = 5.5m,
                    Name = "Unit Test Task",
                    Notes = "A note",
                    PeopleId = TestConstants.PersonId,
                    Priority = true,
                    ProjectId = TestConstants.ProjectId,
                    RepeatEndDate = now.AddDays(1),
                    RepeatState = RepeatState.Weekly,
                    StartDate = now,
                    StartTime = now
                };

                newTask = _taskService.Update(newTask.TaskId, newTask);

                Assert.IsNotNull(newTask);
                Assert.IsNotNull(newTask.EndDate);
                Assert.AreEqual(5.5m, newTask.Hours);
                Assert.AreEqual("Unit Test Task", newTask.Name);
                Assert.AreEqual("A note", newTask.Notes);
                Assert.AreEqual(TestConstants.PersonId, newTask.PeopleId);
                Assert.IsTrue(newTask.Priority);
                Assert.AreEqual(TestConstants.ProjectId, newTask.ProjectId);
                //Assert.IsNotNull(newTask.RepeatEndDate);
                Assert.AreEqual(RepeatState.Weekly, newTask.RepeatState);
                Assert.IsNotNull(newTask.StartDate);
                Assert.IsNotNull(newTask.StartTime);
            }
            finally
            {
                _taskService.Delete(newTask.TaskId);
            }
        }

        [TestMethod]
        public void DeleteTaskTest()
        {
            var now = DateTime.Now;
            var newTask = new FloatTask
            {
                ProjectId = TestConstants.ProjectId,
                StartDate = now,
                EndDate = now,
                Hours = 5.5m,
                PeopleId = TestConstants.PersonId
            };

            newTask = _taskService.Create(newTask);

            Assert.IsNotNull(newTask);

            Assert.IsTrue(_taskService.Delete(newTask.TaskId));
        }
    }
}
