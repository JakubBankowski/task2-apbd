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

    public void Rent(User user, Equipment equipment, Singleton db)
    {
        if (user.GetEquipments().Count < 2)
        {
            user.AddEquipment(equipment);
            equipment.setUnAvailable();
            db.Rentals.Add(new Rental(user,  equipment, DateTime.Now, DateTime.Now.AddDays(7)));
            Console.WriteLine("You have successfully rented an item!");
        }
        else
        {
            Console.WriteLine("You cannot rent more items.");
        }
    }

    public void ReturnItem(User user, Equipment equipment, Singleton db)
    {
        user.RemoveEquipment(equipment);
        equipment.setAvailable();
        foreach (Rental r in db.Rentals.ToList())
        {
            if (r.user == user && r.equipment == equipment && r.returnDate == null)
            {
                r.returnDate = DateTime.Now;
                if (r.rentalEndDate < DateTime.Now)
                {
                    Console.WriteLine("You have to pay a 5$ fee");
                }
                break;
            }
        }
        
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

    public void AddEquipment()
    {
        Console.WriteLine("Enter description: ");
        string description = Console.ReadLine();
        Console.WriteLine();
        
        Console.WriteLine("Enter equipment type: ");
        Console.WriteLine("1) Laptop");
        Console.WriteLine("2) Speaker");
        Console.WriteLine("3) Whiteboard");
        
        string choice = Console.ReadLine();
        Console.WriteLine();

        if (choice == "1")
        {
            Console.WriteLine("Enter hard drive size: ");
            int hardDriveSize = int.Parse(Console.ReadLine());

            if (hardDriveSize == null)
            {
                Console.WriteLine("Wrong choice! Try again.");
                return;
            }
            
            Console.WriteLine("Enter hard operating system: ");
            string operatingSystem = Console.ReadLine();
            
            if (operatingSystem == null)
            {
                Console.WriteLine("Wrong choice! Try again.");
                return;
            }
            
            Laptop laptop = new Laptop(description, hardDriveSize, operatingSystem);
            Singleton.Instance.Equipments.Add(laptop);
            Console.WriteLine("Success!");
            Console.WriteLine();
            return;
        }
        
        if (choice == "2")
        {
            bool hasBlth = false;
            bool hasCD = false;
            Console.WriteLine("Does it have bluetooth? ");
            Console.WriteLine("1) Yes ");
            Console.WriteLine("2) No ");
            string b = Console.ReadLine();

            if (b == null)
            {
                Console.WriteLine("Wrong choice! Try again.");
                return;
            }
            
            if (b == "1")
            {
                hasBlth = true;
            }
            else if (b == "2")
            {
                hasBlth = false;
            }
            
            Console.WriteLine();
            
            Console.WriteLine("Does it have a CD driver? ");
            Console.WriteLine("1) Yes ");
            Console.WriteLine("2) No ");
            string c = Console.ReadLine();

            if (c == null)
            {
                Console.WriteLine("Wrong choice! Try again.");
                return;
            }
            
            if (c == "1")
            {
                hasCD = true;
            }
            else if (c == "2")
            {
                hasCD = false;
            }
            
            Console.WriteLine();
            
            Speaker speaker = new Speaker(description, hasBlth, hasCD);
            Singleton.Instance.Equipments.Add(speaker);
            Console.WriteLine("Success!");
            Console.WriteLine();
            return;
        }
        
        if (choice == "3")
        {
            Console.WriteLine("Enter resolution X: ");
            int resolutionX = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter resolution Y: ");
            int resolutionY = int.Parse(Console.ReadLine());

            if (resolutionX == null || resolutionY == null)
            {
                Console.WriteLine("Wrong choice! Try again.");
                return;
            }
            
            Console.WriteLine();
            
            InteractiveWhiteBoard whiteBoard = new InteractiveWhiteBoard(description, resolutionX, resolutionY);
            Singleton.Instance.Equipments.Add(whiteBoard);
            Console.WriteLine("Success!");
            Console.WriteLine();
            return;
        }
        
        Console.WriteLine("Wrong choice!");
    }
}