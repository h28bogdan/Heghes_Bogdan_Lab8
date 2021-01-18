using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Heghes_Bogdan_Lab8.Data;
using Heghes_Bogdan_Lab8.Models;

namespace Heghes_Bogdan_Lab8.Pages.Boardgames
{
    public class DeleteModel : PageModel
    {
        private readonly Heghes_Bogdan_Lab8.Data.Heghes_Bogdan_Lab8Context _context;

        public DeleteModel(Heghes_Bogdan_Lab8.Data.Heghes_Bogdan_Lab8Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Boardgame Boardgame { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Boardgame = await _context.Boardgame.FirstOrDefaultAsync(m => m.ID == id);

            if (Boardgame == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Boardgame = await _context.Boardgame.FindAsync(id);

            if (Boardgame != null)
            {
                _context.Boardgame.Remove(Boardgame);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
