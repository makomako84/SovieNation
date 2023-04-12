namespace MakoSystems.Sovienation.GameCore;

internal abstract class ResourceStorage
{
    internal abstract void GiveResource(ResourceAbstract resource);
    internal abstract void TakeResource(ResourceAbstract resource);
}