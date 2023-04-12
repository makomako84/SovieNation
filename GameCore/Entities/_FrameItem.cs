namespace MakoSystems.Sovienation.GameCore;

internal struct FrameItem
{
    private readonly int _level;
    private readonly int _x;
    private int _occupiedBlockId;

    internal FrameItem(int x, int level)
    {
        _x = x;
        _level = level;
        _occupiedBlockId = 0;
    }

    internal int X => _x;
    internal int Level => _level;

    internal void CaptureFrameItem(int occupiedBlockId)
    {
        _occupiedBlockId = occupiedBlockId;
    }
    internal void FreeFrameItem()
    {
        _occupiedBlockId = 0;
    }
}