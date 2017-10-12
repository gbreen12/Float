using System.Configuration;

namespace Float.Test
{
    public static class TestConstants
    {
        public static int DepartmentId => int.Parse(ConfigurationManager.AppSettings["DepartmentId"]);
        public static string DepartmentName => ConfigurationManager.AppSettings["DepartmentName"];
        public static int ClientId => int.Parse(ConfigurationManager.AppSettings["ClientId"]);
        public static int ProjectManagerId => int.Parse(ConfigurationManager.AppSettings["ProjectManagerId"]);
        public static int PersonId => int.Parse(ConfigurationManager.AppSettings["PersonId"]);
        public static int ProjectId => int.Parse(ConfigurationManager.AppSettings["ProjectId"]);
    }
}
