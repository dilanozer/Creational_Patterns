// Object Pool operasyonunu gerceklestiren sinifi Singleton olarak tasarlama
// uygulamanin genelinde object pooling davranisini daha rahat bir sekilde kullanabilme

using System.Collections.Concurrent;

ObjectPool<X> pools = ObjectPool<X>.GetInstance;
var x1 = pools.Get(() => new X()); 
x1.Count++;
// operasyonlar
pools.Return(x1); 

var x2 = pools.Get(() => new X()); 
x2.Count++;
pools.Return(x2); 

var x3 = pools.Get(() => new X());
x3.Count++;
pools.Return(x3);

Console.WriteLine();

class ObjectPool<T> where T : class
{
    readonly ConcurrentBag<T> _instances;

    // dis dunyadan erisimi kesme
    ObjectPool()
        => _instances = new();

    // object pool nesnesinin instance inin uretimini static constructor ile saglama
    static ObjectPool<T> _objectPool;

    static ObjectPool() => _objectPool = new ObjectPool<T>();

    // nesneyi disari verecek bir property 
    static public ObjectPool<T> GetInstance { get => _objectPool; }

    public ConcurrentBag<T> Instances { get => _instances; }

    public T Get(Func<T>? objectGenerator = null)
    {
        return _instances.TryTake(out T instance) ? instance : objectGenerator();
    }

    public void Return(T instance)
    {
        _instances.Add(instance);
    }

}

class X
{
    public int Count { get; set; }

    public void Write() => Console.WriteLine(Count);

    public X() => Console.WriteLine("X üretim maliyeti...");

    ~X() => Console.WriteLine("X imha maliyeti...");
}

