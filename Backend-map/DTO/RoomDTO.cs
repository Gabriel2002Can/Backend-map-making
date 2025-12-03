namespace Backend_map.DTO
{
    public class RoomDTO
    {
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
    }

    public class CreateRoomDTO
    {
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        public int FloorId { get; set; }
    }
}
