using Dapper;
using Microsoft.Data.SqlClient;
using MiscSettingsApp.Models;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace MiscSettingsApp.Classes;
internal class Operations
{
    /// <summary>
    /// Read data from MiscSettings table joined with TheEnum
    /// </summary>
    /// <returns></returns>
    public static async Task<List<MiscSettings>> ReadMiscSettings()
    {
        await using SqlConnection cn = new(ConnectionString());
        return cn.Query<MiscSettings>(SqlStatements.SelectMiscSettings).AsList();
    }
}
