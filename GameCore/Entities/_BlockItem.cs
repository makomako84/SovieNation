namespace MakoSystems.Sovienation.GameCore;

/// <summary>
/// base type for building items
/// that shout be placed in Frame and capture it items 
/// </summary>
internal abstract class BlockItem
{
    private int _id;
    private int _x; // captured frame item x coord
    private int _level; // caputre frame item level coord


    internal int Id => _id;
    internal int X => _x;
    internal int Level => _level;

    /// <summary>
    /// when creating id, x and level should be adopted
    /// </summary>
    internal BlockItem(int id, int x, int level)
    {
        _id = id;
        _x = X;
        _level = level;
    }

}