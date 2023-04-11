using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

internal class RoomPool
{
    private List<Room> _rooms;

    internal RoomPool()
    {

    }

    internal void Load(List<Room> rooms)
    {
        _rooms = rooms;
    }
}