using FluentMigrator;
using SvaraKalkulators.Migrations.Interfaces;

namespace SvaraKalkulators.Migrations.Utils.Extensions
{
    public abstract class CompositeMigration : Migration, ICompositeMigration
    {
        public sealed override void Up() =>
            this.RunUp(this);

        public sealed override void Down() =>
            this.RunDown(this);

        public abstract ISubMigration[] GetMigrations();
    }
}
