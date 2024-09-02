//Mercedes
//Araba mercedes = new();
//mercedes.KM = 0;
//mercedes.Marka = "Mercedes";
//mercedes.Model = "";
//mercedes.Vites = true;

ArabaDirector director = new();
Araba opel = director.Build(new OpelBuilder());
opel.ToString();
Araba mercedes = director.Build(new MercedesBuilder());
mercedes.ToString();
Araba bmw = director.Build(new BMWBuilder());
bmw.ToString();

#region Product
class Araba
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public double KM { get; set; }
    public bool Vites { get; set; }
    public override string ToString()
    {
        Console.WriteLine($"{Marka} marka araba {Model} modelinde {KM} kilometrede {Vites} vites olarak üretilmiştir.");
        return base.ToString();
    }
}
#endregion

#region Interface ile Abstract Builder'in Tasarlanmasi
//#region Abstract Builder
//interface IArabaBuilder
//{
//    Araba Araba { get; }
//    IArabaBuilder SetMarka();
//    IArabaBuilder SetModel();
//    IArabaBuilder SetKM();
//    IArabaBuilder SetVites();
//}
//#endregion

//#region Concrete Builder
//class OpelBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }

//    public OpelBuilder() => Araba = new();

//    public IArabaBuilder SetKM()
//    {
//        Araba.KM = 0;
//        return this;
//    }
//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Opel";
//        return this;
//    }
//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "ope";
//        return this;
//    }
//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}

//class MercedesBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }

//    public MercedesBuilder() => Araba = new();

//    public IArabaBuilder SetKM()
//    {
//        Araba.KM = 100;
//        return this;
//    }
//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Mercedes";
//        return this;
//    }
//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "mer";
//        return this;
//    }
//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}

//class BMWBuilder : IArabaBuilder
//{
//    public Araba Araba { get; set; }

//    public BMWBuilder() => Araba = new();

//    public IArabaBuilder SetKM()
//    {
//        Araba.KM = 10;
//        return this;
//    }
//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "BMW";
//        return this;
//    }
//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "bmw";
//        return this;
//    }
//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}
//#endregion

//#region Director
//class ArabaDirector
//{
//    public Araba Build(IArabaBuilder arabaBuilder)
//    {
//        //arabaBuilder.SetMarka();
//        //arabaBuilder.SetModel();
//        //arabaBuilder.SetKM();
//        //arabaBuilder.SetVites();

//        //fluent pattern
//        arabaBuilder
//            .SetMarka()
//            .SetModel()
//            .SetVites()
//            .SetKM();

//        return arabaBuilder.Araba;
//    }
//}
//#endregion
#endregion

#region Abstract Class ile Abstract Builder'in Tasarlanmasi
#region Abstract Builder
abstract class ArabaBuilder
{
    protected Araba araba;
    public Araba Araba { get => araba; }

    public ArabaBuilder() => araba = new();

    public abstract ArabaBuilder SetMarka();
    public abstract ArabaBuilder SetModel();
    public abstract ArabaBuilder SetKM();
    public abstract ArabaBuilder SetVites();
}
#endregion

#region Concrete Builder
class OpelBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        araba.KM = 0;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "Opel";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "ope";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = true;
        return this;
    }
}

class MercedesBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        araba.KM = 100;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "mercedes";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "mer";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = true;
        return this;
    }
}

class BMWBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        araba.KM = 10;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "BMW";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "bmw";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = true;
        return this;
    }
}
#endregion

#region Director
class ArabaDirector
{
    public Araba Build(ArabaBuilder arabaBuilder)
    {
        arabaBuilder
            .SetKM()
            .SetMarka()
            .SetModel()
            .SetVites();

        return arabaBuilder.Araba;
    }
}
#endregion
#endregion
