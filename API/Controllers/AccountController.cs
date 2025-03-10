using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")] //account/register
    public async Task<ActionResult<UserDto>> Resister(RegisterDto registerDto)
    {
        if (await isUserExists(registerDto.Email))
            return BadRequest("The User already exists");

        using var hmac = new HMACSHA3_512();

        var user = new AppUser
        {
            Email = registerDto.Email,
            UserName = registerDto.Username.ToLower(),
            FirstName = registerDto.Firstname,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        context.Users.Add(user);

        await context.SaveChangesAsync();

        return new UserDto
        {
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")] //account/login
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u =>
                          u.Email.ToLower() == loginDto.Email.ToLower());

        if (user == null) return Unauthorized("Invalid email");

        using var hmac = new HMACSHA3_512(user.PasswordSalt);

        var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < ComputeHash.Length; i++)
        {
            if (ComputeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
        }

        return new UserDto
        {
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        };
    }


    private async Task<bool> isUserExists(string Email)
    {
        return await context.Users.AnyAsync(u => u.Email.ToLower() == Email.ToLower());
    }
}

