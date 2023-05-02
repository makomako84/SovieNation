using System.Runtime.InteropServices;
using System.Collections;

namespace MakoSystems.Sovienation.GameCore;

public class Session
{
    private Guid _id;
    private IRoomPool _loadedRooms;
    //private readonly Frame _frame;
    private readonly RoomContainer _roomContainer;

    private readonly IFrame2 _frame;

    public Session()
    {
        _id = Guid.NewGuid();

        _frame = new Frame2(5,5);
        //iframe.Initialize(itemSourceQuery);
        _frame.Intialize();

        _frame.Set(4,4, 55);    // занять элемент фрейма объектом с id=55
        _frame.Set(3,3, 255);   // занять элемент фрейма объектом с id=255
        _frame.Set(1,0, 55);
        
        System.Console.WriteLine($"Frame Initialized for session {_id}");

    }

    public byte[] GetFrames()
    {
        return ((Frame2)_frame).Serialize();
    }

    // private void Test1()
    // {


    //     IList<FrameItem> frameSource = new List<FrameItem>();
    //     // special frame item for Entry block
    //     frameSource.Add(new FrameItem(-1, 0, _frame)); 

    //     // common frame items
    //     frameSource.Add(new FrameItem(0, 0, _frame));
    //     frameSource.Add(new FrameItem(1, 0, _frame));
    //     frameSource.Add(new FrameItem(0, 1, _frame));
    //     frameSource.Add(new FrameItem(1, 1, _frame));
    //     _frame.Initialize(ref frameSource);

        
    //     IList<BaseRoom> roomSource = new List<BaseRoom>();
    //     roomSource.Add(new EnergyRoom(1, "Room1", 0, _frame));
    //     roomSource.Add(new EnergyRoom(2, "Room2", 1, _frame));
        


    //     _roomContainer.Initialize(ref roomSource);

    //     _roomContainer.Get(1).ExtendRoom(_frame.Get(0,0));
    //     _roomContainer.Get(1).ExtendRoom(_frame.Get(1,0));
    // }



}