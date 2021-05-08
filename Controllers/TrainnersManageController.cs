using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssigmentCode.Data;
using AssigmentCode.Models;

namespace AssigmentCode.Controllers
{
    public class TrainnersManageController : Controller
    {
        private readonly CMSContext _context;

        public TrainnersManageController(CMSContext context)
        {
            _context = context;
        }

        // GET: TrainnersManage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trainners.ToListAsync());
        }

        // GET: TrainnersManage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainner = await _context.Trainners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainner == null)
            {
                return NotFound();
            }

            return View(trainner);
        }

        // GET: TrainnersManage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainnersManage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Phone,Education,WorkingPlace,Id,Username,Email,Password")] Trainner trainner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainner);
        }

        // GET: TrainnersManage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainner = await _context.Trainners.FindAsync(id);
            if (trainner == null)
            {
                return NotFound();
            }
            return View(trainner);
        }

        // POST: TrainnersManage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Phone,Education,WorkingPlace,Id,Username,Email,Password")] Trainner trainner)
        {
            if (id != trainner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainnerExists(trainner.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trainner);
        }

        // GET: TrainnersManage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainner = await _context.Trainners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainner == null)
            {
                return NotFound();
            }

            return View(trainner);
        }

        // POST: TrainnersManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainner = await _context.Trainners.FindAsync(id);
            _context.Trainners.Remove(trainner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainnerExists(int id)
        {
            return _context.Trainners.Any(e => e.Id == id);
        }
    }
}
