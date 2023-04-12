namespace MakoSystems.Sovienation.GameCore;

internal class Room
{
    // service
	private Int32 _id;
    private Int32 _buildCellId;
	private Int32 _name;
    private Boolean _isActive;

	private Int32 _currentHealth;
    private Int32 _maximumHealth;
    private Int32 _roomLevel;
    
	private Character[] _attachedCharacters;
    private ResourceStorage _resourceStorage;

    internal Room(Int32 buildCellId)
    {
        _buildCellId = buildCellId;
    }

    internal Int32 BuildCellId
    {
        get => _buildCellId;
    }

    internal void LevelUpRoom() {}
    
    // уничтожением комнаты должен заниматься внешний класс
    // здесь происходит только обнуление ссылок
    // и вызов нотификаций
    internal void DestroyRoom() {}
}