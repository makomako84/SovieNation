namespace MakoSystems.Sovienation.GameCore;

internal struct LevelOutcomeRate
{
	private float _outcomeRate = 1.0f;


	public LevelOutcomeRate()
	{
	}

	public float OutcomeRate { get => _outcomeRate; }

	public void SetOutcomeRate(RoomLevel roomLevel)
	{
		switch(roomLevel)
		{
			case RoomLevel.Level1:
				_outcomeRate = 1.1f;
				break;
			case RoomLevel.Level2:
				_outcomeRate = 1.2f;
				break;
			case RoomLevel.Level3:
				_outcomeRate = 1.3f;
				break;
			default:
				_outcomeRate = 1.0f;
				break;
		}
	}
}