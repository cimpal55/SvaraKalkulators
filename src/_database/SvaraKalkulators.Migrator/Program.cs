using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SvaraKalkulators.Migrations.Migrations;

IConfiguration _configuration = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
  .Build();

var serviceProvider = CreateServices();

using var scope = serviceProvider.CreateScope();
UpdateDatabase(scope.ServiceProvider);

IServiceProvider CreateServices()
{
    return new ServiceCollection()
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            .AddSqlServer()
            .WithGlobalConnectionString(_configuration["ConnectionStrings:Database"])
            .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        .BuildServiceProvider(false);
}

static bool CheckDatabaseExists(string connectionString)
{
    using (var connection = new SqlConnection(connectionString))
    {
        using (var command = new SqlCommand($"SELECT db_id('SvaraKalkulators')", connection))
        {
            connection.Open();
            return (command.ExecuteScalar() != DBNull.Value);
        }
    }
}

void CreateDb()
{
    var cs = _configuration["ConnectionStrings:Default"];
    using var con = new SqlConnection(cs);

    if (CheckDatabaseExists(cs) == false)
    {
        string query = "CREATE DATABASE SvaraKalkulators";
        con.Execute(query);
    }
}

void UpdateDatabase(IServiceProvider serviceProvider)
{
    CreateDb();
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}