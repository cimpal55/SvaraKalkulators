using FluentMigrator;
using SvaraKalkulators.Core.Data.Resources;
using SvaraKalkulators.Migrations.Interfaces;
using static SvaraKalkulators.Core.Data.Resources.Columns;

namespace SvaraKalkulators.Migrations._20240812_Initial
{
    internal sealed class ResultsMigration : ISubMigration
    {
        private const string TableName = Tables.Results;

        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Results.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Results.Barcode).AsString(12).NotNullable()
                .WithColumn(Results.Weight).AsDecimal(19, 5).NotNullable()
                .WithColumn(Results.Mode).AsString().NotNullable()
                .WithColumn(Results.DateTime).AsDateTime().NotNullable();
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
