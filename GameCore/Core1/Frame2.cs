using System.Collections;
using System.Collections.Generic;

namespace MakoSystems.Sovienation.GameCore;


    /*
        Get index calculation by x,y
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

internal class TestClient2
{
    public TestClient2()
    {
        var itemsSource = GetTestSource();

        // создаю решетку длины 4, высоты 2
        Frame2 frame2 = new Frame2(4,2);
        IFrame2 iframe =(IFrame2)frame2;
        iframe.Initialize(itemsSource);
        DebugLogState(frame2);

        iframe.Set(0,0, 55);
        iframe.Set(3,0, 255);
        iframe.Set(1,0, 55);
        DebugLogState(frame2);

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

    internal Frame2(int width, int height)
    {
        _width = width;
        _height = height;
        _frames = new FrameItem2[width * height];
    }

    public IEnumerator GetEnumerator()
    {
        return _frames.GetEnumerator();
    }


    FrameItem2 IFrame2.Get(int x, int y)
    {
        return _frames[GetIndex(x,y)];
    }

    void IFrame2.Set(int x, int y, int value)
    {
        _frames[GetIndex(x,y)].ObjectId = value;
    }

    private int GetIndex(int x, int y)
    {
        return (y % _height) * _width + x % _width;
    }

    internal static int GetIndex(int width, int height, int x, int y)
        => (y % height) * width + x % width;

    void IFrame2.Initialize(IEnumerable source)
    {
        /*
            i = 3 //(3,0)
            x = i % width = 3
            y = i / width = 0

            i = 7 //(3,1)
            x = i % width = 3
            y = i / width = 1 
        */
        _frames = (FrameItem2[])source;
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


}

internal interface IFrame2
{
    internal void Set(int x, int y, int value);
    internal FrameItem2 Get(int x, int y);
    internal void Initialize(IEnumerable source);
}



internal struct FrameItem2
{ 
    internal FrameItem2(int x, int y)
    {
        X = x;
        Y = y;
        ObjectId = -1;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
    public int ObjectId { get; set; }

    public override string ToString() =>
        $"({X},{Y}):{ObjectId}";
}