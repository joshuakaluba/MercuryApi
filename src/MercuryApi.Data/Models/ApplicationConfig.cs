using System;

namespace MercuryApi.Data.Models
{
    public static class ApplicationConfig
    {
        internal static string DatabaseHost
           = Environment.GetEnvironmentVariable
               ("MERCURY_API_DB_HOST", target: EnvironmentVariableTarget.Process);

        public static string Port
            = Environment.GetEnvironmentVariable
                ("MERCURY_API_APPLICATION_PORT", target: EnvironmentVariableTarget.Process);

        internal static string DatabaseName
            = Environment.GetEnvironmentVariable
                ("MERCURY_API_DB_NAME", target: EnvironmentVariableTarget.Process);

        internal static string DatabaseUser
            = Environment.GetEnvironmentVariable
                ("MERCURY_API_DB_USER", target: EnvironmentVariableTarget.Process);

        internal static string DatabasePassword
            = Environment.GetEnvironmentVariable
                ("MERCURY_API_DB_PASSWORD", target: EnvironmentVariableTarget.Process);
    }
}