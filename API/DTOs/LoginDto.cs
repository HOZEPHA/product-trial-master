namespace API;

/// <summary>
/// This class is used to store the login information of the user.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// This property stores the email address of the user.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// This property stores the password of the user.
    /// </summary>
    public required string Password { get; set; }
}
