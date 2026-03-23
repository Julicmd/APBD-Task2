namespace APBD_TASK2.Users;

public class Employee : User
{
    public override int MaxActiveRental => 5;

    public Employee(int id, string name, string surname)
    : base (id, name, surname)
    {
        
    }
    
    
}