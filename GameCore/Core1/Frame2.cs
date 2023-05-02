using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;
using System.Runtime.InteropServices;

namespace MakoSystems.Sovienation.GameCore;


    /*
        FROM X,Y TO i

        0 1 2 3   | 0
        4 5 6 7   | 1
        - - - -     y
        0 1 2 3 x

        length = 8
        height = 2
        width  = 4

        // in: (x,y); out: Array.Index
        c1) Get(2,0) // Array.Index => 2
        c2) Get(3,1) // Array.Index => 7

        c1) h = (y)/height = (0)/2 = 0
            l = (x)/width =  (2)/4 = 2
            i = h*width+l => 0*4+2 => out 2

        c2) h = (y)/height = 1/2 = 1
            l = (x)/width = 3/4 = 3
            i = h*width+l => 1*4+3 =>5

    */

    /*
        FROM i to X,Y
        
        i = 3 //(3,0)
        x = i % width = 3
        y = i / width = 0

        i = 7 //(3,1)
        x = i % width = 3
        y = i / width = 1 
    */

internal class TestClient2
{
    public TestClient2()
    {
        //var itemsSource = GetTestSource();
        XDocument doc = LoadXml();
        IXmlInitilizeQuery<FrameItem2> itemSourceQuery = new FrameXmlInitializeQuery(doc);  // вариант загрузки из xml

        // создаю решетку длины 4, высоты 2
        Frame2 frame2 = new Frame2(5,5);
        IFrame2 iframe =(IFrame2)frame2;
        //iframe.Initialize(itemSourceQuery);
        iframe.Intialize();
        
        DebugLogState(frame2);

        iframe.Set(4,4, 55);    // занять элемент фрейма объектом с id=55
        iframe.Set(3,3, 255);   // занять элемент фрейма объектом с id=255
        iframe.Set(1,0, 55);
        DebugLogState(frame2);
    }

    private XDocument LoadXml()
    {
        var filename = "frame.xml";
        var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var filePath = Path.Combine(currentDir, filename);

        XElement frame = XElement.Load(filePath);
        return XDocument.Load(filePath);
    }

    private FrameItem2[] GetTestSource()
    {
        var initSource = new FrameItem2[4 * 2];
        for(int y=0; y < 2; y++)
        {
            for(int x=0; x < 4; x++)
            {
                initSource[Frame2.GetIndex(4,2,x,y)] = new FrameItem2(x, y);
            }
        }
        return initSource;
    }

    private void DebugLogState(IEnumerable frame)
    {
        System.Console.WriteLine("====================");
        foreach(var item in frame)
        {
            System.Console.WriteLine(item.ToString());
        }
    }
}
/*
    void set(x,y,value)
    value get(x,y)
    initialize(source)
*/
internal class Frame2 : IFrame2, IEnumerable
{
    private int _width, _height;
    private FrameItem2[] _frames;
    private const int _freeId = -1;

    internal Frame2(int width, int height)
    {
        _width = width;
        _height = height;
        _frames = new FrameItem2[width * height];
    }
    private Frame2(FrameItem2[] frames, int width, int height)
    {
        _frames = frames;
        _width = width;
        _height = height;
    }

    public IEnumerator GetEnumerator()
    {
        return _frames.GetEnumerator();
    }

    FrameItem2 IFrame2.Get(int x, int y)
    {
        return _frames[GetIndex(x,y)];
    }
    
    void IFrame2.Set(int x, int y, int objectId)
    {
        _frames[GetIndex(x,y)].ObjectId = objectId;
    }
    
    void IFrame2.Set(int x, int y, int width, int height, int objectId)
    {
        for(int ix = x; ix < x+width; ix++)
        {
            for(int iy = x; iy < y+width; iy++)
            {
                _frames[GetIndex(ix, iy)].ObjectId = objectId;
            }
        }
    }
    
    void IFrame2.Free(int x, int y)
    {
        ((IFrame2)this).Free(x,y);
    }

    void IFrame2.Free(int x, int y, int width, int height)
    {
        ((IFrame2)this).Free(x, y, width, height);
    }

    void IFrame2.Initialize(IEnumerable source)
    {
        _frames = (FrameItem2[])source;
    }
    void IFrame2.Initialize(IXmlInitilizeQuery<FrameItem2> initializeQuery)
    {
        _frames = initializeQuery.Get();
    }
    void IFrame2.Intialize()
    {
        for(int x = 0; x < _width; x++)
        {
            for(int y =0; y < _height; y++)
            {
                _frames[GetIndex(x, y)] = new FrameItem2(x, y) {ObjectId = _freeId};
            }
        }
    }


    internal static int GetIndex(int width, int height, int x, int y)
        => (y % height) * width + x % width;

