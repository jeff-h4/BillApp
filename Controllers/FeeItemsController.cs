using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BillApp.Models;
using BillApp.Data;

namespace BillApp.Controllers
{
    public class FeeItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeeItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FeeItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeeItem.ToListAsync());
        }

        // GET: FeeItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeItem = await _context.FeeItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feeItem == null)
            {
                return NotFound();
            }

            return View(feeItem);
        }

        // GET: FeeItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeeItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransactionDate,Code,Notes")] FeeItem feeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feeItem);
        }

        // GET: FeeItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeItem = await _context.FeeItem.FindAsync(id);
            if (feeItem == null)
            {
                return NotFound();
            }
            return View(feeItem);
        }

        // POST: FeeItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TransactionDate,Code,Notes")] FeeItem feeItem)
        {
            if (id != feeItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeItemExists(feeItem.Id))
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
            return View(feeItem);
        }

        // GET: FeeItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeItem = await _context.FeeItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feeItem == null)
            {
                return NotFound();
            }

            return View(feeItem);
        }

        // POST: FeeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feeItem = await _context.FeeItem.FindAsync(id);
            _context.FeeItem.Remove(feeItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeeItemExists(int id)
        {
            return _context.FeeItem.Any(e => e.Id == id);
        }
    }
}
