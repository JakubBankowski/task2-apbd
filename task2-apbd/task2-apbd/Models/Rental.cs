using System.Transactions;

namespace task2_apbd;

public class Rental
{
    public int id{get;set;}
    
    public User user{get;set;}
    public Equipment equipment{get;set;}
    
    public DateTime rentalDate{get;set;}
    public DateTime rentalEndDate{get;set;}
    
    public DateTime? returnDate{get;set;}

    public static int ID = 1;

    public Rental(User user, Equipment equipment,  DateTime rentalDate, DateTime rentalEndDate)
    {
        id = ID++;
        this.user = user;
        this.equipment = equipment;
        this.rentalDate = rentalDate;
        this.rentalEndDate = rentalEndDate;
    }

    public override string ToString()
    {
        return $"User id: {user.GetId()}, Equipment: {equipment.desc},  Rental Date: {rentalDate}, Rental EndDate: {rentalEndDate}";
    }
}