using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models.Equipment;
using APBD_TASK2.Rentals;
using APBD_TASK2.Users;

namespace APBD_TASK2.Services;

public class RentalService : IRentalService
{
    
    private List<Rental> _rentals = new();
    private List<Equipment> _equipments;
    private List<User> _users;

    public RentalService(List<Equipment> equipments, List<User> users)
    {
        _equipments = equipments;
        _users = users;
    }

    public Rental RentEquipment(int userId, int equipmentId, DateTime rentDate, int numberOfDays)
    {
        User? user = _users.FirstOrDefault(u=> u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found ");
        }

        Equipment? equipment = _equipments.FirstOrDefault(e => e.Id == equipmentId);
        if (equipment == null)
        {
            throw new InvalidOperationException("Equipment not found ");
        }

        if (!IsEquipmentAvailable(equipment))
        {
            throw new InvalidOperationException("Equipment is not available for renting");
        }
        
        int rentalsCount = _rentals.Count(r => r.User.Id == userId && r.IsActive);
        if (rentalsCount >= user.MaxActiveRental)
        {
            throw new InvalidOperationException("User has reached maximum rentals");
        }
        DateTime dueDate = rentDate.AddDays(numberOfDays);
        Rental rental = new Rental(equipment, user, rentDate, dueDate);
        
        equipment.SetUnavailable();
        _rentals.Add(rental);
        
        
        return rental;
    }


    public int ReturnEquipment(int equipmentId, DateTime returnDate)
    {
        Rental? activeRental = _rentals.FirstOrDefault(r => r.Equipment.Id == equipmentId && r.IsActive);
        if (activeRental == null)
        {
            throw new InvalidOperationException("Active rental for this equipment was not found: " + equipmentId);
        }
        int penalty = CalculatePenalty(activeRental.DueDate, returnDate);
        activeRental.CompleteReturn(returnDate, penalty);
        activeRental.Equipment.SetAvailable();
        
        
        return penalty;
    }


    public List<Rental> GetActviteRentalsForUsers(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId && r.IsActive).ToList();
    }

    public List<Rental> GetAllRentals()
    {
        return _rentals;
    }

    public List<Rental> GetOverDueRentals()
    {
        return _rentals.Where(r => r.IsActive && r.DueDate < DateTime.Now)
            .ToList();
    }
    
    
    
    private bool IsEquipmentAvailable(Equipment equipment)
    {
        return equipment.Status == EquipmentStatus.Available;
    }

    private int CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate.Date <= dueDate.Date)
        {
            return 0;
        }

        int lateReturn = (returnDate.Date - dueDate.Date).Days;
        return lateReturn * 10;
    }
}