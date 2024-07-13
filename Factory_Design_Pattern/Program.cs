while (true)
{
    for (int i = 0; i < 100; i++)
    {
        try
        {
            A? a = ProductCreator.GetInstance(ProductType.A) as A;
            a.Run();

            B? b = ProductCreator.GetInstance(ProductType.B) as B;
            b.Run();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

#region Abstract Product
// Concrete productlari ust bir referans ile temsil edebilme
// sistemde diger siniflardan, Patternda uygulayacagimiz siniflarin farkini yaratma
interface IProduct
{
    void Run();
}
#endregion


#region Concrete Products
// surecte uretmeyi hedefledigimiz nesne gruplari
class A : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class B : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class C : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}
#endregion


#region Creator
// Concrete productlari yardimci bir sinifin uzerinde uretimlerini saglayarak
// ihtiyac noktasinda kullanabilme

// tamsayilari metinsel ifadeler ile temsil etme
enum ProductType
{
    A, B, C
}

class ProductCreator
{
    // A, B, C nesnelerinin talebini alabilecegi ve talep edilen nesneyi uretip
    // dondurebilecegi metot

    // i degerine gore A,B veya C nesneleri uretilecegi icin, polimorfizm geregi
    // butun nesneleri temsil edecek IProduct referansinda ilgili nesneyi donme

    static public IProduct GetInstance(ProductType productType)
    {
        // i == 0 -> A
        // i == 1 -> B
        // i == 2 -> C

        IProduct _product = null; // uretilecek nesne 

        switch (productType)
        {
            case ProductType.A:
                _product = new A();
                break;
            case ProductType.B:
                _product = new B();
                break;
            case ProductType.C:
                _product = new C();
                break;
            default:
                break;
        }

        return _product;
    }
}
#endregion



