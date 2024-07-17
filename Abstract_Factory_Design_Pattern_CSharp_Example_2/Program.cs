// Concrete classlarin daha ozellestirilmis hali

DatabaseCreator creator = new DatabaseCreator();
Database mysql = creator.Create(new MySqlDatabaseFactory());
Database mssql = creator.Create(new MsSqlDatabaseFactory());

Console.WriteLine();

#region Abstract Product

enum ConnectionState
{
    Open, Close
}

abstract class Connection
{
    public abstract bool Connect();
    public abstract bool Disconnect();
    public abstract ConnectionState State { get; set; }
}

abstract class Command
{
    public abstract void Execute(string query);
}
#endregion

#region Concrete Products

class MsSqlConnection : Connection
{
    public override ConnectionState State { get; set; }

    public override bool Connect()
    {
        Console.WriteLine("MsSqlConnection baglantisi gerceklestirildi");
        State = ConnectionState.Open;
        return true;
    }

    public override bool Disconnect()
    {
        Console.WriteLine("MsSqlConnection baglantisi koparildi");
        State = ConnectionState.Close;
        return true;
    }
}

class MySqlConnection : Connection
{
    public override ConnectionState State { get; set; }

    public override bool Connect()
    {
        Console.WriteLine("MySqlConnection baglantisi gerceklestirildi");
        State = ConnectionState.Open;
        return true;
    }

    public override bool Disconnect()
    {
        Console.WriteLine("MySqlConnection baglantisi koparildi");
        State = ConnectionState.Close;
        return true;
    }
}

class MsSqlCommand : Command
{
    public override void Execute(string query)
    {
        Console.WriteLine(query);
    }
}

class MySqlCommand : Command
{
    public override void Execute(string query)
    {
        Console.WriteLine(query);
    }
}

#endregion

#region Abstract Factory

abstract class DatabaseFactory
{
    public abstract Connection CreateConnection();
    public abstract Command CreateCommand();
}

#endregion

#region Concrete Factory

class MsSqlDatabaseFactory : DatabaseFactory
{
    public override Command CreateCommand()
    {
        MsSqlCommand command = new();
        return command;
    }

    public override Connection CreateConnection()
    {
        MsSqlConnection connection = new();
        // connection string set
        return connection;
    }
}

class MySqlDatabaseFactory : DatabaseFactory
{
    public override Command CreateCommand()
    {
        MsSqlCommand command = new();
        return command;
    }

    public override Connection CreateConnection()
    {
        MsSqlConnection connection = new();
        // connection string set
        return connection;
    }
}

#endregion

#region Creator

class DatabaseCreator
{
    public Database Create(DatabaseFactory databaseFactory)
    {
        return new Database()
        {
            Command = databaseFactory.CreateCommand(),
            Connection = databaseFactory.CreateConnection()
        };
    }
}

#endregion

class Database
{
    public Connection Connection { get; set; }
    public Command Command { get; set; }
}