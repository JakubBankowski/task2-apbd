namespace task2_apbd;

public class InteractiveWhiteBoard : Equipment
{
    int resolutionX;
    int resolutionY;
    
    public InteractiveWhiteBoard(string desc, int resolutionX, int resolutionY) : base(desc)
    {
        this.resolutionX = resolutionX;
        this.resolutionY = resolutionY;
    }
}