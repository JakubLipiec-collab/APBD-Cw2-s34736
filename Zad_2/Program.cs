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
                
                Console.WriteLine("Proba wypozyczenia " +camera.Name+" przez "+employee.Name);
                rentalService.RentEquipment(employee, camera,-10);
                Console.WriteLine("Sukces\n");

                Console.WriteLine("Proba wypozyczenia " +laptop.Name+" przez "+employee.Name);
                rentalService.RentEquipment(employee, laptop,3);
            }
            catch (EquipmentUnavaiableException e)
            {
                Console.WriteLine("Blad: "+e);
            }

            Console.WriteLine("\nProba zwrotu w dobrym terminie");
            var returnGoodLoan = repo.Loans.FirstOrDefault(e =>
                e.Borrower.Id == student.Id &&
                e.Item.Id == laptop.Id &&
                e.IsActive
            );
            if (returnGoodLoan != null)
            {
                decimal kara = rentalService.ReturnEquipment(returnGoodLoan);
                Console.WriteLine("Sukces, brak kary");
                if(kara!=0) Console.WriteLine("Kara: "+kara);
            }
            Console.WriteLine("\nProba zwrotu po terminie");
            var returnBadLoan = repo.Loans.FirstOrDefault(e =>
                e.Borrower.Id == employee.Id &&
                e.Item.Id == camera.Id &&
                e.IsActive
            );
            if (returnBadLoan != null)
            {
                decimal kara = rentalService.ReturnEquipment(returnBadLoan);
                Console.WriteLine("Sukces, ale z kara");
                if(kara!=0) Console.WriteLine("Kara: "+kara);
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