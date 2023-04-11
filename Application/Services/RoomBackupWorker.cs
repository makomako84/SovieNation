using MakoSystems.Sovienation.GameCore;
using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.Application;

public class RoomBackupWorker
{
    private readonly IRoomRepository _roomRepository;
    private readonly ISessionPersist _sessionPersistUnit;
    public RoomBackupWorker(
        IRoomRepository roomRepository,
        ISessionPersist sessionPersistUnit)
    {
        _roomRepository = roomRepository;

        _sessionPersistUnit = sessionPersistUnit;
        
    }

    public void Backup()
    {
        System.Console.WriteLine("Call backup");
        var rooms = _sessionPersistUnit.GetRoomSlice();
        var characters = _sessionPersistUnit.GetCharacterSlice();

        _roomRepository.Update(rooms);
    }
}