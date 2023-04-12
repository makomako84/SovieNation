namespace MakoSystems.Sovienation.GameCore;

internal class BuildMatrix
{
    // available building position cells
    private BuildMatrixCell[] _buildCells;

    internal BuildMatrix()
    {
        _buildCells = new BuildMatrixCell();
        InitTestValues();
    }

    internal BuildMatrixCell BuildRequest(Int32 blockAreaId)
    {
        // CPU consuming call. Use dictionary instead?
        var buildCell = _buildCells.Find(cell => cell.Id == blockAreaId);
        if(buildCell.AttachedRoomId == 0)
        {
            return buildCell;
        } 
        return null;
    }

    internal void InitTestValues()
    {
        _buildCells.Add(new BuildMatrixCell(0,0));
        _buildCells.Add(new BuildMatrixCell(10, 0));
        _buildCells.Add(new BuildMatrixCell(20, 0));
    }

}