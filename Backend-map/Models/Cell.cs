namespace Backend_map.Models
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFilled { get; set; }
        public Floor Floor { get; set; }
        public int FloorId { get; set; }

}
}
