using FluentMigrator;

namespace SvaraKalkulators.Migrations.Interfaces
{
    public interface ISubMigration
    {
        void Up(Migration migration);

        void Down(Migration migration);
    }
}
