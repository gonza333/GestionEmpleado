using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionEmpleados.Data;
using GestionEmpleados.Models;
using System.Threading.Tasks;

namespace GestionEmpleados.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; }

        // Este método se ejecuta al cargar la página para editar un empleado
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Id == id);

            if (Empleado == null)
            {
                return NotFound();
            }
            return Page();
        }

        // Este método se ejecuta al guardar los cambios del empleado
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(Empleado.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("/Index");
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
