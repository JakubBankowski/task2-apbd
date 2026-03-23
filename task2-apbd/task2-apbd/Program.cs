namespace  task2_apbd;

public class Program
{
    public static void Main(string[] args)
    {
        Singleton db = Singleton.Instance;
        RentalService rentalService = new RentalService();
        
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
            user = rentalService.LogIn(db);
        }
        
        else if (choice == "2")
        {
            user = rentalService.AddUser();
        }
    }
}