using System.ComponentModel.DataAnnotations;
using CTWebAPI.Models.MetaData;

namespace CTWebAPI.Models
{
    [MetadataType(typeof (NutrientMetaData))]
    public partial class Nutrient
    {
    }
}