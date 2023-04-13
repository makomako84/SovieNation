namespace MakoSystems.Sovienation.GameCore;

internal struct FrameItem
{
    private readonly int _level;
    private readonly int _x;
    private readonly int _id;
    private int _occupiedBlockId;
    private readonly Frame _holdingFrame;

    internal FrameItem(
        int x, int level, Frame holdingFrame)
    {
        var rand = new Random();
        _id = rand.Next();
        _x = x;
        _level = level;
        _holdingFrame = holdingFrame;
        System.Console.WriteLine($"New frame item: {this.ToString()}");
    }

    internal int X => _x;
    internal int Level => _level;
    internal bool IsFree => _occupiedBlockId == 0;

    internal void Capture(int occupiedBlockId)
    {
        _occupiedBlockId = occupiedBlockId;
        System.Console.WriteLine($"Frame item captured: {this.ToString()}");
    }
    internal void Free()
    {
        _occupiedBlockId = 0;
    }

    public override string ToString()
    {
        return $"Id: {_id} L: {_level}, X: {_x}, Occupied: {_occupiedBlockId}, Frame: {_holdingFrame.FrameName}";
    }
}