namespace MakoSystems.Sovienation.GameCore;

internal class Frame
{
    // available building position cells
    private IList<FrameItem> _blocks;

    internal Frame(IList<FrameItem> frameItems)
    {
        _blocks = frameItems;
    }
}