using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Greab_Alexandra_lab2.Data;
using Greab_Alexandra_lab2.Models;

namespace Greab_Alexandra_lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Greab_Alexandra_lab2.Data.Greab_Alexandra_lab2Context _context;

        public DetailsModel(Greab_Alexandra_lab2.Data.Greab_Alexandra_lab2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowings == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowings.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
