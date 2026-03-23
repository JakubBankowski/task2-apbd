using System.Runtime.InteropServices.JavaScript;

namespace task2_apbd;

public abstract class Equipment
{
    private int id{get;set;}
    public string desc{get;set;}
    
    private static int ID = 1;

    private bool available = true;

    private DateTime rentalDate;
    private DateTime rentalEndDate;

    private DateTime rentalReturnDate;

    public Equipment(string desc)
    {
        id = ID++;
        this.desc = desc;
    }
    
    public bool isAvailable()
    {
        return this.available;
    }
    
    public void setAvailable()
    {
        this.available = true;
    }
    
    public void setUnAvailable()
    {
        this.available = false;
    }
}