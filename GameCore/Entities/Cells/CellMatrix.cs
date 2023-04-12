namespace MakoSystems.Sovienation.GameCore;

internal class CellMatrix
{
        // available building position cells
    private List<BuildMatrixCell> _buildCells;

    internal CellMatrix()
    {
        _buildCells = new List<BuildMatrixCell>();
    }

    internal BuildMatrixCell Get(Int32 blockAreaId)
    {
        return _buildCells.Find(c => c.Id == blockAreaId);
    }

    internal void Load(CellCoords[] coords)
    {
        foreach(var item in coords)
        {
            _buildCells.Add(new BuildMatrixCell(item.X, item.Y));
        }
    }
}