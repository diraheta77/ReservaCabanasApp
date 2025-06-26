using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservaCabanasApp.Models;
using ReservaCabanasApp.Data;

namespace ReservaCabanasApp.Pages.Cabanas;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;
    [BindProperty]
    public Cabana Cabana { get; set; } = new();

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync(IFormFile? Imagen)
    {
        if (!ModelState.IsValid)
            return Page();

        // Guardar imagen si se subió
        if (Imagen != null && Imagen.Length > 0)
        {
            var fileName = Path.GetFileName(Imagen.FileName);
            var filePath = Path.Combine("wwwroot/img/cabanas", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Imagen.CopyToAsync(stream);
            }
            Cabana.ImagenUrl = $"/img/cabanas/{fileName}";
        }

        _context.Cabanas.Add(Cabana);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}