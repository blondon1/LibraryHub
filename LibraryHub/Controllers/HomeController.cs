using LibraryHub.Data;
using LibraryHub.Data.Services;
using LibraryHub.Data.Static;
using LibraryHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHub.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class HomeController : Controller
    {
        private readonly IBooksService _service;

        public HomeController(IBooksService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllAsync(n => n.Edition);
            return View(allBooks);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync(n => n.Edition);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allBooks.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allBooks.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allBooks);
        }

        //GET: Books/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        //GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Edition = new SelectList(movieDropdownsData.Edition, "Id", "Name");
            ViewBag.Publishers = new SelectList(movieDropdownsData.Publishers, "Id", "FullName");
            ViewBag.Authors = new SelectList(movieDropdownsData.Author, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Edition = new SelectList(movieDropdownsData.Edition, "Id", "Name");
                ViewBag.Publishers = new SelectList(movieDropdownsData.Publishers, "Id", "FullName");
                ViewBag.Authors = new SelectList(movieDropdownsData.Author, "Id", "FullName");

                return View(book);
            }

            await _service.AddNewMovieAsync(book);
            return RedirectToAction(nameof(Index));
        }


        //GET: Books/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                BookCategory = movieDetails.BookCategory,
                EditionId = movieDetails.EditionId,
                PublisherId = movieDetails.PublisherId,
                AuthorIds = movieDetails.Authors_Books.Select(n => n.AuthorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Edition = new SelectList(movieDropdownsData.Edition, "Id", "Name");
            ViewBag.Publishers = new SelectList(movieDropdownsData.Publishers, "Id", "FullName");
            ViewBag.Authors = new SelectList(movieDropdownsData.Author, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
            if (id != book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Edition = new SelectList(movieDropdownsData.Edition, "Id", "Name");
                ViewBag.Publishers = new SelectList(movieDropdownsData.Publishers, "Id", "FullName");
                ViewBag.Authors = new SelectList(movieDropdownsData.Author, "Id", "FullName");

                return View(book);
            }

            await _service.UpdateMovieAsync(book);
            return RedirectToAction(nameof(Index));
        }
    }
}