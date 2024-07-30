// Object Pool Design Pattern i asenkron sureclerde orneklendirme

using System.Collections.Concurrent;

ObjectPool<X> pool = ObjectPool<X>.GetInstance;

var t1 = Task.Run(() =>
{
    while (true)
    {
        var x = pool.Get(() => new X());
        if (x != null)
        {
            x.Count++;
            x.Write();
            pool.Return(x);
        }
    }
});

var t2 = Task.Run(() =>
{
    while (true)
    {
        var x = pool.Get(() => new X());
        if (x != null)
        {
            x.Count++;
            x.Write();
            pool.Return(x);
        }
    }
});

await Task.WhenAll(t1, t2);

// ConcurrentBag
/*
 * Asenkron sureclerde kullanilan Thread Safe bir koleksiyondur
 * 
 * Tum thread'ler icin bu koleksiton nesnesinden bir model olusturulmakta ve
 * her bir is parcacigi kendisine ait model uzerinden calismaktadir. Boylece
 * cakisma soz konusu olmamaktadir
 * 
 * Her bir thread icin, eklenen en sonuncu eleman elde edilir. Dolayısıyla herhangi
 * bir thread'de eleman eklenmedigi durumlarda en sonuncu eleman istenildigi taktirde
 * diger thread'ler tarafindan son eleman olarak eklenenlerden biri rastgele alinacak
 * ve geri gonderilecektir
 */

class ObjectPool<T> where T : class
{
    readonly ConcurrentBag<T> _instances;

    readonly List<string> _types = new();

    ObjectPool()
        => _instances = new();

    static ObjectPool<T> _objectPool;

    static ObjectPool() => _objectPool = new ObjectPool<T>();

    static public ObjectPool<T> GetInstance { get => _objectPool; }

    static object _o = new();

    public ConcurrentBag<T> Instances { get => _instances; }

    public T Get(Func<T>? objectGenerator = null)
    {
        // lock lama
        lock (_o)
        {
            var state = _instances.TryTake(out T instance);

            if (!state && !_types.Any(t => t == nameof(T)))
            {
                T generatedInstance = objectGenerator();
                _types.Add(nameof(T));
                return generatedInstance;
            }

            return instance;
        }
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



