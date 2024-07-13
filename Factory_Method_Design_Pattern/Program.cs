// Single Responsibility prensibine uyar
#region Abstract Product
// Concrete productlari ust bir referans ile temsil edebilme
// sistemde diger siniflardan, Patternda uygulayacagimiz siniflarin farkini yaratma
interface IProduct
{
    void Run();
}
#endregion

#region Abstract Factory

interface IFactory
{
    IProduct CreateProduct();
}
#endregion

#region Concrete Products
// surecte uretmeyi hedefledigimiz nesne gruplari
class A : IProduct
{
    public A()
    {
        Console.WriteLine($"{nameof(A)} nesnesi uretildi");
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}

class B : IProduct
{
    public B()
    {
        Console.WriteLine($"{nameof(B)} nesnesi uretildi");
    }
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class C : IProduct
{
    public C()
    {
        Console.WriteLine($"{nameof(C)} nesnesi uretildi");
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}
#endregion

#region Concrete Factories

class AFactory : IFactory
{
    public IProduct CreateProduct()
    {
        A a = new A();
        return a;
    }
}

class BFactory : IFactory
{
    public IProduct CreateProduct()
    {
        B b = new B();
        return b;
    }
}

class CFactory : IFactory
{
    public IProduct CreateProduct()
    {
        C c = new C();
        return c;
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

        IFactory _factory = productType switch
        {
            ProductType.A => new AFactory(),
            ProductType.B => new BFactory(),
            ProductType.C => new CFactory()
        };
        return _factory.CreateProduct();
    }
}
#endregion