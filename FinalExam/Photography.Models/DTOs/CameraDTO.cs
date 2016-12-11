namespace Photography.Models.DTOs
{
    public class CameraDTO
    {
        public string Type { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsFullFrame { get; set; }

        public int MinISO { get; set; }

        public int MaxISO { get; set; }

        public string MaxVideoResolution { get; set; }

        public int MaxFrameRate { get; set; }

        public int MaxShutterSpeed { get; set; }
    }
}