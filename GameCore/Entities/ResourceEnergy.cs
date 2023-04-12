namespace MakoSystems.Sovienation.GameCore;

internal class ResourceEnergy : ResourceAbstract
{
    private float _energy;

    public float Energy
    {
        get => _energy;
        set => _energy = value;
    }
}