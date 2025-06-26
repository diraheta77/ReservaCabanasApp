using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservaCabanasApp.Models;
using ReservaCabanasApp.Data;

namespace ReservaCabanasApp.Pages.Cabanas;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;
    public Cabana Cabana { get; set; } = new();

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet(int id)
    {
        Cabana = _context.Cabanas.Find(id);
        if (Cabana == null)
            return NotFound();
        return Page();
    }
}