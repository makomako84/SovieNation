using System.Collections;
using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

internal class RoomContainer : IEnumerable<BaseRoom>
{
    private IList<BaseRoom> _rooms;
    private BaseRoom _tempRoom;

    internal RoomContainer(IList<BaseRoom> roomSource)
    {
        _rooms = roomSource;
    }



    Int32 AddTemp<T>(Int32 buildCellId) where T : BaseRoom
    {
        return 0;
    }
    void Aprove()
    {
        _rooms.Add(_tempRoom);
    }

    void RemoveTemp()
    {
        _tempRoom = null;
    }

    public IEnumerator<BaseRoom> GetEnumerator()
    {
        return _rooms.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return null;
    }
}