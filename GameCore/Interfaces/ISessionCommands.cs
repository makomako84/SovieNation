namespace MakoSystems.Sovienation.GameCore;

public interface ISessionCommands
{
    public void RoomIncreaseLevel(Int32 roomId);
    public void RoomDecreaseLevel(Int32 roomId);
    public void RoomDestroy(Int32 roomId);
    public void CharacterAttach(Int32 characterId, Int32 roomId);
    public void CharacterDettach(Int32 characterId);
    public void CharacterGiveWeapon(Int32 characterId, Int32 weaponId);
    public void CharacterGiveArmor(Int32 characterId, Int32 armorId);

}