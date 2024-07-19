// 2.YONTEM -> Abstract Prototype olusturmana gerek yok, bu gorevi IClonable ustlendi

Person person1 = new("Fatma", "Ozer", Department.A, 2500, 500);

Person person2 = (Person)person1.Clone();
person2.Name = "Ayse";
person2.Salary = 1000;

Console.WriteLine();

#region Concrete Prototype

class Person : ICloneable
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

    public object Clone()
    {
        // direkt object turunde donebilirsin
        return base.MemberwiseClone();
    }
}

enum Department
{
    A, B, C
}

#endregion





