namespace MakoSystems.Sovienation.GameCore;

internal class Character
{
	private string _name;
	private int _health;
	private Room _attachedRoom;

	internal Character(string name, int health)
	{
		_attachedRoom = null; // search for "default room here";
	}
}
