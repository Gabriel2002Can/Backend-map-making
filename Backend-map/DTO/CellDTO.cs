namespace Backend_map.DTO
{

    public class CellsDTO
    {
        public List<CellUpdateDTO> Cells { get; set; }

        public int FloorId { get; set; }
    }

    public class CellUpdateDTO
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsFilled { get; set; }
    }
}
