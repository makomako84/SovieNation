using MakoSystems.Sovienation.Application;
using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.Persist;

public class RoomRepository : IRoomRepository
{

    public void Update(List<RoomDto> rooms)
    {
        System.Console.WriteLine("Rooms update to database");
    }
}