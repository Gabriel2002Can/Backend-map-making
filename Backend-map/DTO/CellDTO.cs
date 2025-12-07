using Backend_map.Models;

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

        public bool? IsFilled { get; set; }

        public bool ClearRoom { get; set; } = false;
        public int? RoomId { get; set; }

        public bool ClearIcon { get; set; } = false;
        public IconType? Icon { get; set; }
    }
}
