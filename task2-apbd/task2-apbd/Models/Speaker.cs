namespace task2_apbd;

public class Speaker : Equipment
{
    private bool hasBluetooth;
    private bool hasCDDrive;
    
    public Speaker(string desc, bool hasBluetooth, bool hasCdDrive) : base(desc)
    {
        this.hasBluetooth = hasBluetooth;
        this.hasCDDrive = hasCdDrive;
    }
}