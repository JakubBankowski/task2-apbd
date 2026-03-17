namespace task2_apbd;

public class Singleton
{
    public static Singleton? _instance;

    public static Singleton Instance
    {
        get
        {
            _instance ??= new Singleton();
            return _instance;
        }
    }
    
    private Singleton(){}

    public List<User> Users { get; set; } = new List<User>();
}