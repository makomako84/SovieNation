namespace MakoSystems.Sovienation.GameCore;

internal class BuildMatrixCell
{
    CellCoords _cellCoords;

    private Int32 _attachedRoomId;

    private Int32 _id;
    private static Int32 _idCounter = 0;

    internal BuildMatrixCell(Int32 x, Int32 y)
    {
        _cellCoords = new CellCoords(x, y);
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