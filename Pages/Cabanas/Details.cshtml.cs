using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservaCabanasApp.Models;
using ReservaCabanasApp.Data;
using Microsoft.EntityFrameworkCore;

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
        Cabana = _context.Cabanas
            .Include(c => c.Imagenes)
            .FirstOrDefault(c => c.Id == id);
        if (Cabana == null)
            return NotFound();
        return Page();
    }
}