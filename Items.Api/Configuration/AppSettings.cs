namespace Items.Api.Configuration;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; }
}

public class ConnectionStrings
{
    public string PostgreSqlConnection { get; set; }
}