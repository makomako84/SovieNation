using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

internal class RoomPool : IRoomPool
{
    private List<Room> _rooms;
    private Room _tempRoom;

    internal RoomPool()
    {

    }

    Int32 IRoomPool.AddTemp(Int32 buildCellId)
    {
        _tempRoom = new Room(buildCellId);
        return _tempRoom.BuildCellId;
    }
    void IRoomPool.Aprove()
    {
        _rooms.Add(_tempRoom);
    }
    void IRoomPool.RemoveTemp()
    {
        _tempRoom = null;
    }

    void IRoomPool.Load(List<Room> rooms)
    {
        _rooms = rooms;
    }

    void IRoomPool.LogRooms()
    {
        foreach(var item in _rooms)
        {
            Console.WriteLine(item);
        }
    }
}