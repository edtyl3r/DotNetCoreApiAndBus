namespace DotNetCoreApi.Infrastructure.Exceptions
{
    using System;

    internal class ConfigurationSectionMissingException : Exception
    {
        public ConfigurationSectionMissingException(string sectionPath)
            : base($"Could not find configuration section {sectionPath}")
        {
        }
    }
}
