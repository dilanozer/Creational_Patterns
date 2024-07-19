Example ex1 = Example.GetInstance;
Example ex2= Example.GetInstance;
Example ex3 = Example.GetInstance;
Example ex4 = Example.GetInstance;

class Example
{
    Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi olusturuldu");
    }

    #region 2. Yöntem
    static Example()
    {
        _example = new Example();
    }
    #endregion

    static Example _example;

    // nesne uretme sorumlulugunu ustlenir
    public static Example GetInstance
    {
        get {
            #region 1. Yöntem
            // if (_example == null)
            //    _example = new Example();
            // return _example;
            #endregion

            #region 2. Yöntem
            return _example;
            #endregion
        }
    }
}
 
