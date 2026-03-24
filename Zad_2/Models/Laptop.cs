namespace Zad_2.Models;

public class Laptop : Equipment
{
    public int RamGB { get; private set; }
    public string Proccesor { get; private set; }
    public Laptop(string name, int ramGb, string proccesor) : base(name)
    {
        RamGB = ramGb;
        Proccesor = proccesor;
    }
}