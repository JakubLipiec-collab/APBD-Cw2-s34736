using Zad_2.Models;
using Zad_2.Exceptions;
using Zad_2.Repositories;

namespace Zad_2.Services;
    public class RentalService : IRentalService
    {
        private readonly MemoryRepository _repository;
        private const decimal DailyPenalty = 10.0m;

        public RentalService(MemoryRepository repository)
        {
            _repository = repository;
        }

        public Loan RentEquipment(User user, Equipment item, int days)
        {
            if (!item.isAvaiable)
            {
                throw new EquipmentUnavaiableException("Sprzet jest aktualnie niedostepny");
            }
            var activeLoans = _repository.GetActiveLoans(user);
            if (activeLoans.Count >= user.MaxActiveLoans)
            {
                throw new LimitExceededException("Uzytkownik osiagnal limit wypozyczen");
            }
            var loan = new Loan(user, item, days);
            item.SetAvaiable(false);
            _repository.AddLoan(loan);
            return loan;
        }

        public decimal ReturnEquipment(Loan loan)
        {
            if (!loan.IsActive)
            {
                throw new InvalidOperationException("To wypozyczenie zostalo juz zakonczone");
            }

            decimal penalty = 0;
            if (DateTime.Now > loan.DueTime)
            {
                int dayslate = (DateTime.Now - loan.DueTime).Days;
                penalty = dayslate*DailyPenalty;
            }
            loan.CompleteLoan(penalty);
            loan.Item.SetAvaiable(true);
            
            return penalty;
        }
    }