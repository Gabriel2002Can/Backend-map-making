using System.Text.Json.Serialization;

namespace Backend_map.Models
{
    public enum IconType
    {
        Stairs,
        Elevator,
        Door,
        Toilet,
    }

    public class Cell
    {
        public int Id { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public bool IsFilled { get; set; }

        [JsonIgnore]
        public Floor Floor { get; set; }
        public int FloorId { get; set; }

        [JsonIgnore]
        public Room? Room { get; set; }
        public int? RoomId { get; set; }

        public IconType? Icon { get; set; }
        public string? IconImage => Icon switch
        {
            IconType.Stairs => "faStairs",
            IconType.Elevator => "faElevator",
            IconType.Door => "faDoorClosed",
            IconType.Toilet => "faRestroom",
            _ => null
        };
    }
}
