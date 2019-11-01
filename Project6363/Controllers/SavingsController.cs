using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project6363.Models;

namespace Project6363.Controllers
{
    public class SavingsController : Controller
    {
        private readonly BankDbContext _context;

        public SavingsController(BankDbContext context)
        {
            _context = context;
        }

        // GET: Savings
        public async Task<IActionResult> Index()
        {
            var bankDbContext = _context.Saving.Include(s => s.Customer);
            return View(await bankDbContext.ToListAsync());
        }

        // GET: Savings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saving = await _context.Saving
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saving == null)
            {
                return NotFound();
            }

            return View(saving);
        }

        // GET: Savings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            return View();
        }

        // POST: Savings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,type,accountNumber,CustomerId,InterestRate,Balance,createdAt,status,period,dateAndTime")] Saving saving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", saving.CustomerId);
            return View(saving);
        }

        // GET: Savings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saving = await _context.Saving.FindAsync(id);
            if (saving == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", saving.CustomerId);
            return View(saving);
        }

        // POST: Savings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,type,accountNumber,CustomerId,InterestRate,Balance,createdAt,status,period,dateAndTime")] Saving saving)
        {
            if (id != saving.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavingExists(saving.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", saving.CustomerId);
            return View(saving);
        }

        // GET: Savings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saving = await _context.Saving
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saving == null)
            {
                return NotFound();
            }

            return View(saving);
        }

        // POST: Savings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saving = await _context.Saving.FindAsync(id);
            _context.Saving.Remove(saving);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavingExists(int id)
        {
            return _context.Saving.Any(e => e.Id == id);
        }
    }
}
