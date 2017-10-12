using Float.Models;

namespace Float.Services
{
    public class ProjectServiceV3 : FloatServiceV3<Project>, IProjectServiceV3
    {
        protected override string BaseEndpoint => "projects";
    }

    public interface IProjectServiceV3 : IFloatServiceV3<Project>
    {
    }
}
