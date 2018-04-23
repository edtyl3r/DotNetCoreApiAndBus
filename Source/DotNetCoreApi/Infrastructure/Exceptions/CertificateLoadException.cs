namespace DotNetCoreApi.Infrastructure.Exceptions
{
    using System;

    internal class CertificateLoadException : Exception
    {
        public CertificateLoadException()
            : base("Could not load certificate")
        {
        }

        public CertificateLoadException(Exception e)
            : base("Could not load certificate", e)
        {
            
        }
    }
}