using APBD_TASK2.Enum;

namespace APBD_TASK2.Models.Equipment;

public abstract class Equipment
{
    private static int _nextId = 1; 
        
    public int Id { get; } 
    public string Name{ get; set; }
    
    public EquipmentStatus Status{ get; private set; } = EquipmentStatus.Available;

    public Equipment(string name)
    {
        Id = _nextId++;
        Name = name;
    }
    
    public void SetAvailable()
    {
        Status = EquipmentStatus.Available;
    }

    public void SetUnavailable()
    {
        Status = EquipmentStatus.Unavailable;
    }
    


}