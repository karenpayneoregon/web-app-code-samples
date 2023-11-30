using Configuration1.Models;
using Microsoft.Data.SqlClient;

namespace Configuration1.Classes;

public class ConnectionHelpers
{
    public static bool CheckConnectionString(ConnectionsConfiguration connections)
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new(connections.Development);
        if (sqlConnectionStringBuilder.DataSource != ".\\SQLEXPRESS")
        {
            return false;
        }

        if (!Equals(sqlConnectionStringBuilder.Encrypt, SqlConnectionEncryptOption.Optional))
        {
            return false;
        }

        // ensure the active environment is set
        if (string.IsNullOrEmpty(connections.ActiveEnvironment))
        {
            return false;
        }

        // do we have a proper environment
        if (!Enum.TryParse(connections.ActiveEnvironment, out ConnectionEnvironment _))
        {
            return false;
        }

        return true;
    }
}
