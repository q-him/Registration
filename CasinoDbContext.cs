using Microsoft.EntityFrameworkCore;

namespace Registration;

public sealed class CasinoDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public CasinoDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=casino.db");
    }

    public async Task<bool> IsEmailOccupiedAsync(string email)
    {
        email = email.ToLower();
        return await Users.AnyAsync(user => user.Email.ToLower() == email);
    }

    public async Task<bool> IsNicknameOccupiedAsync(string nickname)
    {
        nickname = nickname.ToLower();
        return await Users.AnyAsync(user => user.Nickname.ToLower() == nickname);
    }

    public async Task<bool> IsPhoneOccupiedAsync(string phone)
    {
        phone = phone.ToLower();
        return await Users.AnyAsync(user => user.Phone.ToLower() == phone);
    }

    public async Task AddUserAsync(User user)
    {
        await Users.AddAsync(user);
        await SaveChangesAsync();
    }
}