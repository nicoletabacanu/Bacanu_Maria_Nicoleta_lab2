﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bacanu_Maria_Nicoleta_lab2.Data;
using Bacanu_Maria_Nicoleta_lab2.Models;

namespace Bacanu_Maria_Nicoleta_lab2.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly Bacanu_Maria_Nicoleta_lab2.Data.Bacanu_Maria_Nicoleta_lab2Context _context;

        public EditModel(Bacanu_Maria_Nicoleta_lab2.Data.Bacanu_Maria_Nicoleta_lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public BookCategory BookCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookCategory == null)
            {
                return NotFound();
            }

            var bookcategory =  await _context.BookCategory.FirstOrDefaultAsync(m => m.ID == id);
            if (bookcategory == null)
            {
                return NotFound();
            }
            BookCategory = bookcategory;
           ViewData["BookID"] = new SelectList(_context.Book, "ID", "ID");
           ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCategoryExists(BookCategory.ID))
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

        private bool BookCategoryExists(int id)
        {
          return (_context.BookCategory?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
