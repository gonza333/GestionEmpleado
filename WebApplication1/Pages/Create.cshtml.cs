using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestionEmpleados.Data;
using GestionEmpleados.Models;

namespace GestionEmpleados.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(Empleado);
                _context.SaveChanges();

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
