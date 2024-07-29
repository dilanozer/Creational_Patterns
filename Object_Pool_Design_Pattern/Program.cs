using System.Collections.Concurrent;

ObjectPool<X> pools = new ObjectPool<X>();
// Creation evresi
var x1 = pools.Get(() => new X()); // objectGenerator() calisir
x1.Count++;
// operasyonlar
pools.Return(x1); // havuza x1 i atma

// Validation evresi
var x2 = pools.Get(() => new X()); // var olan instance i doner, haliyle x1 ile x2 ayni nesne
x2.Count++;
pools.Return(x2); // x2 i pool a gonderme

var x3 = pools.Get(() => new X());
x3.Count++;
pools.Return(x3);

// Destroy evresi -> ilgili nesneyi pool a atmazdan garbage collector a gider

Console.WriteLine();

class ObjectPool<T> where T : class
{
    // Pool
    readonly ConcurrentBag<T> _instances;

    public ObjectPool()
    {
        _instances = new();
    }

    // pool da nesnenin var olup olmadigini kontrol etmek icin, disariya acilan property
    public ConcurrentBag<T> Instances { get => _instances; }

    public T Get(Func<T>? objectGenerator = null)
    {
        // havuzdan generic parametrede bildirilen turdeki nesneyi geri dondurmek
        return _instances.TryTake(out T instance) ? instance : objectGenerator();
    }

    public void Return(T instance)
    {
        // havuzdan odunc alinan nesneyi geri iade etmek
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

