using System.Threading.Tasks;

using BD9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BD9.Pages.Models
{
        [IgnoreAntiforgeryToken]
        public class CreateModel : PageModel
        {
            ApplicationContext context;
            [BindProperty]
            public Model Mod { get; set; } = new();
            public CreateModel(ApplicationContext db)
            {
                context = db;
            }
            public async Task<IActionResult> OnPostAsync()
            {
                context.Models.Add(Mod);
                await context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
        }
}
