using LibraryHub.Data.Base;
using LibraryHub.Data.ViewModels;
using LibraryHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHub.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewBookVM data)
        {
            var newMovie = new Book()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                EditionId = data.EditionId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                BookCategory = data.BookCategory,
                PublisherId = data.PublisherId
            };
            await _context.Books.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Book Authors
            foreach (var actorId in data.AuthorIds)
            {
                var newActorMovie = new Author_Book()
                {
                    BookId = newMovie.Id,
                    AuthorId = actorId
                };
                await _context.Authors_Books.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Books
                .Include(c => c.Edition)
                .Include(p => p.Publisher)
                .Include(am => am.Authors_Books).ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Author = await _context.Authors.OrderBy(n => n.FullName).ToListAsync(),
                Edition = await _context.Editions.OrderBy(n => n.Name).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewBookVM data)
        {
            var dbMovie = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.EditionId = data.EditionId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.BookCategory = data.BookCategory;
                dbMovie.PublisherId = data.PublisherId;
                await _context.SaveChangesAsync();
            }

            //Remove existing Authors
            var existingActorsDb = _context.Authors_Books.Where(n => n.BookId == data.Id).ToList();
            _context.Authors_Books.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Book Authors
            foreach (var actorId in data.AuthorIds)
            {
                var newActorMovie = new Author_Book()
                {
                    BookId = data.Id,
                    AuthorId = actorId
                };
                await _context.Authors_Books.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
