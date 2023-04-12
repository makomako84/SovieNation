using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

internal class RoomPool
{
    private List<Room> _rooms;

    internal RoomPool()
    {

    }

    internal void Add(Int32 buildCellId)
    {
        _rooms.Add(new Room());
    }

    internal void Load(List<Room> rooms)
    {
        _rooms = rooms;
    }
}