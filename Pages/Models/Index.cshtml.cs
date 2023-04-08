using BD9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BD9.Pages.Models
{
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<Model> Models { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Models = context.Models.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Models.FindAsync(id);

            if (user != null)
            {
                context.Models.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}