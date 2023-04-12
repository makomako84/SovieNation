namespace MakoSystems.Sovienation.GameCore;

internal class Session
{
    private IRoomPool _loadedRooms;
    private CharacterPool _loadedCharacters;
    private CellMatrix _cellMatrix;
    
    internal Session()
    {

    }

    internal void LoadCells(CellCoords[] coords)
    {
        _cellMatrix = new CellMatrix();
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