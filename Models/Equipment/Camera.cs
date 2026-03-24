namespace APBD_TASK2.Models.Equipment;

public class Camera : Equipment
{
    public string Model{get; set;}
    public string LensType{get; set;}

    public Camera(int id, string name, string model, string lensType)
    : base(name)
    {
        Model = model;
        LensType = lensType;
    }
    
}