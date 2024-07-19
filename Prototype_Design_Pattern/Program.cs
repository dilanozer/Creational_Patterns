Person person1 = new("Dilan", "Ozer", Department.C, 100, 10);
// Person person2 = new("Ahmet", "Ozer", Department.C, 100, 10);

Person person2 = person1.Clone();
person2.Name = "Ahmet";

Console.WriteLine();

#region Abstract Prototype

interface IPersonCloneable
{
    Person Clone();
}

#endregion

#region Concrete Prototype

class Person : IPersonCloneable
{
    public Person(string name, string surname, Department department, int salary, int premium)
    {
        Name = name;
        Surname = surname;
        Department = department;
        Salary = salary;
        Premium = premium;

        Console.WriteLine("Person nesnesi olusturuldu");
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }

    public Person Clone()
    {
        return (Person)base.MemberwiseClone();
    }
}

enum Department
{
    A, B, C
}

#endregion



