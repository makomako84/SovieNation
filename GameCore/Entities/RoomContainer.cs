using System.Collections;
using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

internal class RoomContainer : IEnumerable<BaseRoom>
{
    private IList<BaseRoom> _rooms;
    private BaseRoom _tempRoom;

    internal RoomContainer()
    {
        
    }

    internal void Initialize(ref IList<BaseRoom> source)
    {
        _rooms = source;
    }

    internal BaseRoom Get(int id) => _rooms.First(r => r.Id == id);

    internal void AttachRoom()
    {

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