using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

/// <summary>
/// Класс игровой сессии
/// </summary>
public class SessionCommandUnit : ISessionCommands
{
    private CharacterPool _loadedRooms { get; set; }
    private RoomPool _loadedCharacters { get; set; }

    internal SessionCommandUnit()
    {

    }

    public void RoomIncreaseLevel(int roomId)
    {
        throw new NotImplementedException();
    }

    public void RoomDecreaseLevel(int roomId)
    {
        throw new NotImplementedException();
    }

    public void RoomDestroy(int roomId)
    {
        throw new NotImplementedException();
    }

    public void CharacterAttach(int characterId, int roomId)
    {
        throw new NotImplementedException();
    }

    public void CharacterDettach(int characterId)
    {
        throw new NotImplementedException();
    }

    public void CharacterGiveWeapon(int characterId, int weaponId)
    {
        throw new NotImplementedException();
    }

    public void CharacterGiveArmor(int characterId, int armorId)
    {
        throw new NotImplementedException();
    }



}