using System;

public static class Config
{
    public static readonly string DbConnectionString = "Server=localhost\\SQLEXPRESS;Database=Team3;Trusted_Connection=True;TrustServerCertificate=True;";

    static Config()
    {
        if (string.IsNullOrEmpty(DbConnectionString))
        {
            throw new InvalidOperationException("DATABASE_CONNECTION_STRING environment variable is not set.");
        }
    }
}
