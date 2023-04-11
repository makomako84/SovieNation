namespace MakoSystems.Sovienation.GameCore;

internal class RoomGlobalConfiguration
{
    public float BaseOutcome { get; set; }
    public float Level1OutcomeRate { get; set; }
    public float Level2OutcomeRate { get; set; }
    public float Level3OutcomeRate { get; set; }

    public RoomGlobalConfiguration()
    {
        BaseOutcome = 25;
        Level1OutcomeRate = 1.0f;
        Level2OutcomeRate = 1.1f;
        Level3OutcomeRate = 1.2f;
    }
}