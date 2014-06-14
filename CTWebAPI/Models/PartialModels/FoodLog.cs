using System.ComponentModel.DataAnnotations;
using CTWebAPI.Models.MetaData;

namespace CTWebAPI.Models
{
    [MetadataType(typeof (FoodLogMetaData))]
    public partial class FoodLog
    {
    }
}