namespace DemoAdoCrud; 

public static class ConnectionString
{
    public static string connection_string = "Server=localhost\\SQLEXPRESS;Database=DemoADo;Trusted_Connection=True; TrustServerCertificate=True ";

    public static string GotconnectionString()
    {
        return connection_string;
    }
}
