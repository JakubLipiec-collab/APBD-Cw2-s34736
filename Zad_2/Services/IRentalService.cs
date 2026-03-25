using Zad_2.Models;

namespace Zad_2.Services;

public interface IRentalService
{
    Loan RentEquipment(User user, Equipment item, int days);
    decimal ReturnEquipment(Loan loan);
}