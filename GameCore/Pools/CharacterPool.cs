namespace MakoSystems.Sovienation.GameCore;

internal class CharacterPool
{
    private List<Character> _characters;

    internal CharacterPool()
    {

    }

    internal void Load(List<Character> characters)
    {
        _characters = characters;
    }
}