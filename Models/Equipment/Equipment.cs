using APBD_TASK2.Enum;

namespace APBD_TASK2.Models.Equipment;

public abstract class Equipment
{
    
    public int Id { get; } 
    public string Name{ get; set; }
    
    public EquipmentStatus Status{ get; private set; } = EquipmentStatus.Available;

    public Equipment(int id, string name)
    {
        Id = id;
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