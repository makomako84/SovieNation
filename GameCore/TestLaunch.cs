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

        List<CellCoords> cellCords = new List<CellCoords>()
        {
            new CellCoords(0, 0),
            new CellCoords(0, 1),
            new CellCoords(0, 2)
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