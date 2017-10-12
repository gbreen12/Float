using Float.Models;
using Float.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Float.Test
{
    [TestClass]
    public class ProjectsTest
    {
        IProjectServiceV3 _projectService;
        public ProjectsTest()
        {
            _projectService = new ProjectServiceV3();
        }

        [TestMethod]
        public void GetProjectsTest()
        {
            var projects = _projectService.GetCollection();

            Assert.IsNotNull(projects);
            Assert.IsTrue(projects.Count() >= 1);
        }

        [TestMethod]
        public void GetProjectsLimit1Test()
        {
            var projects = _projectService.GetCollection(1);

            Assert.IsNotNull(projects);
            Assert.IsTrue(projects.Count() == 1);
        }

        [TestMethod]
        public void GetProjectsPaginatedTest()
        {
            var projects = _projectService.GetCollection(1, 1);

            Assert.IsNotNull(projects);
            Assert.IsTrue(projects.Count() == 1);
        }

        [TestMethod]
        public void GetProjectTest()
        {
            var project = _projectService.GetCollection(1).Single();
            project = _projectService.GetInstance(project.ProjectId);

            Assert.IsNotNull(project);
        }

        [TestMethod]
        public void CreateProjectTest()
        {
            var newProject = new Project
            {
                Active = true,
                AllPmsSchedule = true,
                ClientId = TestConstants.ClientId,
                Color = "0095D8",
                Notes = "A note",
                Name = "Unit Test Client",
                NonBillable = true,
                ProjectManager = TestConstants.ProjectManagerId,
                Tags = new List<string> { "Tag 1", "Tag 2" },
                Tentative = true
            };

            try
            {
                newProject = _projectService.Create(newProject);

                Assert.IsNotNull(newProject);
                Assert.IsTrue(newProject.Active);
                Assert.IsTrue(newProject.AllPmsSchedule);
                Assert.AreEqual(TestConstants.ClientId, newProject.ClientId);
                Assert.AreEqual("0095D8", newProject.Color);
                Assert.AreEqual("A note", newProject.Notes);
                Assert.AreEqual("Unit Test Client", newProject.Name);
                Assert.IsTrue(newProject.NonBillable);
                Assert.AreEqual(TestConstants.ProjectManagerId, newProject.ProjectManager);
                Assert.IsNotNull(newProject.Tags);
                Assert.IsTrue(newProject.Tags.Contains("Tag 1"));
                Assert.IsTrue(newProject.Tags.Contains("Tag 2"));
                Assert.IsTrue(newProject.Tentative);
            }
            finally
            {
                _projectService.Delete(newProject.ProjectId);
            }
        }

        [TestMethod]
        public void CreatePersonSimpleTest()
        {
            var newProject = new Project
            {
                Name = "Unit Test Client"
            };

            try
            {
                newProject = _projectService.Create(newProject);

                Assert.IsNotNull(newProject);
                Assert.IsFalse(newProject.Active);
                Assert.IsFalse(newProject.AllPmsSchedule);
                Assert.IsNull(newProject.ClientId);
                Assert.IsNull(newProject.Color);
                Assert.IsNull(newProject.Notes);
                Assert.AreEqual("Unit Test Client", newProject.Name);
                Assert.IsFalse(newProject.NonBillable);
                Assert.IsNull(newProject.ProjectManager);
                Assert.AreEqual(0, newProject.Tags.Count);
                Assert.IsFalse(newProject.Tentative);
            }
            finally
            {
                _projectService.Delete(newProject.ProjectId);
            }
        }

        [TestMethod]
        public void UpdateProjectTest()
        {
            var newProject = new Project
            {
                Name = "Unit Test Client"
            };

            try
            {
                newProject = _projectService.Create(newProject);

                Assert.IsNotNull(newProject);
                Assert.IsFalse(newProject.Active);
                Assert.IsFalse(newProject.AllPmsSchedule);
                Assert.IsNull(newProject.ClientId);
                Assert.IsNull(newProject.Color);
                Assert.IsNull(newProject.Notes);
                Assert.AreEqual("Unit Test Client", newProject.Name);
                Assert.IsFalse(newProject.NonBillable);
                Assert.IsNull(newProject.ProjectManager);
                Assert.AreEqual(0, newProject.Tags.Count);
                Assert.IsFalse(newProject.Tentative);

                newProject = new Project
                {
                    ProjectId = newProject.ProjectId,
                    Active = true,
                    AllPmsSchedule = true,
                    ClientId = TestConstants.ClientId,
                    Color = "0095D8",
                    Notes = "A note",
                    Name = "Unit Test Client",
                    NonBillable = true,
                    ProjectManager = TestConstants.ProjectManagerId,
                    Tags = new List<string> { "Tag 1", "Tag 2" },
                    Tentative = true
                };

                newProject = _projectService.Update(newProject.ProjectId, newProject);

                Assert.IsNotNull(newProject);
                Assert.IsTrue(newProject.Active);
                Assert.IsTrue(newProject.AllPmsSchedule);
                Assert.AreEqual(TestConstants.ClientId, newProject.ClientId);
                Assert.AreEqual("0095D8", newProject.Color);
                Assert.AreEqual("A note", newProject.Notes);
                Assert.AreEqual("Unit Test Client", newProject.Name);
                Assert.IsTrue(newProject.NonBillable);
                Assert.AreEqual(TestConstants.ProjectManagerId, newProject.ProjectManager);
                Assert.IsNotNull(newProject.Tags);
                Assert.AreEqual(0, newProject.Tags.Count);
                Assert.IsTrue(newProject.Tentative);
            }
            finally
            {
                _projectService.Delete(newProject.ProjectId);
            }
        }

        [TestMethod]
        public void DeleteProjectTest()
        {
            var newProject = new Project
            {
                Name = "Unit Test Client"
            };

            newProject = _projectService.Create(newProject);

            Assert.IsNotNull(newProject);

            Assert.IsTrue(_projectService.Delete(newProject.ProjectId));
        }
    }
}
