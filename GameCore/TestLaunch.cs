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

        _gameSession.LoadCharacters(characters);
    }

    public void LaunchGameSession()
    {
        // Initialize Timer
        // Start recalculating async operation
        // Start backuping states async operation
    }
}