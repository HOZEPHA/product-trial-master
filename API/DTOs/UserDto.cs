namespace API;

/// <summary>
/// This class represents a data transfer object for a user.
/// </summary>
public class UserDto
{
    /// <summary>
    /// This property stores the email address of the user.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// This property stores the token of the user.
    /// </summary>
    public required string Token { get; set; }
}
