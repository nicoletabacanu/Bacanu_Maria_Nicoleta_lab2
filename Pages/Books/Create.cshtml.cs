﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bacanu_Maria_Nicoleta_lab2.Data;
using Bacanu_Maria_Nicoleta_lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bacanu_Maria_Nicoleta_lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Bacanu_Maria_Nicoleta_lab2.Data.Bacanu_Maria_Nicoleta_lab2Context _context;

        public CreateModel(Bacanu_Maria_Nicoleta_lab2.Data.Bacanu_Maria_Nicoleta_lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        { 
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
           "PublisherName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var newBook = new Book();
            var selectedCategories = Request.Form["selectedCategories"];

            if (selectedCategories.Any())
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
    
}
