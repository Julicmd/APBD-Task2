namespace APBD_TASK2.Users;

public abstract class User
{
    private static int _createid = 1; 
    
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public abstract int MaxActiveRental{get;}

    public User(int id, string name, string surname)
    {
        Id = _createid++;
        Name = name;
        Surname = surname;
    }
    
}