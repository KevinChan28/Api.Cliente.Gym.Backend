namespace Aplication.Client.API
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class Image
    {
        public string PathToSave { get; set; }
        public string DefaultEncodedBase64 { get; set; }
    }

    public class ServerMode
    {
        public bool IsOnlineServer { get; set; }
    }

}
