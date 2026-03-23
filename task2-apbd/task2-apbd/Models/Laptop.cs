namespace task2_apbd;

public class Laptop : Equipment
{
    private int hardDriveSize;
    public string operatingSystem;

    public Laptop(string desc, int hardDriveSize, string operatingSystem) : base(desc)
    {
        this.hardDriveSize = hardDriveSize;
        this.operatingSystem = operatingSystem;
    }
}