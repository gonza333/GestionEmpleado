using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionEmpleados.Data;
using GestionEmpleados.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionEmpleados.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleados { get; set; }

        // Este método se ejecuta al cargar la página
        public async Task OnGetAsync()
        {
            Empleados = await _context.Empleados.ToListAsync();
        }

        // Este método se ejecuta al eliminar un empleado
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
