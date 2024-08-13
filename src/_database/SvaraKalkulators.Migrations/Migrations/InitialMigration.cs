using FluentMigrator;
using SvaraKalkulators.Migrations._20240812_Initial;
using SvaraKalkulators.Migrations.Interfaces;
using SvaraKalkulators.Migrations.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvaraKalkulators.Migrations.Migrations
{
    [TimestampedMigration(2024, 8, 12, 0, 0, "Initial migration")]
    public sealed class InitialMigration : CompositeMigration
    {
        public override ISubMigration[] GetMigrations() =>
            new ISubMigration[]
            {
                new ResultsMigration(),
            };
    }
}
