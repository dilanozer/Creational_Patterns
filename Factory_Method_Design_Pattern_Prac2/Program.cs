using System.Reflection;

GarantiBank? garantiBank = BankCreator.Create(BankType.GarantiBank) as GarantiBank;
HalkBank? halkBank = BankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifBank = BankCreator.Create(BankType.VakifBank) as VakifBank;

GarantiBank? garantiBank2 = BankCreator.Create(BankType.GarantiBank) as GarantiBank;
HalkBank? halkBank2 = BankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifBank2 = BankCreator.Create(BankType.VakifBank) as VakifBank;

GarantiBank? garantiBank3 = BankCreator.Create(BankType.GarantiBank) as GarantiBank;
HalkBank? halkBank3 = BankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifBank3 = BankCreator.Create(BankType.VakifBank) as VakifBank;

#region Abstract Product

interface IBank
{

}
#endregion

#region Concrete Products

class GarantiBank : IBank
{
    string _userCode, _password;

    // constructor private yapilarak developerlarin product nesnelerinden new operatoru ile nesne
    // uretmesini engeller
    GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi olusturuldu");
        _userCode = userCode;
        _password = password;
    }

    // Product nesnesini singleton yapma:

    // Nesne uretiminin sorumlulugu factoryde degildir, sinifin kendisindedir
    
    // Factory sinifindan yapilacak olan taleplerde, ilkinde nesne uretilir ve
    // sonrasinda olan taleplerde ayni Product nesneleri kullanilmaya devam edecek
    static GarantiBank() => _garantiBank = new("ayse", "123"); // nesne uretimi
    static GarantiBank _garantiBank;
    // client in nesne talebinde bulunabilmesi icin member tanimlama
    static public GarantiBank GetInstance => _garantiBank; 

    public void ConnectGaranti() => Console.WriteLine($"{nameof(GarantiBank)} - Connected");

    public void SendMoney(int amount) => Console.WriteLine($"{amount} money sent");
}

class HalkBank : IBank
{
    string _userCode, _password;

    // constructor private yapilarak developerlarin product nesnelerinden new operatoru ile nesne
    // uretmesini engeller
    HalkBank(string userCode)
    {
        Console.WriteLine($"{nameof(HalkBank)} nesnesi olusturuldu");
        _userCode = userCode;
    }

    // Product nesnesini singleton yapma

    // Factory sinifindan yapilacak olan taleplerde, ilkinde nesne uretilir ve
    // sonrasinda olan taleplerde ayni Product nesneleri kullanilmaya devam edecek
    static HalkBank() => _halkBank = new("ayse");
    static HalkBank _halkBank;
    static public HalkBank GetInstance => _halkBank;

    public string Password { set => _password = value; }

    public void Send(int amount, string accountNumber) => Console.WriteLine($"{amount} money sent");
}

class CredentialVakifBank
{
    public string UserCode { get; set; }
    public string Mail { get; set; }
}

class VakifBank : IBank
{
    string _userCode, _email, _password;

    public bool isAuthentication { get; set; }

    // constructor private yapilarak developerlarin product nesnelerinden new operatoru ile nesne
    // uretmesini engeller
    VakifBank(CredentialVakifBank credential, string password)
    {
        Console.WriteLine($"{nameof(VakifBank)} nesnesi olusturuldu");
        _userCode = credential.UserCode;
        _email = credential.Mail;
        _password = password;
    }

    // product nesnesini singleton yapma

    // Factory sinifindan yapilacak olan taleplerde, ilkinde nesne uretilir ve
    // sonrasinda olan taleplerde ayni Product nesneleri kullanilmaya devam edecek
    static VakifBank() => _vakifBank = new(new() { Mail = "ayse@gmail.com", UserCode = "ayse" }, "123");
    static VakifBank _vakifBank;
    static public VakifBank GetInstance => _vakifBank;

    public void ValidateCredential()
    {
        if (true) // validating
            isAuthentication = true;
    }

    public void SendMoneyToAccountNumber(int amount, string recipientName, string accountNumber)
        => Console.WriteLine($"{amount} money sent");
}
#endregion

#region Abstract Factory

interface IBankFactory
{
    IBank CreateInstance();
}

#endregion

#region Concrete Factories

class GarantiBankFactory : IBankFactory
{
    // singleton
    public GarantiBankFactory() { } // constructor i private ayarlama
    static GarantiBankFactory() => _garantiBankFactory = new(); // factory i doldurma
    static GarantiBankFactory _garantiBankFactory; // static olarak factory sinifindan referans alma
    // bu referans noktasini disariya kontrollu bir sekilde acmayi saglayacak static property
    static public GarantiBankFactory GetInstance => _garantiBankFactory;  

    public IBank CreateInstance()
    {
        GarantiBank garantiBank = GarantiBank.GetInstance;
        garantiBank.ConnectGaranti();
        return garantiBank;
    }
}

class HalkBankFactory : IBankFactory
{
    // singleton
    public HalkBankFactory() { }
    static HalkBankFactory() => _halkBankFactory = new();
    static HalkBankFactory _halkBankFactory;
    static public HalkBankFactory GetInstance => _halkBankFactory;

    public IBank CreateInstance()
    {
        HalkBank halkBank = HalkBank.GetInstance;
        halkBank.Password = "123";
        return halkBank;
    }
}

class VakifBankFactory : IBankFactory
{
    // singleton
    public VakifBankFactory() { }
    static VakifBankFactory() => _vakifBankFactory = new();
    static VakifBankFactory _vakifBankFactory;
    static public VakifBankFactory GetInstance => _vakifBankFactory;

    public IBank CreateInstance()
    {
        VakifBank vakifBank = VakifBank.GetInstance;
        vakifBank.ValidateCredential();
        return vakifBank;
    }
}
#endregion

#region Creator

enum BankType
{
    GarantiBank, HalkBank, VakifBank
}

class BankCreator
{
    static public IBank Create(BankType bankType)
    {
        //IBankFactory _bankFactory = bankType switch
        //{
        //    BankType.Vakifbank => VakifBankFactory.GetInstance,
        //    BankType.Halkbank => HalkBankFactory.GetInstance,
        //    BankType.Garanti => GarantiBankFactory.GetInstance
        //};

        //return _bankFactory.CreateInstance();

        // Sorun:
        // Creator sinifi, factory lere bagimlilik sergiler. Reflection calismasi ile
        // bu bagimliligi kaldirabiliriz

        // Cozum:
        // 
        string factory = $"{bankType.ToString()}Factory";
        Type? type = Assembly.GetExecutingAssembly().GetType(factory);
        IBankFactory? bankFactory = Activator.CreateInstance(type) as IBankFactory;
        return bankFactory.CreateInstance();
    }
}
#endregion
