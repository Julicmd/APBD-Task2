namespace APBD_TASK2.Rentals;
using APBD_TASK2.Equipment;
using APBD_TASK2.Users;

public class Rental
{
    private static int _nextId = 1;

    public int Id { get; }
    public Equipment Equipment { get; }
    public User User { get; }
    public DateTime RentalDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public int PenaltyFee { get; private set; }

    public bool IsActive => ReturnDate == null;
    
    public Rental( Equipment equipment, User user,DateTime rentaldate,DateTime dueDate)
    {
        Id = _nextId++;
        Equipment = equipment;
        User = user;
        RentalDate = rentaldate;
        DueDate = dueDate;
        ReturnDate = null;
        PenaltyFee = 0;
    }

    public void CompleteReturn(DateTime returndate, int penaltyFee)
    {
        ReturnDate = returndate;
        PenaltyFee = penaltyFee;
    }
        
    
}