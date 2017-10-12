using Float.Models;

namespace Float.Services
{
    public class PeopleServiceV3 : FloatServiceV3<Person>, IPeopleServiceV3
    {
        protected override string BaseEndpoint => "people";
    }

    public interface IPeopleServiceV3 : IFloatServiceV3<Person>
    {
    }
}
