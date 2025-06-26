using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservaCabanasApp.Models;
using ReservaCabanasApp.Data;

namespace ReservaCabanasApp.Pages.Cabanas;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public List<Cabana> Cabanas { get; set; } = new();

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Cabanas = _context.Cabanas.ToList();
    }
}