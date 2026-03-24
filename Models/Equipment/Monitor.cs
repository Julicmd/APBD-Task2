namespace APBD_TASK2.Models.Equipment;

public class Monitor : Equipment
{
    public int ScreenSize{get; set;}
    public string Resolution{get; set;}


    public Monitor(string name, int screenSize, string resolution)
        : base(name)
    {
        ScreenSize = screenSize;
        Resolution = resolution;
    }
    
    
}