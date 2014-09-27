using System.Data.Entity;
using CTWebAPI.Models.DomainModels;

namespace CTWebAPI.Models
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
    }
}