using Float.Models;
using Float.Services;

namespace FloatTest
{
    class Program
    {
        private static readonly PeopleServiceV3 _peopleService = new PeopleServiceV3();
        private static readonly ProjectServiceV3 _projectService = new ProjectServiceV3();
        static void Main(string[] args)
        {
            //GetPeople();
            //CreatePerson();
            GetProjects();
        }

        private static void GetPeople()
        {
            var people = _peopleService.GetCollection();
        }

        private static void CreatePerson()
        {
            var newPerson = new Person
            {
                Name = "A name",
                Active = true
            };

            var createdPerson = _peopleService.Create(newPerson);

            createdPerson = _peopleService.Delete(createdPerson.PeopleId);
        }

        private static void GetProjects()
        {
            var projects = _projectService.GetCollection();
        }
    }
}
