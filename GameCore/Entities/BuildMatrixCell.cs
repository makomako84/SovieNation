namespace MakoSystems.Sovienation.GameCore;

internal class BuildMatrixCell
{
    private Int32 _x;
    private Int32 _y;

    private Int32 _attachedRoomId;

    private Int32 _id;
    private static Int32 _idCounter = 0;

    internal BuildMatrixCell(Int32 x, Int32 y)
    {
        _x = x;
        _y = y;
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