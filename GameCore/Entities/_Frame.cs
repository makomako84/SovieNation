using System.Collections;

namespace MakoSystems.Sovienation.GameCore;

internal class Frame : IEnumerable<FrameItem>
{
    private readonly string _frameName;
    // available building position cells
    private IList<FrameItem> _blocks;

    internal Frame()
    {
        _blocks = new List<FrameItem>();
        var rand = new Random();
        _frameName = "Frame" + rand.Next();
    }

    internal void Initialize(ref IList<FrameItem> items)
    {
        _blocks = items;
    }

    internal string FrameName => _frameName;

    internal FrameItem Get(int x, int level)
    {
        return _blocks.First(b => b.X == x && b.Level == level);
    }

    internal IEnumerable<FrameItem> List()
    {
        return _blocks;
    }

    internal IEnumerable<FrameItem> ListFreeItems()
    {
        return _blocks.Where(b => b.IsFree);
    }

    internal void CaptureFrameItem(int x, int level, int captureBlockId)
    {
        var block = _blocks.First(b => b.X == x && b.Level == level);
        block.Capture(captureBlockId);
    }

    internal void FreeFrameItem(int x, int level)
    {
        var block = _blocks.First(b => b.X == x && b.Level == level);
        block.Free();
    }

    public IEnumerator<FrameItem> GetEnumerator()
    {
        return _blocks.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return null;
    }
}