namespace APBD_TASK2.Equipment;

public class Laptop : Equipment
{
    public string OperatingSystem {get;  set;}
    
    
    public Laptop(int id, string name, string operatingSystem)
    : base(name)
    {
        OperatingSystem = operatingSystem;
    }
    
}