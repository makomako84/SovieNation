namespace MakoSystems.Sovienation.GameCore;

internal abstract class BaseRoom
{
    // service
	private int _id;
	private string _name;
    // should refer to the same items as in Session IList<BlockItem>
    private LinkedList<FrameItem> _capturedFrameBlocks;

    private static int _globalMaxRoomLength = 3;

    internal BaseRoom(
        int id,
        string name)
    {
        _id = id;
        _name = name;
        _capturedFrameBlocks = new LinkedList<FrameItem>();
    }

    internal void ExtendRoom(FrameItem frameItem)
    {
        if(_capturedFrameBlocks.Count < _globalMaxRoomLength)
        {
            _capturedFrameBlocks.AddLast(frameItem);
            frameItem.Capture(this._id);
            RecalculateParameteres();
        }
        else
        {
            throw new System.Exception("Attempt to extend maximum size room");
        }
    }

    protected virtual void RecalculateParameteres()
    {

    }
    
    // уничтожением комнаты должен заниматься внешний класс
    // здесь происходит только обнуление ссылок
    // и вызов нотификаций
    internal void DestroyRoom() 
    {
        foreach(var item in _capturedFrameBlocks)
            item.Free();

        _capturedFrameBlocks = null;
        _name = null;
        _id = -1;
    }

    private String CapturedFramesToString() => string.Join(", ", _capturedFrameBlocks);
    public override string ToString() => $"id: {_id}, name: {_name} capturedFrames: {CapturedFramesToString()}";
}

internal class EnergyRoom : BaseRoom
{
    public EnergyRoom(int id, string name, IList<FrameItem> capturedBlocks) 
        : base(id, name, capturedBlocks)
    {
    }
}