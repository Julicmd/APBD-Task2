namespace APBD_TASK2.Users;

public class Student : User
{
    public override int MaxActiveRental => 2;

    public Student(int id, string name, string surname) 
        : base(id, name, surname)
    {
        
        
    }
}