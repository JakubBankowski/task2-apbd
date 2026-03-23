namespace  task2_apbd;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Singleton db = Singleton.Instance;
            RentalService rentalService = new RentalService();

            User user = new User();
            Console.WriteLine("Log in or Register:");
            Console.WriteLine("1) Log in");
            Console.WriteLine("2) Register");

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

            if (user == null)
            {
                Console.WriteLine("User Not Found");
                return;
            }

            if (user.GetUserType() == "Admin")
            {
                Console.WriteLine("Welcome " + user.GetUsername() + "!");
                Console.WriteLine("Choose what you want to do: ");
                Console.WriteLine("1) Display equipment status");
                Console.WriteLine("2) Display user data");
                Console.WriteLine("3) Display overdue rentals");
                Console.WriteLine("4) Display a summary");
                Console.WriteLine("5) Add new equipment");
                string choice_2 = Console.ReadLine();
                while (choice_2 != "1" && choice_2 != "2" && choice_2 != "3" && choice_2 != "4" && choice_2 != "5")
                {
                    Console.WriteLine("Wrong choice! Try again.");
                    choice_2 = Console.ReadLine();
                }

                if (choice_2 == "1")
                {
                    rentalService.DisplayStatus(db);
                    continue;
                }

                if (choice_2 == "2")
                {
                    Console.WriteLine("Type username: ");
                    string username =  Console.ReadLine();
                    
                    
                }
            }
            
            if (user.GetUserType() == "Admin")
            {
                Console.WriteLine("Welcome " + user.GetUsername() + "!");
                Console.WriteLine("Choose what you want to do: ");
                Console.WriteLine("1) Display equipment status");
                Console.WriteLine("2) Display user data");
                Console.WriteLine("3) Display overdue rentals");
                Console.WriteLine("4) Display a summary");
                Console.WriteLine("5) Add new equipment");
                string choice_2 = Console.ReadLine();
                while (choice_2 != "1" && choice_2 != "2" && choice_2 != "3" && choice_2 != "4" && choice_2 != "5")
                {
                    Console.WriteLine("Wrong choice! Try again.");
                    choice_2 = Console.ReadLine();
                }

                if (choice_2 == "1")
                {
                    rentalService.DisplayStatus(db);
                    continue;
                }

                if (choice_2 == "2")
                {
                    Console.WriteLine("Type username: ");
                    string username =  Console.ReadLine();
                    
                    
                }
            }
        }
    }
}