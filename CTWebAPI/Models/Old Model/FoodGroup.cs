//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CTWebAPI.Models.Old_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class FoodGroup
    {
        public FoodGroup()
        {
            this.tbl_foods = new HashSet<Food>();
        }
    
        public int FoodGroupID { get; set; }
        public string Name { get; set; }
        public int SourceID { get; set; }
    
        public virtual ICollection<Food> tbl_foods { get; set; }
    }
}
