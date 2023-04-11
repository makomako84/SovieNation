using System.Collections.Generic;
using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.Application;

/// <summary>
/// Интерфейс для Persistence слоя
/// </summary>
public interface IRoomRepository
{
    public void Update(List<RoomDto> rooms);
}