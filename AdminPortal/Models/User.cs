using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models;

public class User
{
    [Key]
    public int UserId { get; protected set; }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string UserName { get; protected set; }
    public string UserEmail { get; protected set; }
    public string UserAddress { get; protected set; }

    public User(int userId, string firstName, string lastName, string userName, string userEmail, string userAdress)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        UserEmail = userEmail;
        UserAddress = userAdress;
    }

    public User(string firstName, string lastName, string userName, string userEmail, string userAdress)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        UserEmail = userEmail;
        UserAddress = userAdress;
    }

    public User(int userId)
    {
        UserId = userId;
        FirstName = "Unknown";
        LastName = "Unknown";
        UserName = "Unknown";
        UserEmail = "Unknown";
        UserAddress = "Unknown";
    }

    public User()
    {
        UserId = 0;
        FirstName = "Unknown";
        LastName = "Unknown";
        UserName = "Unknown";
        UserEmail = "Unknown";
        UserAddress = "Unknown";
    }

    // Prints the details of the user to the console.
    public virtual void DisplayDetails()
    {

        Console.WriteLine($"-\nUser ID: {UserId}\nFirst Name: {FirstName}\nLast Name: {LastName}\nUser Name: {UserName}\nUser Email: {UserEmail}\nUser Adress: {UserAddress}");
    }
}