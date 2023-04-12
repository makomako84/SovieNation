namespace MakoSystems.Sovienation.GameCore;

internal interface IMatrixBuilder
{
        internal BuildMatrixCell BuildRequest(
            Int32 blockAreaId, 
            Int32 roomId);
}