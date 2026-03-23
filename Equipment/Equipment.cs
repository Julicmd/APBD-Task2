namespace APBD_TASK2.Equipment;

public abstract class Equipment
{
    private static int _nextId = 1; 
        
    public int Id { get; } = _nextId++;
    public string Name{ get; set; }

    public bool Available { get; private set; } = true;

    public Equipment(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public void EquipAvailable()
    {
        Available = true;
    }
    
    public void EuipUnavailable()
    {
        Available = false;
    }


}