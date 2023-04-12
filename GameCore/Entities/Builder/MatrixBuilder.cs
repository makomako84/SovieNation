namespace MakoSystems.Sovienation.GameCore;

internal class MatrixBuilder : IMatrixBuilder
{
    private Cells _cellMatrix;

    internal MatrixBuilder(Cells cellMatrix)
    {
        _cellMatrix = cellMatrix;
    }

    Cell IMatrixBuilder.BuildRequest(int blockAreaId, int roomId)
    {
                // CPU consuming call. Use dictionary instead?
        var buildCell = _cellMatrix.Get(blockAreaId);
        if(buildCell != null && buildCell.AttachedRoomId != 0)
        {
            buildCell.AttachedRoomId = roomId;
            return buildCell;
        } 
        return null;
    }
}