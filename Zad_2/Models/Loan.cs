namespace Zad_2.Models;

public class Loan
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public User Borrower { get; private set; }
    public Equipment Item { get; private set; }
    public DateTime RentDate { get; private set; }
    public DateTime DueTime  { get; private set; }
    public DateTime ReturnDate { get; private set; }
    public decimal PenaltyAmount { get; private set; }

    public bool IsActive => ReturnDate < DateTime.Now;
    public bool IsOverdue => IsActive && DateTime.Now > DueTime;
    
    public Loan(User borrower, Equipment item, int rentDays){
        Borrower = borrower;
        Item = item;
        RentDate = DateTime.Now;
        DueTime = RentDate.AddDays(rentDays);
    }
    
    public void CompleteLoan(decimal penaltyAmount){
        PenaltyAmount = penaltyAmount;
        ReturnDate = DateTime.Now;
    }
}