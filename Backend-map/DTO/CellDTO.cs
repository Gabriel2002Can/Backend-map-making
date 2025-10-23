namespace Backend_map.DTO
{
    public class CellsDTO
    {
        public List<CellDTO> Cells { get; set; }

        public int FloorId { get; set; }

    }

    public class CellDTO
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFilled { get; set; }
    }
}
