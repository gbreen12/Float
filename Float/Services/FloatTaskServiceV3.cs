using Float.Models;

namespace Float.Services
{
    public class FloatTaskServiceV3 : FloatServiceV3<FloatTask>, IFloatTaskServiceV3
    {
        protected override string BaseEndpoint => "tasks";
    }

    public interface IFloatTaskServiceV3 : IFloatServiceV3<FloatTask>
    {
    }
}
