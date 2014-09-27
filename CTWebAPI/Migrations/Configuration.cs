namespace CTWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CTWebAPI.Domain.Data.Models.CTModelV2>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CTWebAPI.Domain.Data.Models.CTModelV2 context)
        {
        }
    }
}
