using System.ComponentModel.DataAnnotations;
using CTWebAPI.Models.MetaData;

namespace CTWebAPI.Models
{
    [MetadataType(typeof (ActivityLogMetadData))]
    public partial class ActivityLog
    {
    }
}