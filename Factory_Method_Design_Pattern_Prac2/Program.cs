GarantiBank? garantiBank = BankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank = BankCreator.Create(BankType.Halkbank) as HalkBank;
VakifBank? vakifBank = BankCreator.Create(BankType.Vakifbank) as VakifBank;

#region Abstract Product

interface IBank
{

}
#endregion

#region Concrete Products

class GarantiBank : IBank
{
    string _userCode, _password;

    public GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi olusturuldu");
        _userCode = userCode;
        _password = password;
    }

    public void ConnectGaranti() => Console.WriteLine($"{nameof(GarantiBank)} - Connected");

    public void SendMoney(int amount) => Console.WriteLine($"{amount} money sent");
}

class HalkBank : IBank
{
    string _userCode, _password;

    public HalkBank(string userCode)
    {
        Console.WriteLine($"{nameof(HalkBank)} nesnesi olusturuldu");
        _userCode = userCode;
    }

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

    public VakifBank(CredentialVakifBank credential, string password)
    {
        Console.WriteLine($"{nameof(VakifBank)} nesnesi olusturuldu");
        _userCode = credential.UserCode;
        _email = credential.Mail;
        _password = password;
    }

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

class GarantiFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        GarantiBank garanti = new("ayse", "123");
        garanti.ConnectGaranti();
        return garanti;
    }
}

class HalkBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        HalkBank halkBank = new("ayse");
        halkBank.Password = "123";
        return halkBank;
    }
}

class VakifBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        VakifBank vakifBank = new(new() { Mail = "ayse@gmail.com", UserCode = "ayse" }, "123");
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
            BankType.Vakifbank => new VakifBankFactory(),
            BankType.Halkbank => new HalkBankFactory(),
            BankType.Garanti => new GarantiFactory()
        };

        return _bankFactory.CreateInstance();
    }
}
#endregion
