//ArabaDirector director = new();
//Araba opel = director.Build(new OpelBuilder());
//opel.ToString();
//Araba mercedes = director.Build(new MercedesBuilder());
//mercedes.ToString();
//Araba bmw = director.Build(new BMWBuilder());
//bmw.ToString();

ArabaDirector director = new();
Araba opel = director.Build(BuilderCreator.Create(BuilderType.Opel));
opel.ToString();
Araba mercedes = director.Build(BuilderCreator.Create(BuilderType.Mercedes));
mercedes.ToString();
Araba bmw = director.Build(BuilderCreator.Create(BuilderType.BMW));
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

#region Abstract Builder & (Factory DP) Abstract Product 
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

#region Concrete Builder & (Factory DP) Product
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

#region (Factory DP) Creator
enum BuilderType
{
    Opel, Mercedes, BMW
}

class BuilderCreator
{
    static public ArabaBuilder Create(BuilderType builderType)
    {
        return builderType switch
        {
            BuilderType.Opel => new OpelBuilder(),
            BuilderType.Mercedes => new MercedesBuilder(),
            BuilderType.BMW => new BMWBuilder()
        };
    }
}
#endregion