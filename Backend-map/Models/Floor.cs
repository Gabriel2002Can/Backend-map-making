namespace Backend_map.Models
{
    public class Floor
    {
        // The number of the floor
        public int Number { get; set; }

        public int DimensionX { get; set; }
        public int DimensionY { get; set; }

        public Map Map { get; set; }
        public int MapId { get; set; }

        public ICollection<Cell> Cells { get; set; }
    }
}
