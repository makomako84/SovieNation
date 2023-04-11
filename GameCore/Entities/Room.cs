using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;
internal class Room
{
	private Int32 _health;
	private float _baseOutcome;
	private float _consumeValue;
	private float _currentOutcome;
	private RoomLevel _level;
	private LevelOutcomeRate _levelOutcomeRate;
	private bool _isActive;
	private  Character _attachedCharacter;

	private static readonly RoomGlobalConfiguration _conf;

	static Room()
	{
		_conf = new RoomGlobalConfiguration();
	}

	internal Room(
		Int32 health,
	 	byte level)
	{
		_levelOutcomeRate = new LevelOutcomeRate();
		_health = health;
		_level = (RoomLevel)level;
	}


	// Public API
	// ...
	internal Character Character
	{
		get => _attachedCharacter;
		set
		{
			_attachedCharacter = value;
			NotifyCharacterAttached();
		}
	}

	internal Int32 Health { get => _health; }
	internal byte RoomLevel { get => (byte)_level; }
	
	// called every time slice from GameCore Thread
	internal void UpdateOutcome()
	{
		_currentOutcome = _baseOutcome - _consumeValue;
	}

	// called every time from user input (user-input => TCP-message API => internal API => IncreaseLevel)
	// при условии, что сопутствующие условия для Increase выполнены (т.е. должен быть респонз)
	internal void IncreaseLevel()
	{
		_level++;
		_levelOutcomeRate.SetOutcomeRate(_level);
	}
	internal void DecreaseLevel()
	{
		_level--;
		_levelOutcomeRate.SetOutcomeRate(_level);
	}

	private Int32 GetCurrentOutcome()
	{
		
		return (Int32)((byte)_level * _levelOutcomeRate.OutcomeRate);
	}
	private void NotifyCharacterAttached()
	{

	}
}
