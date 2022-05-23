using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Registration.Pages;

public class AllUsersModel : PageModel
{
    public CasinoDbContext DB;

    public AllUsersModel(CasinoDbContext db)
    {
        DB = db;
    }

    public void OnGet()
    {
        
    }
}