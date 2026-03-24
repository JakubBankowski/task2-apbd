namespace task2_apbd.Interfaces;

public interface IRentalService
{
    public User AddUser();

    public User LogIn(Singleton db);

    public void Rent(User user, Equipment equipment, Singleton db);
    
    public void ReturnItem(User user, Equipment equipment, Singleton db);

    public void DisplayStatus(Singleton db);

    public void DisplayUserRental(User user);
    
    public void AddEquipment();
}