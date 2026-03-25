namespace APBD_TASK2.Users;

public abstract class User
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public abstract int MaxActiveRental{get;}

    public User(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }
    
}