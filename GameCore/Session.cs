namespace MakoSystems.Sovienation.GameCore;

internal class Session
{
    private IRoomPool _loadedRooms;
    private CharacterPool _loadedCharacters;
    private Cells _cellMatrix;
    
    internal Session()
    {

    }

    internal void LoadCells(Coord[] coords)
    {
        _cellMatrix = new Cells();
        _cellMatrix.Load(coords);
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