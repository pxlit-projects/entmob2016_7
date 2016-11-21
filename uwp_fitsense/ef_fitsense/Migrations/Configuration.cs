namespace ef_fitsense.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ef_fitsense.DataLayer.FitsenseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ef_fitsense.DataLayer.FitsenseContext context)
        {
            //Update-Database -TargetMigration: migrationName
            //Add-Migration Name
            //Update-Database 
        }
    }
}