    private int GetIndex(int x, int y)
    {
        return (y % _height) * _width + x % _width;
    }



    void InitTest()
    {
        for(int y=0; y < _height; y++)
        {
            for(int x=0; x < _width; x++)
            {
                _frames[GetIndex(x,y)] = new FrameItem2(x, y);
            }
        }
    }
    void InternalDebug()
    {
        for(int i=0; i< _frames.Length; i++)
        {
            var f = _frames[i];
            System.Console.WriteLine($"i: {i}, x:{f.X}, y:{f.Y}, val: {f.ObjectId}");
        }
    }

    internal byte[] Serialize()
    {
        int frameSize = Marshal.SizeOf(typeof(FrameItem2)) * _frames.Length; 
        byte[] frameBytes = new byte[frameSize];

        GCHandle handle = GCHandle.Alloc(frameBytes, GCHandleType.Pinned);
        try
        {
            IntPtr ptr = handle.AddrOfPinnedObject();
            for(int i=0; i < _frames.Length; i++)
            {
                Marshal.StructureToPtr(_frames[i], ptr, false);
                ptr += Marshal.SizeOf(typeof(FrameItem2));
            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine("Exception when serialize: {0}", ex);
        }
        finally
        {
            handle.Free();
        }

        int totalSize = sizeof(int) + sizeof(int) + frameSize;
        byte[] buffer = new byte[totalSize];

        int offset = 0;
        Buffer.BlockCopy(BitConverter.GetBytes(_width), 0, buffer, offset, sizeof(int));
        offset += sizeof(int);
        Buffer.BlockCopy(BitConverter.GetBytes(_height), 0, buffer, offset, sizeof(int));
        offset += sizeof(int);
        Buffer.BlockCopy(frameBytes, 0, buffer, offset, frameBytes.Length);
        offset += Marshal.SizeOf(typeof(FrameItem2)) * _frames.Length;

        return buffer;
    }

    internal static Frame2 Deserialize(byte[] data)
    {
        int offset = 0;
        int width = BitConverter.ToInt32(data, offset);
        offset += sizeof(int);
        int height = BitConverter.ToInt32(data, offset);
        offset += sizeof(int);
        
        int frameItemsLength = (data.Length - offset) / Marshal.SizeOf(typeof(FrameItem2));
        FrameItem2[] items = new FrameItem2[frameItemsLength];
        GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);

        try
        {
            
        }

        // var size = data.Length / Marshal.SizeOf(typeof(FrameItem2));
        // FrameItem2[] frameItems = new FrameItem2[size];
        // GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        // try
        // {
        //     IntPtr ptr = handle.AddrOfPinnedObject();
        //     for(int i=0; i < frameItems.Length; i++)
        //     {
        //         frameItems[i] = (FrameItem2)Marshal.PtrToStructure(ptr, typeof(FrameItem2));
        //         ptr += Marshal.SizeOf(typeof(FrameItem2));
        //     }
        // }
        // catch
        // {
        //     System.Console.WriteLine("Exception when deserialize");
        // }
        // finally
        // {
        //     handle.Free();
        // }
    }
}

interface IXmlInitilizeQuery<T>
{
    internal T[] Get();
}

internal class FrameXmlInitializeQuery : IXmlInitilizeQuery<FrameItem2>
{
    private XDocument _doc;
    internal FrameXmlInitializeQuery(XDocument doc)
    {
        _doc = doc;
    }
    FrameItem2[] IXmlInitilizeQuery<FrameItem2>.Get()
    {
        return _doc.Root
                .Elements("Item")
                .Select(x => new FrameItem2(
                    (int)x.Attribute("X"), (int)x.Attribute("Y")))
                .ToArray();
    }
}

internal interface IFrame2
{
    internal void Set(int x, int y, int objectId);
    internal void Set(int x, int y, int width, int height, int objectId);
    internal void Free(int x, int y);
    internal void Free(int x, int y, int width, int height);
    internal FrameItem2 Get(int x, int y);
    internal void Intialize();
    [Obsolete]
    internal void Initialize(IEnumerable source);
    [Obsolete]
    internal void Initialize(IXmlInitilizeQuery<FrameItem2> initializeQuery);
}



internal struct FrameItem2
{ 
    private int _x;
    private int _y;
    private int _objectId;
    internal FrameItem2(int x, int y)
    {
        _x = x;
        _y = y;
        _objectId = -1;
    }
    public int X { get => _x; }
    public int Y { get => _y; }
    public int ObjectId
    {
        get => _objectId;
        set => _objectId = value;
    }

    public override string ToString() =>
        $"({_x},{_y}):{_objectId}";
}