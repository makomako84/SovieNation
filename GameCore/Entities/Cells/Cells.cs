namespace MakoSystems.Sovienation.GameCore;

internal class Cells
{
        // available building position cells
    private List<Cell> _buildCells;

    internal Cells()
    {
        _buildCells = new List<Cell>();
    }

    internal Cell Get(Int32 blockAreaId)
    {
        return _buildCells.Find(c => c.Id == blockAreaId);
    }

    internal void Load(Coord[] coords)
    {
        foreach(var item in coords)
        {
            _buildCells.Add(new Cell(item.X, item.Y));
        }
    }
}