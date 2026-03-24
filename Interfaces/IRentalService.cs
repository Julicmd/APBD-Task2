using APBD_TASK2.Rentals;

namespace APBD_TASK2.Interfaces;

public interface IRentalService
{
    Rental RentEquipment(int userId, int equipmentId,DateTime rentDate,int numberOfDays);
    int ReturnEquipment(int equipmentId,DateTime returnDate);
    List<Rental> GetActviteRentalsForUsers (int userId);
    List<Rental> GetOverDueRentals();
    List<Rental> GetAllRentals();

}    