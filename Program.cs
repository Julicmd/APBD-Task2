

using APBD_TASK2.Database;
using APBD_TASK2.Models.Equipment;
using APBD_TASK2.Services;
using APBD_TASK2.Users;
using Monitor = APBD_TASK2.Models.Equipment.Monitor;

var db = Singleton.Instance;




var users = new List<User>();
var equipment = new List<Equipment>();

users.Add(new Student(1, "John", "Smith"));
users.Add(new Student(2, "Ryan", "Gosling"));
users.Add(new Employee(3, "Jones", "Danse"));
users.Add(new Employee(4, "Michael", "Jordan"));

equipment.Add(new Camera(1,"Sony", "ZV-E10", "16-50mm"));
equipment.Add(new Laptop(2,"Dell", "Windows"));
equipment.Add(new Laptop(3,"Samsung", "Windows"));
equipment.Add(new Monitor(4,"AOC", 24, "1920x1080"));
equipment.Add(new Camera(5,"Nikon", "D7500", "18-140mm"));
equipment.Add(new Monitor(6,"LG", 37, "2560x1440"));

var rentalService = new RentalService(equipment, users);

Console.WriteLine("=== ALL EQUIPMENT ===");
foreach (var item in equipment)
{
    Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Status: {item.Status}");
}

Console.WriteLine();
Console.WriteLine("=== CORRECT RENTAL ===");
try
{
    var rental1 = rentalService.RentEquipment(1, 1, DateTime.Now, 5);
    Console.WriteLine($"Rental created: {rental1.User.Name} rented {rental1.Equipment.Name} until {rental1.DueDate:D}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("=== INVALID RENTAL: SAME EQUIPMENT AGAIN ===");
try
{
    rentalService.RentEquipment(2, 1, DateTime.Now, 3);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("=== RETURN ON TIME ===");
try
{
    int penalty = rentalService.ReturnEquipment(1, DateTime.Now.AddDays(3));
    Console.WriteLine($"Equipment returned. Penalty: {penalty}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("=== LATE RETURN ===");
try
{
    var lateRental = rentalService.RentEquipment(3, 2, DateTime.Now.AddDays(-10), 3);
    int latePenalty = rentalService.ReturnEquipment(2, DateTime.Now);
    Console.WriteLine($"Late return penalty: {latePenalty}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("=== ACTIVE RENTALS FOR USER 1 ===");

var activeRentals = rentalService.GetActviteRentalsForUsers(1);
foreach (var rental in activeRentals)
{
    Console.WriteLine($"Rental ID: {rental.Id}, Equipment: {rental.Equipment.Name}, Due: {rental.DueDate:d}");
}

Console.WriteLine();
Console.WriteLine("=== OVERDUE RENTALS ===");
var overdueRentals = rentalService.GetOverDueRentals();
foreach (var rental in overdueRentals)
{
    Console.WriteLine($"Rental ID: {rental.Id}, Equipment: {rental.Equipment.Name}, User: {rental.User.Name}, Due: {rental.DueDate:d}");
}

Console.WriteLine();
Console.WriteLine("=== FINAL EQUIPMENT STATUS ===");
foreach (var item in equipment)
{
    Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Status: {item.Status}");
}

Console.WriteLine();
Console.WriteLine("=== ALL RENTALS ===");
foreach (var rental in rentalService.GetAllRentals())
{
    string returnInfo = rental.ReturnDate.HasValue ? rental.ReturnDate.Value.ToShortDateString() : "not returned";
    Console.WriteLine($"Rental ID: {rental.Id}, Equipment: {rental.Equipment.Name}, User: {rental.User.Name}, Due: {rental.DueDate:d}, Return: {returnInfo}, Penalty: {rental.PenaltyFee}");
}