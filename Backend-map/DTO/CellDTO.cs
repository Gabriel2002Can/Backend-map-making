namespace Backend_map.DTO
{
    public class CellsCreationDTO
    {
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }

        public int FloorId { get; set; }

    }

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
