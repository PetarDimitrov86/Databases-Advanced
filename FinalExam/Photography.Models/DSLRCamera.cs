namespace Photography.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DSLRCameras")]
    public class DSLRCamera : Camera
    {
        public int? MaxShutterSpeed { get; set; }
    }
}