using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

public class SessionPersistUnit : ISessionPersist
{
        // SessionPersist
    public List<RoomDto> GetRoomSlice()
    {
        return new List<RoomDto>();
    }

    public List<CharacterDto> GetCharacterSlice()
    {
        return new List<CharacterDto>();
    }
}