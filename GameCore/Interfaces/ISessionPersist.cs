using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

public interface ISessionPersist
{
    public List<RoomDto> GetRoomSlice();
    public List<CharacterDto> GetCharacterSlice();
}