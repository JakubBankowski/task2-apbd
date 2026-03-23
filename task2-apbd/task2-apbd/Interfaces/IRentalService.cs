namespace task2_apbd.Interfaces;

public interface IRentalService
{
    public User AddUser();

    public User LogIn(Singleton db);
}