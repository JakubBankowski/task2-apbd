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
            
            Console.WriteLine("");
            
            if (choice == "1")
            {
                user = rentalService.LogIn(db);
            }

            else if (choice == "2")
            {
                user = rentalService.AddUser();
            }
            
            Console.WriteLine("");

            if (user == null)
            {
                Console.WriteLine("User Not Found");
                return;
            }
            
            if (user.GetUserType() == "Admin")
            {
                while (true)
                {
                    Console.WriteLine("Welcome " + user.GetUsername() + "!");
                    Console.WriteLine("Choose what you want to do: ");
                    Console.WriteLine("1) Display equipment status");
                    Console.WriteLine("2) Display user data");
                    Console.WriteLine("3) Display overdue rentals");
                    Console.WriteLine("4) Display a summary");
                    Console.WriteLine("5) Add new equipment");
                    Console.WriteLine("6) Log out");
                    string choice_2 = Console.ReadLine();

                    if (choice_2 == "1")
                    {
                        rentalService.DisplayStatus(db);
                        Console.WriteLine();
                        continue;
                    }

                    if (choice_2 == "2")
                    {
                        User selectedUser = null;
                        Console.WriteLine("Choose a user by ID: ");
                        foreach (User u in db.Users)
                        {
                            Console.WriteLine(u);
                        }
                        Console.WriteLine();
                        string userID =  Console.ReadLine();

                        foreach (User u in db.Users)
                        {
                            if (u.GetId() == Int32.Parse(userID))
                            {
                                selectedUser = u;
                            }
                        }

                        if (selectedUser == null)
                        {
                            Console.WriteLine("No user found");
                            continue;
                        }

                        Console.WriteLine($"All active {selectedUser.GetUsername()}s rentals: ");
                        foreach (Equipment e in selectedUser.GetEquipments())
                        {
                            Console.WriteLine(e);
                        }
                        
                        Console.WriteLine();
                        continue;
                    }

                    if (choice_2 == "3")
                    {
                        Console.WriteLine("Here are all overdue rentals: ");
                        foreach (Rental r in db.Rentals)
                        {
                            if (r.returnDate == null && r.rentalEndDate < DateTime.Now)
                            {
                                Console.WriteLine(r);
                            }
                        }
                        Console.WriteLine();
                        continue;
                    }

                    if (choice_2 == "4")
                    {
                        Console.WriteLine("Here are all rentals: ");
                        foreach (Rental r in db.Rentals)
                        {
                            Console.WriteLine(r);
                        }
                        Console.WriteLine();
                        continue;
                    }

                    if (choice_2 == "5")
                    {
                        rentalService.AddEquipment();
                        continue;
                    }

                    if (choice_2 == "6")
                    {
                        Console.WriteLine("Logging out");
                        Console.WriteLine();
                        break;
                    }
                    Console.WriteLine("Wrong choice! Try again.");
                    Console.ReadLine();
                }
            }

            if (user.GetUserType() == "User")
            {
                while (true)
                {
                    Console.WriteLine("Welcome " + user.GetUsername() + "!");
                    Console.WriteLine("Choose what you want to do: ");
                    Console.WriteLine("1) Rent an item");
                    Console.WriteLine("2) Return an item");
                    Console.WriteLine("3) Log out");
                    string choice_2 = Console.ReadLine();
                    
                    if (choice_2 == "1")
                    {
                        Equipment eq = null;
                        Console.WriteLine("Choose an item by id: ");
                        foreach (Equipment e in db.Equipments)
                        {
                            if (e.isAvailable())
                            {
                                Console.WriteLine(e);
                            }
                        }
                        int chosenID =  int.Parse(Console.ReadLine());
                        
                        if (chosenID == null)
                        {
                            Console.WriteLine("No item found");
                            Console.WriteLine();
                            continue;
                        }

                        foreach (Equipment e in db.Equipments)
                        {
                            if (e.getID() == chosenID)
                            {
                                if (e.isAvailable())
                                {
                                    eq = e;
                                    rentalService.Rent(user, eq, db);
                                    break;
                                }
                            }
                        }

                        if (eq == null)
                        {
                            Console.WriteLine("Item unavailable");
                        }

                        continue;
                    }

                    if (choice_2 == "2")
                    {
                        Equipment eq = null;
                        Console.WriteLine("Choose an item by id: ");
                        foreach (Equipment e in user.GetEquipments())
                        {
                            Console.WriteLine(e);
                        }
                        int chosenID =  int.Parse(Console.ReadLine());
                        
                        if (chosenID == null)
                        {
                            Console.WriteLine("No item found");
                            Console.WriteLine();
                            continue;
                        }

                        foreach (Equipment e in user.GetEquipments())
                        {
                            if (e.getID() == chosenID)
                            {
                                eq = e;
                                rentalService.ReturnItem(user, eq, db);
                            }
                        }

                        if (eq == null)
                        {
                            Console.WriteLine("Item unavailable");
                        }

                        continue;
                    }
                    
                    if (choice_2 == "3")
                    {
                        Console.WriteLine("Logging out");
                        Console.WriteLine();
                        break;
                    }
                    
                    Console.WriteLine("Wrong choice! Try again.");
                    Console.ReadLine();
                }
            }
        }
    }
}