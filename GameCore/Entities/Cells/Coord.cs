namespace MakoSystems.Sovienation.GameCore;

internal struct Coord
{
    private int _x;
    private int _y;

    internal Coord(int x, int y)
    {
        _x = x;
        _y = y;
    }

    internal int X => _x;
    internal int Y => _y;
}