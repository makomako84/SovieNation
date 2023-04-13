// namespace MakoSystems.Sovienation.GameCore;

// internal class BuildDirector
// {
//     private IMatrixBuilder _buildMatrix;
//     private IRoomPool _roomPool;

//     internal BuildDirector(
//         IMatrixBuilder matrix,
//         IRoomPool roomPool)
//     {
//         _buildMatrix = matrix;
//         _roomPool = roomPool;
//     }

//     internal bool BuildRoom(Int32 buildAreaCellId)
//     {
//         Int32 tempRoomId = _roomPool.AddTemp(buildAreaCellId);
//         // Реквест на строительство в выбранной клетке
//         // Если клетка не занята и существует, то можно строить
//         var buildCell = _buildMatrix.BuildRequest(
//             buildAreaCellId, 
//             tempRoomId);

//         if(buildCell != null)
//         {
//             // можно размещать Room
//             _roomPool.Aprove();
//             return true;
//         }
//         _roomPool.RemoveTemp();
//         return false;
//     }
// }