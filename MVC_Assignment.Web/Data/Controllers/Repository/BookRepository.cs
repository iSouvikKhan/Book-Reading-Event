using Microsoft.EntityFrameworkCore;
using MVC_Assignment_1.Data;
using MVC_Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Assignment_1.Repository
{
    public class BookRepository
    {

        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatededOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };


            newBook.bookGallery = new List<BookGallery>();

            foreach(var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync(); // for this only, data will hit database

            return newBook.Id;
        }

        //public async Task<List<BookModel>> GetAllBooks()
        //{
        //    var books = new List<BookModel>();
        //    var allbooks = await _context.Books.ToListAsync();
        //    if (allbooks?.Any() == true)
        //    {
        //        foreach (var book in allbooks)
        //        {
        //            books.Add(new BookModel()
        //            {
        //                Author = book.Author,
        //                Catagory = book.Catagory,
        //                Description = book.Description,
        //                Id = book.Id,
        //                LanguageId = book.LanguageId,
        //                Language = book.Language.Name,
        //                Title = book.Title,
        //                TotalPages = book.TotalPages,
        //                CoverImageUrl = book.CoverImageUrl
        //            }) ;
        //        }
        //    }
        //    return books;
        //}


        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Catagory = book.Catagory,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl
                }).ToListAsync();
        }


        public async Task<List<BookModel>> GetTopBookAsync(int count)
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Catagory = book.Catagory,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl
                }).Take(count).ToListAsync();
        }




        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Catagory = book.Catagory,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.bookGallery.Select(g=>new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl

                }).FirstOrDefaultAsync();
        }




        public List<BookModel> SearchBook(string title, string authorName)
        {
            //return DataSource().Where(X => X.Title == title && X.Author == authorName).ToList();
            return null;
        }

        //private List<BookModel> DataSource()
        //{
        //    return new List<BookModel>()
        //    {
        //        new BookModel(){Id=1,Title="MVC",Author="Nitish", Description="Describe Yourself", Catagory="Programming", TotalPages=123},
        //        new BookModel(){Id=2,Title="Python",Author="Amit", Description="Describe Yourself", Catagory="ML/DL", TotalPages=436}
        //    };
        //}


    }
}
