using System.Runtime.InteropServices.JavaScript;

namespace task2_apbd;

public abstract class Equipment
{
    private int id{get;set;}
    public string desc{get;set;}
    
    private static int ID = 1;

    private bool available = true;

    public Equipment(string desc)
    {
        id = ID++;
        this.desc = desc;
    }
    
    public bool isAvailable()
    {
        return this.available;
    }

    public int getID()
    {
        return id;
    }
    
    public void setAvailable()
    {
        this.available = true;
    }
    
    public void setUnAvailable()
    {
        this.available = false;
    }

    public override string ToString()
    {
        return "id: " + id + ", desc: " + desc + ", available: " + available;
    }
}