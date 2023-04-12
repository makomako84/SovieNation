namespace MakoSystems.Sovienation.GameCore;

internal class Cell
{
    private Int32 _id;
    Coord _coords;
    private Int32 _attachedRoomId;
    private static Int32 _idCounter = 0;

    internal Cell(Int32 x, Int32 y)
    {
        _coords = new Coord(x, y);
        _idCounter++;
        _id = _idCounter;
        _attachedRoomId = 0;
    }
    internal Int32 AttachedRoomId
    {
        get => _attachedRoomId;
        set
        {
            if(_attachedRoomId == 0)
                _attachedRoomId = value;
        }
    }

    internal Int32 Id
    {
        get => _id;
    }
}