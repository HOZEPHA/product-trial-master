namespace API;

/// <summary>
/// This class represents a data transfer object for registering a user.
/// </summary>
public class RegisterDto
{
   /// <summary>
   /// This property stores the email address of the user.
   /// </summary>
   public required string Username { get; set; }

   /// <summary>
   /// This property stores the Firstname address of the user.
   /// </summary>
   public required string Firstname { get; set; }

   /// <summary>
   /// This property stores the email address of the user.
   /// </summary>
   public required string Email { get; set; }

   /// <summary>
   /// This property stores the password of the user.
   /// </summary>
   public required string Password { get; set; }
}
