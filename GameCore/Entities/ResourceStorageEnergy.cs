namespace MakoSystems.Sovienation.GameCore;


/*
    Есть куча вот этих композит-румов. Один из румов сказал: хочу передать ресурс.
    В ответ на это создается некий сигнал (эвент) о том, что нужно забрать ресурсы.
    ResourceStorage забирает ресурсы у всякого, кто заявил о необходимости сбора.
    Т.е. RoomComposite ничего не знает о ResourceStorage, он только передает сигнал
    о том, что Resource нужно собрать.
*/
internal class ResourceStorageEnergy  : ResourceStorage
{
    private float _currentEnergy;

    internal override void GiveResource(ResourceAbstract resource)
    {
        ResourceEnergy energyResource = resource as ResourceEnergy();

        _currentEnergy += energyResource.Energy;
    }

    internal override void TakeResource(ResourceAbstract resource)
    {
        ResourceEnergy energyResource = resource as ResourceEnergy();

        _currentEnergy -= energyResource.Energy;
    }
}