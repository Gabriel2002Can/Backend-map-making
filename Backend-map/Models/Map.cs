namespace Backend_map.Models
{
    public class Map
    {
        public string Name { get; set; }

        public ICollection<Floor> Floors { get; set; }

        public int NumberOfFloors => Floors?.Count ?? 0;
    }
}
