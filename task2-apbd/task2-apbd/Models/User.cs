namespace task2_apbd;

public class User
{
    private int id{get;set;}
    private string username { get; set; } = null;
    private string password { get; set; } = null;
    private UserType userType { get; set; }
    
    private List<Equipment> equipments { get; set; } = new List<Equipment>();

    private static int ID = 1;
    
    public User(){}

    public User(string username, string password, UserType userType)
    {
        id = ID++;
        this.username = username;
        this.password = password;
        this.userType = userType;
        
        Singleton._instance.Users.Add(this);
    }
    
    public int GetId() {return id;}

    public string GetUsername()
    {
        return this.username;
    }
    
    public string GetUserType()
    {
        return userType.ToString();
    }

    public bool PassCheck(string password)
    {
        return this.password == password;

    }

    public void AddEquipment(Equipment equipment)
    {
        equipments.Add(equipment);
    }

    public void RemoveEquipment(Equipment equipment)
    {
        equipments.Remove(equipment);
    }
    
    public  List<Equipment> GetEquipments()
    {
        return equipments;
    }

    public override string ToString()
    {
        return $"{this.id} : {this.username}";
    }
}

public enum UserType
{
    Admin,
    User
}