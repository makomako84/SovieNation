using System.Runtime.InteropServices;

namespace MakoSystems.Sovienation.GameCore;

internal class Session
{
    private IRoomPool _loadedRooms;
    private readonly Frame _frame;
    private readonly RoomContainer _roomContainer;

    internal Session()
    {
        var frameSource = new List<FrameItem>();
        _frame = new Frame(frameSource);

        // special frame item for Entry block
        frameSource.Add(new FrameItem(-1, 0, _frame)); 

        // common frame items
        frameSource.Add(new FrameItem(0, 0, _frame));
        frameSource.Add(new FrameItem(1, 0, _frame));
        frameSource.Add(new FrameItem(0, 1, _frame));
        frameSource.Add(new FrameItem(1, 1, _frame));

        
        var roomSource = new List<BaseRoom>();
        roomSource.Add(new EnergyRoom(1, "Room1", new List<FrameItem>() {
            _frame.Get(0, 0)
        }));
        roomSource.Add(new EnergyRoom(2, "Room2", new List<FrameItem>() {
            _frame.Get(0, 1),
            _frame.Get(1, 1)
        }));

        _roomContainer = new RoomContainer(roomSource);

        Debug();

    }

    private unsafe void Debug()
    {
        foreach(var frameItem in _frame)
        {
            FrameItem* ptr = &frameItem;
            IntPtr addr = (IntPtr)ptr;
            System.Console.WriteLine(addr.ToString());
            System.Console.WriteLine(frameItem.ToString());
        }

        foreach(var roomItem in _roomContainer)
        {
            System.Console.WriteLine(roomItem.ToString());
        }
    }

}