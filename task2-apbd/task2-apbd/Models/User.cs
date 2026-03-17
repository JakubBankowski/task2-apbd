namespace task2_apbd;

public class User
{
    private int id{get;set;}
    private string username { get; set; } = null;
    private string password { get; set; } = null;
    private UserType userType { get; set; }

    private static int ID = 1;
    
    public User(){}

    public User(string username, string password, UserType userType)
    {
        id = ID++;
        this.username = username;
        this.password = password;
        this.userType = userType;
    }

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
}

public enum UserType
{
    Admin,
    User
}