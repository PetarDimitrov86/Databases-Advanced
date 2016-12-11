namespace Photography.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MirrorlessCameras")]
    public class MirrorlessCamera : Camera
    {
        public string MaxVideoResolution { get; set; }

        public int? MaxFrameRate { get; set; }
    }
}