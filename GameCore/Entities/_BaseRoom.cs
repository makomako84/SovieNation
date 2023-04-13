namespace MakoSystems.Sovienation.GameCore;

internal abstract class BaseRoom
{
    // service
	private int _id;
	private string _name;
    private Frame _frame;
    private int _blockLength;
    private int _level;
    private int[] _blockX;

    private static int _globalMaxRoomLength = 3;

    internal BaseRoom(
        int id,
        string name, int level, Frame frame)
    {
        _id = id;
        _name = name;
        _frame = frame;
        _level = level;
        _blockX = new int[_globalMaxRoomLength];
    }

    internal int Id => _id;

    internal void ExtendRoom(FrameItem frameItem)
    {
        if(_blockLength < _globalMaxRoomLength)
        {
            _blockLength++;
            _frame.CaptureFrameItem(frameItem.X, frameItem.Level, this._id);
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
        
        _blockLength = 0;
        _name = null;
        _id = -1;
    }

    public override string ToString() => $"id: {_id}, name: {_name}";
}

internal class EnergyRoom : BaseRoom
{
    public EnergyRoom(int id, string name, int level, Frame frame) 
        : base(id, name, level, frame)
    {
    }
}