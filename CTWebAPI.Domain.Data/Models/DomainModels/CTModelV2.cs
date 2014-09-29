using System.Data.Entity;
using CTWebAPI.Domain.Data.Models.DomainModels;

namespace CTWebAPI.Domain.Data.Models
{
    public class CTModelV2 : DbContext
    {
        public CTModelV2() : base("name=CTModelV2")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<FoodGroup> FoodGroups { get; set; }
        public virtual DbSet<FoodLog> FoodLogs { get; set; }
        public virtual DbSet<FoodNutrientRecord> FoodNutrientRecords { get; set; }
        public virtual DbSet<Nutrient> Nutrients { get; set; }
        public virtual DbSet<NutrientRDA> NutrientRdas { get; set; }

        protected virtual void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Food>();
            modelBuilder.Entity<Activity>();
            modelBuilder.Entity<ActivityLog>();
            modelBuilder.Entity<FoodGroup>();
            modelBuilder.Entity<FoodLog>();
            modelBuilder.Entity<FoodNutrientRecord>();
            modelBuilder.Entity<Nutrient>();
            modelBuilder.Entity<NutrientRDA>();
            modelBuilder.Entity<NutrientRDA>();
        }
    }
}