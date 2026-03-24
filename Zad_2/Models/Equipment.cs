namespace Zad_2.Models;

public abstract class Equipment
{
    public Guid Id { get; private set; } =  Guid.NewGuid();
    public string Name { get; private set; }
    public bool isAvaiable { get; private set; } = true;
    
    protected Equipment(string name){
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Equipment name can not be empty");
        Name = name;
    }

    public void SetAvaiable(bool avaiable)
    {
        isAvaiable = avaiable;
    }

    public override string ToString()
    {
        return Id+" "+Name+" "+isAvaiable;
    }
}