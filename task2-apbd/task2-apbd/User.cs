namespace task2_apbd;

public class User
{
    private int id;
    private string username;
    private string password;
    private UserType userType;

    private static int ID = 0;

    public User(string username, string password, UserType userType)
    {
        id = ID;
        ID++;
        this.username = username;
        this.password = password;
        this.userType = userType;
    }
}

public enum UserType
{
    Admin,
    User
}