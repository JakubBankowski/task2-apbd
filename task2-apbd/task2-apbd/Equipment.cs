namespace task2_apbd;

public class Equipment
{
    private int id;
    public string desc;
    private EquipmentType equipmentType;
    private static int ID = 0;

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