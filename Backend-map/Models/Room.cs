using System.Text.Json.Serialization;

namespace Backend_map.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public Floor Floor { get; set; }
        public int FloorId { get; set; }

    }
}
