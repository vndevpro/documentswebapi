namespace GdNetDataStoreRavenDb
{
    public class RavenDbSettings
    {
        public string[] Urls { get; set; } = Array.Empty<string>();
        public string Database { get; set; } = string.Empty;
        public string CertificatePath { get; set; } = string.Empty;
        public string CertificateBase64 { get; set; } = string.Empty;
    }
}
