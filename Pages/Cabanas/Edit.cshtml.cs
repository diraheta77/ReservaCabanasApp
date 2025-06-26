using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservaCabanasApp.Models;
using ReservaCabanasApp.Data;

namespace ReservaCabanasApp.Pages.Cabanas;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;
    [BindProperty]
    public Cabana Cabana { get; set; } = new();

    public EditModel(AppDbContext context)
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

    public async Task<IActionResult> OnPostAsync(IFormFile? Imagen)
    {
        if (!ModelState.IsValid)
            return Page();

        var cabanaDb = _context.Cabanas.Find(Cabana.Id);
        if (cabanaDb == null)
            return NotFound();

        // Actualizar campos
        cabanaDb.Nombre = Cabana.Nombre;
        cabanaDb.Capacidad = Cabana.Capacidad;
        cabanaDb.CamasMatrimonial = Cabana.CamasMatrimonial;
        cabanaDb.CamasIndividuales = Cabana.CamasIndividuales;
        cabanaDb.PrecioPorNoche = Cabana.PrecioPorNoche;
        cabanaDb.Observaciones = Cabana.Observaciones;
        cabanaDb.Activa = Cabana.Activa;

        // Imagen
        if (Imagen != null && Imagen.Length > 0)
        {
            var fileName = Path.GetFileName(Imagen.FileName);
            var filePath = Path.Combine("wwwroot/img/cabanas", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Imagen.CopyToAsync(stream);
            }
            cabanaDb.ImagenUrl = $"/img/cabanas/{fileName}";
        }

        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}