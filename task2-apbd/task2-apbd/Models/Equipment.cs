namespace task2_apbd;

public class Equipment
{
    private int id{get;set;}
    public string desc{get;set;}
    private EquipmentType equipmentType{get;set;}
    private static int ID = 1;

    public Equipment(string desc, EquipmentType equipmentType)
    {
        id = ID++;
        this.desc = desc;
        this.equipmentType = equipmentType;
    }
}

public enum EquipmentType
{
    Laptop,
    Mouse,
    Keyboard,
    Projector,
    Camera
}