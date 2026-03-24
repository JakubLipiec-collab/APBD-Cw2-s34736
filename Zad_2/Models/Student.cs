namespace Zad_2.Models;

public class Student : User
{
    public override int MaxActiveLoans => 2;
    public string IndexNumber { get; private set; }

    public Student(string name, string lastName, string indexNumber) : base(name, lastName)
    {
        IndexNumber = indexNumber;
    }
}