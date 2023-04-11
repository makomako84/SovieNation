using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

public class RoomPool : IRoomSlice
{
    private List<Room> _rooms;

    public RoomPool()
    {

    }

    public List<RoomDto> GetSlice()
    {
        List<RoomDto> dtos = new List<RoomDto>();
        foreach(var item in _rooms)
        {
            dtos.Add(item.ToDto());
        }
        return dtos;
    }

    public void Load(List<RoomDto> rooms)
    {
        _rooms = new List<Room>();
        foreach(var item in rooms)
        {
            _rooms.Add(Room.FromDto(item));
        }
    }
}