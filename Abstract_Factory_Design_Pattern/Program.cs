ComputerCreator creator = new();

Computer asus =  creator.CreateComputer(new AsusFactory());
Computer toshiba = creator.CreateComputer(new ToshibaFactory());

// elde edilecek nesne
class Computer
{

    public Computer(ICPU cPU, IRAM rAM, IVideoCard videoCard)
    {
        CPU = cPU;
        RAM = rAM;
        VideoCard = videoCard;
    }

    public Computer()
    {

    }

    public ICPU CPU { get; set; }
    public IRAM RAM { get; set; }
    public IVideoCard VideoCard { get; set; }
}

#region Abstract Products
interface ICPU { }

interface IRAM { }

interface IVideoCard { }
#endregion

#region Concrete Products
// uretilmesi gereken nesneler:  Products

class CPU : ICPU
{
    public CPU(string text)
        => Console.WriteLine(text);
}

class RAM : IRAM
{
    public RAM(string text)
        => Console.WriteLine(text);
}

class VideoCard : IVideoCard
{
    public VideoCard(string text)
        => Console.WriteLine(text);
}
#endregion

#region Abstract Factory

interface IComputerFactory
{
    ICPU CreateCPU();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();
}
#endregion

#region Concrete Factories

class AsusFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU($"Asus CPU üretildi");

    public IRAM CreateRAM()
        => new RAM($"Asus RAM üretildi");

    public IVideoCard CreateVideoCard()
        => new VideoCard($"Asus Video Card üretildi");
}

class ToshibaFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU($"Toshiba CPU üretildi");

    public IRAM CreateRAM()
        => new RAM($"Toshiba RAM üretildi");

    public IVideoCard CreateVideoCard()
        => new VideoCard($"Toshiba Video Card üretildi");
}

class MSIFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU($"MSI CPU üretildi");

    public IRAM CreateRAM()
        => new RAM($"MSI RAM üretildi");

    public IVideoCard CreateVideoCard()
        => new VideoCard($"MSI Video Card üretildi");
}
#endregion

#region Creator

class ComputerCreator
{
    ICPU _cpu;
    IRAM _ram;
    IVideoCard _videoCard;

    public Computer CreateComputer(IComputerFactory computerFactory)
    {
        _cpu = computerFactory.CreateCPU();
        _ram = computerFactory.CreateRAM();
        _videoCard = computerFactory.CreateVideoCard();

        return new(_cpu, _ram, _videoCard);
    }
}
#endregion
