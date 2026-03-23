using task2_apbd.Interfaces;

namespace task2_apbd;

public class RentalService : IRentalService
{
    public User AddUser()
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

    public User LogIn(Singleton db)
    {
        User user = null;
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
                    Console.WriteLine("Successfully logged in!");
                }
            }
        }

        if (user == null)
        {
            Console.WriteLine("User not found.");
        }
        return user;
    }

    public void Rent(User user, Equipment equipment, DateTime startDate, DateTime endDate, Singleton db)
    {
        user.AddEquipment(equipment);
        db.Rentals.Add(new Rental(user,  equipment, startDate, endDate));
    }

    public void DisplayStatus(Singleton db)
    {
        foreach (Equipment e in db.Equipments)
        {
            Console.WriteLine(e.ToString());
        }
    }
    
    public void DisplayUserRental(User user)
    {
        foreach (Equipment e in user.GetEquipments())
        {
            Console.WriteLine(e.ToString());
        }
    }
}