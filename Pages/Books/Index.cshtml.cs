﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Greab_Alexandra_lab2.Data;
using Greab_Alexandra_lab2.Models;

namespace Greab_Alexandra_lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Greab_Alexandra_lab2.Data.Greab_Alexandra_lab2Context _context;

        public IndexModel(Greab_Alexandra_lab2.Data.Greab_Alexandra_lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.Include(b => b.Publisher)
            .Include(b => b.Author)
            .ToListAsync();
        }

    }
}
