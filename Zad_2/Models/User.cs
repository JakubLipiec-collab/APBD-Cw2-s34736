namespace Zad_2.Models;

public abstract class User
{
   public Guid Id { get; private set; } =  Guid.NewGuid();
   public string Name { get; private set; }
   public string LastName { get; private set; }
    
   public abstract int MaxActiveLoans { get; }

   protected User(String name, string lastName)
   {
      if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(lastName))
         throw new ArgumentException("Name and last name cannot be empty");
      Name = name;
      LastName = lastName;
   }

   public override string ToString()
   {
      return "Id: " + Id + ", Name: " + Name + ", LastName: " + LastName;
   }
}