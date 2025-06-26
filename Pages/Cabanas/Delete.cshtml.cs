using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservaCabanasApp.Models;
using ReservaCabanasApp.Data;

namespace ReservaCabanasApp.Pages.Cabanas;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;
    [BindProperty]
    public Cabana Cabana { get; set; } = new();

    public DeleteModel(AppDbContext context)
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

    public async Task<IActionResult> OnPostAsync()
    {
        var cabanaDb = _context.Cabanas.Find(Cabana.Id);
        if (cabanaDb == null)
            return NotFound();

        _context.Cabanas.Remove(cabanaDb);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}