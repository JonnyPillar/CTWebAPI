using System.ComponentModel.DataAnnotations;
using CTWebAPI.Models.MetaData;

namespace CTWebAPI.Models
{
    [MetadataType(typeof (UserMetaData))]
    public partial class User
    {
    }
}