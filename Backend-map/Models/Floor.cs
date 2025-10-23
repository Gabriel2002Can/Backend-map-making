using System.Text.Json.Serialization;

namespace Backend_map.Models
{
    public class Floor
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // The number of the floor
        public int Number { get; set; }

        public int DimensionX { get; set; }
        public int DimensionY { get; set; }

        [JsonIgnore]
        public Map Map { get; set; }
        public int MapId { get; set; }

        public ICollection<Cell> Cells { get; set; }
    }
}
