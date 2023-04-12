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

        List<Coord> cellCords = new List<Coord>()
        {
            new Coord(0, 0),
            new Coord(0, 1),
            new Coord(0, 2)
        };

        _gameSession.LoadCells(cellCords.ToArray());
        _gameSession.LoadCharacters(characters);
    }

    public void LaunchGameSession()
    {
        // Initialize Timer
        // Start recalculating async operation
        // Start backuping states async operation
    }
}