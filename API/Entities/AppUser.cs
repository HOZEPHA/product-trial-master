namespace API.Entities;

/// <summary>
/// This class is used to store the user information in the database.
/// </summary>
public class AppUser
{
    /// <summary>
    /// This is the auto-incremented primary key of the user.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// this property is used to store the username of the user.
    /// </summary>
    public required string UserName { get; set; }

    /// <summary>
    /// this property is used to store the first name of the user.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// this property is used to store the email of the user.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// this property is used to store the password hash of the user.
    /// </summary>
    public required byte[] PasswordHash { get; set; }

    /// <summary>
    /// this property is used to store the password salt of the user.
    /// </summary>
    public required byte[] PasswordSalt { get; set; }

}

