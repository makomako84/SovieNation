using MakoSystems.Sovienation.GameCore;
using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.Application;

public class RoomBackupWorker
{
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomSlice _roomSlice;
    public RoomBackupWorker(
        IRoomRepository roomRepository,
        IRoomSlice roomSlice)
    {
        _roomRepository = roomRepository;
        _roomSlice = roomSlice;
    }

    public void Backup()
    {
        System.Console.WriteLine("Call backup");
        List<RoomDto> rooms =  _roomSlice.GetSlice();
        _roomRepository.Update(rooms);
    }
}