using Zad_2.Exceptions;
using Zad_2.Models;
using Zad_2.Repositories;
using Zad_2.Services;

namespace  Zad_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo =  new MemoryRepository();
            var rentalService = new RentalService(repo);

            var student = new Student("Jan", "Kowalsk", "s20294");
            var employee = new Employee("Anna", "Nowakowska", "Katedra informatyki");
            repo.AddUser(student);
            repo.AddUser(employee);

            var laptop = new Laptop("Dell EXATRON", 128, "i10");
            var camera = new Camera("Canon XGSM4", true, "8K");
            repo.AddEquipment(camera);
            repo.AddEquipment(laptop);
            
            Console.WriteLine("Wypozyczalnia:");
            try
            {
                Console.WriteLine("Proba wypozyczenia "+laptop.Name+" przez "+student.Name);
                rentalService.RentEquipment(student, laptop,31);
                Console.WriteLine("Sukces\n");

                Console.WriteLine("Proba wypozyczenia " +laptop.Name+" przez "+employee.Name);
                rentalService.RentEquipment(employee, laptop,3);
            }
            catch (EquipmentUnavaiableException e)
            {
                Console.WriteLine("Blad: "+e);
            }

            Console.WriteLine("\nIlosc aktywnych wypozyczen: "+repo.Loans.Count(loan => loan.IsActive));
            Console.WriteLine("Dostepny sprzet");
            foreach (var item in repo.GetAvaiableEquipment())
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}