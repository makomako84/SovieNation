namespace MakoSystems.Sovienation.GameCore;

internal abstract class BaseRoom
{
    // service
	private int _id;
	private string _name;
    // should refer to the same items as in Session IList<BlockItem>
    private IList<BlockItem> _capturedBlocks;

    private static int _globalMaxRoomLength = 3;

    internal BaseRoom(
        int id,
        string name,
        IList<BlockItem> capturedBlocks)
    {
        _id = id;
        _name = name;
        _capturedBlocks = capturedBlocks;
    }

    internal void ExtendRoom(BlockItem blockItem)
    {
        if(_capturedBlocks.Count < _globalMaxRoomLength)
        {
            _capturedBlocks.Add(blockItem);
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
        _capturedBlocks = null;
        _name = null;
        _id = -1;
    }
}