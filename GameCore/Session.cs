namespace MakoSystems.Sovienation.GameCore;

internal class Session
{
    private IRoomPool _loadedRooms;
    private CharacterPool _loadedCharacters;
    private readonly Frame _frame;
    
    internal Session()
    {
        var frameSource = new List<FrameItem>();

        // special frame item for Entry block
        frameSource.Add(new FrameItem(-1, 0)); 

        // common frame items
        frameSource.Add(new FrameItem(0, 0));
        frameSource.Add(new FrameItem(1, 0));
        frameSource.Add(new FrameItem(0, 0));
        frameSource.Add(new FrameItem(1, 0));
    }

}