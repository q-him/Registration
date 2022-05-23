using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Registration.Pages;

public class RegisterModel : PageModel
{
    private ILogger<RegisterModel> _logger;
    private CasinoDbContext _db;

    public bool IsRegistrationComplete { get; private set; }
    public bool IsEmailOccupied { get; private set; }
    public bool IsNicknameOccupied { get; private set; }
    public bool IsPhoneOccupied { get; private set; }

    public RegisterModel(ILogger<RegisterModel> logger, CasinoDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public void OnGet()
    {
    }


    public async Task OnPost(User user)
    {
        _logger.LogInformation(
            $"POST /Register {user.Email} {user.Nickname} {user.FirstName} {user.LastName} {user.Phone} {user.Born}");

        IsEmailOccupied = await _db.IsEmailOccupiedAsync(user.Email);
        IsNicknameOccupied = await _db.IsNicknameOccupiedAsync(user.Nickname);
        IsPhoneOccupied = await _db.IsPhoneOccupiedAsync(user.Phone);

        IsRegistrationComplete = !(IsNicknameOccupied || IsEmailOccupied || IsPhoneOccupied);

        if (IsRegistrationComplete)
        {
            await _db.AddUserAsync(user);            
        }
    }
}