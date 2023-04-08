using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BD9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BD9.Pages.Emploees
{
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<Emploee> Emps { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Emps = context.Emps.AsNoTracking().ToList();
        }
        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    Emps = await context.Emps
        //        .Include(c => c.ContactInform)
        //        .FirstOrDefaultAsync(m => m.id == id);

        //    if (Rent == null)
        //        return NotFound();

        //    ItemDropDownList(_db, Rent.ItemId);
        //    CustomerDropDownList(_db, Rent.CustomerId);

        //    return Page();
        //}

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Emps.FindAsync(id);

            if (user != null)
            {   
                context.Emps.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
