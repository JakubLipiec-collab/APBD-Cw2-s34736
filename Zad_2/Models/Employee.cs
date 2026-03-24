namespace Zad_2.Models;

public class Employee : User
{
    public override int MaxActiveLoans => 5;
    public string Department { get; private set; }

    public Employee(string name, string lastName, string department) : base(name, lastName)
    {
        Department = department;
    }
}