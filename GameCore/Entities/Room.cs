using MakoSystems.Sovienation.DTO;

namespace MakoSystems.Sovienation.GameCore;


internal enum RoomType
{
	Entry,
	PowerProduction,
	FoodProduction
}

internal enum RoomLevel : byte
{
	Level1 = 0,
	Level2 = 1,
	Level3 = 2
}

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

internal class Room
{
	private readonly RoomType _roomType;
	private Int32 _health;
	private Int32 _baseOutcome;
	private Int32 _consumeValue;
	private Int32 _currentOutcome;
	private RoomLevel _level;
	private LevelOutcomeRate _levelOutcomeRate;
	private bool _isActive;
	private Character _attachedCharacter;

	public Room(RoomType roomType)
	{
		_levelOutcomeRate = new LevelOutcomeRate();
	}

	// Public API
	// ...
	public Character Character
	{
		get => _attachedCharacter;
		set => _attachedCharacter = value;
	}

	internal Int32 Health { get => _health; }
	internal byte RoomLevel { get => (byte)_level; }
	
	// called every time slice from GameCore Thread
	public void UpdateOutcome()
	{
		_currentOutcome = _baseOutcome - _consumeValue;
	}

	// called every time from user input (user-input => TCP-message API => internal API => IncreaseLevel)
	// при условии, что сопутствующие условия для Increase выполнены (т.е. должен быть респонз)
	public void IncreaseLevel()
	{
		_level++;
		_levelOutcomeRate.SetOutcomeRate(_level);
	}
	public void DecreaseLevel()
	{
		_level--;
		_levelOutcomeRate.SetOutcomeRate(_level);
	}


	private Int32 GetCharacterOutcome()
	{
		return 0;
	}
	private Int32 GetCurrentOutcome()
	{
		
		return (Int32)((byte)_level * _levelOutcomeRate.OutcomeRate);
	}

	public RoomDto ToDto()
    {
		// Происходит копирование памяти в ManagedHeap - Не самая лучшая ситуация конечно же
		// Может можно как-то вызвать очистку в ручную? После завершения операции
        return new RoomDto() 
        { 
            Health = this._health,
            RoomLevel = (byte)this._level
        };
    }
}
