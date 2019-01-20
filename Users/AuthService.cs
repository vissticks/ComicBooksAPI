using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ComicBooksAPI.DAL;
using ComicBooksAPI.Exceptions;
using ComicBooksAPI.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class AuthService : GenericService<User>
{
    private readonly ComicsContext _context;
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthService(
        ComicsContext context,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IConfiguration configuration
    ) : base(context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _configuration = configuration;
    }

    public async Task<IdentityResult> Register(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<User> Authenticate(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user != null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            
            if (result.Succeeded)
            {
                return await _userManager.FindByNameAsync(username);
            }

            if (result.IsLockedOut)
            {
                throw new AuthenticationFailedException("User is locked out");
            }
            else if (result.RequiresTwoFactor)
            {
                throw new AuthenticationFailedException("Two factor authentication is required");
            }
        }

        throw new AuthenticationFailedException("Wrong password and/or username");
    }

    public string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokeOptions = new JwtSecurityToken(
            issuer: "https://localhost:5001",
            audience: "https://localhost:5001",
            claims: new List<Claim>(),
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
    }
}