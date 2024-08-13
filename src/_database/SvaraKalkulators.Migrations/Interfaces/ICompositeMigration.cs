namespace SvaraKalkulators.Migrations.Interfaces
{
    public interface ICompositeMigration
    {
        ISubMigration[] GetMigrations();
    }
}
