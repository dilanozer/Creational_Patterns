GarantiBank? garantiBank = BankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank = BankCreator.Create(BankType.Halkbank) as HalkBank;
VakifBank? vakifBank = BankCreator.Create(BankType.Vakifbank) as VakifBank;

GarantiBank? garantiBank2 = BankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank2 = BankCreator.Create(BankType.Halkbank) as HalkBank;
VakifBank? vakifBank2 = BankCreator.Create(BankType.Vakifbank) as VakifBank;

GarantiBank? garantiBank3 = BankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank3 = BankCreator.Create(BankType.Halkbank) as HalkBank;
VakifBank? vakifBank3 = BankCreator.Create(BankType.Vakifbank) as VakifBank;

#region Abstract Product

interface IBank
{

}
#endregion

#region Concrete Products

class GarantiBank : IBank
{
    string _userCode, _password;

    GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi olusturuldu");
        _userCode = userCode;
        _password = password;
    }

    // Product nesnesini singleton yapma

    // Factory sinifindan yapilacak olan taleplerde, ilkinde nesne uretilir ve
    // sonrasinda olan taleplerde ayni Product nesneleri kullanilmaya devam edecek
    static GarantiBank() => _garantiBank = new("ayse", "123");
    static GarantiBank _garantiBank;
    static public GarantiBank GetInstance => _garantiBank;

    public void ConnectGaranti() => Console.WriteLine($"{nameof(GarantiBank)} - Connected");

    public void SendMoney(int amount) => Console.WriteLine($"{amount} money sent");
}

class HalkBank : IBank
{
    string _userCode, _password;

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
    GarantiBankFactory() { }
    static GarantiBankFactory _garantiFactory;
    static GarantiBankFactory() => _garantiFactory = new();
    static public GarantiBankFactory GetInstance => _garantiFactory;

    public IBank CreateInstance()
    {
        GarantiBank garanti = GarantiBank.GetInstance;
        garanti.ConnectGaranti();
        return garanti;
    }
}

class HalkBankFactory : IBankFactory
{
    // singleton
    HalkBankFactory() { }
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
    VakifBankFactory() { }
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
    Garanti, Halkbank, Vakifbank
}

class BankCreator
{
    static public IBank Create(BankType bankType)
    {
        IBankFactory _bankFactory = bankType switch
        {
            BankType.Vakifbank => VakifBankFactory.GetInstance,
            BankType.Halkbank => HalkBankFactory.GetInstance,
            BankType.Garanti => GarantiBankFactory.GetInstance
        };

        return _bankFactory.CreateInstance();
    }
}
#endregion
