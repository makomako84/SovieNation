using System.Runtime.InteropServices;

namespace MakoSystems.Sovienation.GameCore;

internal class Session
{
    private IRoomPool _loadedRooms;
    private readonly Frame _frame;
    private readonly RoomContainer _roomContainer;

    internal Session()
    {
        
        _frame = new Frame();
        _roomContainer = new RoomContainer();

        IList<FrameItem> frameSource = new List<FrameItem>();
        // special frame item for Entry block
        frameSource.Add(new FrameItem(-1, 0, _frame)); 

        // common frame items
        frameSource.Add(new FrameItem(0, 0, _frame));
        frameSource.Add(new FrameItem(1, 0, _frame));
        frameSource.Add(new FrameItem(0, 1, _frame));
        frameSource.Add(new FrameItem(1, 1, _frame));
        _frame.Initialize(ref frameSource);

        
        IList<BaseRoom> roomSource = new List<BaseRoom>();
        roomSource.Add(new EnergyRoom(1, "Room1", 0, _frame));
        roomSource.Add(new EnergyRoom(2, "Room2", 1, _frame));
        


        _roomContainer.Initialize(ref roomSource);

        _roomContainer.Get(1).ExtendRoom(_frame.Get(0,0));
        _roomContainer.Get(1).ExtendRoom(_frame.Get(1,0));
        

        Debug();

    }

    private unsafe void Debug()
    {
        foreach(var frameItem in _frame)
        {
            System.Console.WriteLine(frameItem.ToString());
        }

        foreach(var roomItem in _roomContainer)
        {
            System.Console.WriteLine(roomItem.ToString());
        }
    }

}