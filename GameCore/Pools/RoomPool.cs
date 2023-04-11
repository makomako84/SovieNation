using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

public class RoomPool : IRoomSlice
{
    private List<Room> _rooms;

    public List<RoomDto> GetSlice()
    {
        List<RoomDto> dtos = new List<RoomDto>();
        foreach(var item in _rooms)
        {
            dtos.Add(item.ToDto());
        }
        return dtos;
    }
}