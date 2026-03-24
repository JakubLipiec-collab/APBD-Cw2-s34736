using Zad_2.Models;

namespace Zad_2.Repositories;

public class MemoryRepository
{
    public List<User> Users { get; } = new List<User>();
    public List<Equipment> Equipment { get; } = new List<Equipment>();
    public List<Loan> Loans { get; } = new List<Loan>();

    public void AddUser(User user) => Users.Add(user);
    public void AddEquipment(Equipment equipment) => Equipment.Add(equipment);
    public void AddLoan(Loan loan) => Loans.Add(loan);

    public List<Equipment> GetAvaiableEquipment() => Equipment.Where(e => e.isAvaiable).ToList();
    public List<Loan> GetActiveLoans(User user) => Loans.Where(l => l.Borrower.Id == user.Id && l.IsActive).ToList();
}