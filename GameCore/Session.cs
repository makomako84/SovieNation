namespace MakoSystems.Sovienation.GameCore;

internal class Session
{
    private RoomPool _loadedRooms { get; set; }
    private CharacterPool _loadedCharacters { get; set; }
    
    internal Session()
    {

    }

    internal void LoadRooms(List<Room> rooms)
    {
        _loadedRooms = new RoomPool();
        _loadedRooms.Load(rooms);
    }

    internal void LoadCharacters(List<Character> characters)
    {
        _loadedCharacters = new CharacterPool();
        _loadedCharacters.Load(characters);
    }

}