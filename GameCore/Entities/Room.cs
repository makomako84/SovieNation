namespace MakoSystems.Sovienation.GameCore;

internal class Room
{
    // service
	private Int32 _id;
	private Int32 _name;
    private Bool _isActive;

	private Int32 _currentHealth;
    private Int32 _maximumHealth;
    private Int32 _roomLevel;
    
	private Character[] _attachedCharacters;
    private ResourceStorage _resourceStorage;

    internal void LevelUpRoom() {}
    
    // уничтожением комнаты должен заниматься внешний класс
    // здесь происходит только обнуление ссылок
    // и вызов нотификаций
    internal void DestroyRoom() {}
}