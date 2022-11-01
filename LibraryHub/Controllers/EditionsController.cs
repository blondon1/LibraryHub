using LibraryHub.Data;
using LibraryHub.Data.Services;
using LibraryHub.Data.Static;
using LibraryHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHub.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EditionsController : Controller
    {
        private readonly IEditionService _service;

        public EditionsController(IEditionService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEdition = await _service.GetAllAsync();
            return View(allEdition);
        }


        //Get: Edition/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Edition edition)
        {
            if (!ModelState.IsValid) return View(edition);
            await _service.AddAsync(edition);
            return RedirectToAction(nameof(Index));
        }

        //Get: Edition/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        //Get: Edition/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Edition edition)
        {
            if (!ModelState.IsValid) return View(edition);
            await _service.UpdateAsync(id, edition);
            return RedirectToAction(nameof(Index));
        }

        //Get: Edition/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
