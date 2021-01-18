using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Heghes_Bogdan_Lab8.Data;
using Heghes_Bogdan_Lab8.Models;

namespace Heghes_Bogdan_Lab8.Pages.Boardgames
{
    public class EditModel : PageModel
    {
        private readonly Heghes_Bogdan_Lab8.Data.Heghes_Bogdan_Lab8Context _context;

        public EditModel(Heghes_Bogdan_Lab8.Data.Heghes_Bogdan_Lab8Context context)
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
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Boardgame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardgameExists(Boardgame.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BoardgameExists(int id)
        {
            return _context.Boardgame.Any(e => e.ID == id);
        }
    }
}
