﻿using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;

namespace SqlServerSink.Classes;
internal class SetupLogging
{
    
    public static void Initialize()
    {


        var configuration = Configurations.GetConfigurationRoot();


        var columnOptionsSection = configuration.GetSection("Serilog:ColumnOptions");
        var sinkOptionsSection = configuration.GetSection("Serilog:SinkOptions");


        Log.Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(
                connectionString: "LogDatabase",
                sinkOptions: new MSSqlServerSinkOptions
                {
                    TableName = "LogEvents",
                    SchemaName = "dbo",
                    AutoCreateSqlTable = true
                },
                sinkOptionsSection: sinkOptionsSection,
                appConfiguration: configuration,
                columnOptionsSection: columnOptionsSection)
            .CreateLogger();
    }
}
