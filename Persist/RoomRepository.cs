using MakoSystems.Sovienation.Application;
using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.Persist;

public class RoomRepository : IRoomRepository
{

    public void Update(List<RoomDto> rooms)
    {
        foreach(var item in rooms)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("Rooms update to database");
    }
}