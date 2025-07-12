namespace GdNetDataStoreRavenDb
{
    public class RavenSettings
    {
        public string[] Urls { get; set; } = Array.Empty<string>();
        public string DatabaseName { get; set; } = string.Empty;
        public string CertFilePath { get; set; } = string.Empty;
        public string CertPassword { get; set; } = string.Empty;
        public string CertBase64 { get; set; } = string.Empty;
    }
}
