namespace MakoSystems.Sovienation.GameCore;

internal class BuildDirector
{
    private BuildMatrix _buildMatrix;
    private RoomPool _roomPool;

    internal BuildDirector(
        BuildMatrix matrix,
        RoomPool roomPool)
    {
        _buildMatrix = matrix;
        _roomPool = roomPool;
    }

    internal bool BuildRoom(Int32 buildAreaCellId)
    {
        // Реквест на строительство в выбранной клетке
        // Если клетка не занята и существует, то можно строить
        var buildCell = _buildMatrix.BuildRequest(buildAreaCellId);
        if(buildCell != null)
        {
            // можно размещать Room
            return true;
        }
        return false;
    }
}