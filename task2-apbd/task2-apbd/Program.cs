namespace  task2_apbd;

public class Program
{
    public static void Main(string[] args)
    {
        Singleton db = Singleton.Instance;
        
        User user = new User();
        Console.WriteLine("Log in or Register:");
        Console.WriteLine("-Log in (Enter 1)");
        Console.WriteLine("-Register (Enter 2)");
        
        string choice = Console.ReadLine();
        while (choice != "1" && choice != "2")
        {
            Console.WriteLine("Wrong choice! Try again.");
            choice = Console.ReadLine();
        }

        if (choice == "1")
        {
            Console.WriteLine("Enter username: "); 
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            
            foreach (User u in db.Users)
            {
                if (u.GetUsername() == username)
                {
                    if (u.PassCheck(password))
                    {
                        user = u;
                    }
                }
            }

            if (user == null)
            {
                Console.WriteLine("User not found.");
            }
        }
    }

    static User AddUser()
    {
        Console.WriteLine("Enter username: ");
        string username = Console.ReadLine();
        Console.Clear();
        
        Console.WriteLine("Enter password: ");
        string password = Console.ReadLine();
        Console.Clear();
        
        Console.WriteLine("Choose account type: ");
        Console.WriteLine("-Regular (Enter 1)");
        Console.WriteLine("-Administrator(Enter 2)");

        string choice = Console.ReadLine();
        while (choice != "1" && choice != "2")
        {
            Console.WriteLine("Wrong choice! Try again.");
            choice = Console.ReadLine();
        }

        if (choice == "1")
        {
            return new User(username,password,UserType.User);
        }
        
        return new User(username,password,UserType.Admin);
    } 
}