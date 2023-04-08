using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BD9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BD9.Pages.ContactInforms
{
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<ContactInform> Informs { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Informs = context.Informs.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Informs.FindAsync(id);

            if (user != null)
            {
                context.Informs.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
