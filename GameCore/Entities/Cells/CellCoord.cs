namespace MakoSystems.Sovienation.GameCore;

internal struct CellCoords
{
    private int _x;
    private int _y;

    internal CellCoords(int x, int y)
    {
        _x = x;
        _y = y;
    }

    internal int X => _x;
    internal int Y => _y;
}