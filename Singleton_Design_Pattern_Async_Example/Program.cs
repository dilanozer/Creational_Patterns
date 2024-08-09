List<Task> tasks = new();

for (int i = 0; i < 100; i++)
{
    tasks.Add(Task.Run(() =>
    {
        Example.GetInstance();
    }));
}

await Task.WhenAll(tasks);

class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturulmuştur");
    }

    #region 2. Yontem
    static Example()
    {
        _example = new Example();
    }
    #endregion

    static Example _example;
    static object _obj = new object();

    static public Example GetInstance()
    {
        #region 1. Yontem
        /*
        lock (_obj)
        {
            if (_example == null)
                _example = new Example();
        }
        */
        #endregion

        return _example;
    }
}
