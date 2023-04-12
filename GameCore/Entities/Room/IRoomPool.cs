using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;

internal interface IRoomPool
{

    internal Int32 AddTemp(Int32 buildCellId);
    internal void Aprove();
    internal void RemoveTemp();
    internal void Load(List<Room> rooms);
    internal void LogRooms();
}