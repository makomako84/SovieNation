using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

public interface IRoomSlice
{
    public List<RoomDto> GetSlice();
    public void Load(List<RoomDto> rooms);
}