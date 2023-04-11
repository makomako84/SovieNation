namespace MakoSystems.Sovienation.GameCore;

public class TestLaunch
{
    Session _gameSession;
    public TestLaunch()
    {
        _gameSession = new Session();

        var characters = new List<Character>()
        {
            new Character("John", 100)
        };
        var rooms = new List<Room>()
        {
            new Room(50, 0)
        };

        _gameSession.LoadCharacters(characters);
        _gameSession.LoadRooms(rooms);
    }

    public void LaunchGameSession()
    {
        // Initialize Timer
        // Start recalculating async operation
        // Start backuping states async operation
    }
}