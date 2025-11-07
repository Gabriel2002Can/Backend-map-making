namespace Backend_map.DTO
{
    public class CreateFloorDTO
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public int DimensionX { get; set; }
        public int DimensionY { get; set; }

        public int MapId { get; set; }
    }

    public class UpdateFloorDTO
    {
        public string? Name { get; set; }
        public int? Number { get; set; }
        public int? DimensionX { get; set; }
        public int? DimensionY { get; set; }
    }
}
