using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models;

public class Admin
{
    [Key]
    public int AdminId { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set;} = null!; // navigational property.

    public Admin(
        int adminId,
        int userId
    )
    {
        AdminId = adminId;
        UserId = userId;

    }
}        