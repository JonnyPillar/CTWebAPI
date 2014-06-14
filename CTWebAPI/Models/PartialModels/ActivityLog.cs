using System.ComponentModel.DataAnnotations;
using CTWebAPI.Models.MetaData;

namespace CTWebAPI.Models
{
    [MetadataType(typeof (FoodGroupMetaData))]
    public partial class ActivityLog
    {
    }
}