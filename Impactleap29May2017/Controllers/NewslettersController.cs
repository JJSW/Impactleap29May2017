using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Impactleap29May2017.Data;
using Impactleap29May2017.Models;

namespace Impactleap29May2017.Controllers
{
    public class NewslettersController : Controller
    {
        private readonly ClientContext _context;

        public NewslettersController(ClientContext context)
        {
            _context = context;    
        }

        // GET: Newsletters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Newsletters.ToListAsync());
        }

        // GET: Newsletters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletters
                .SingleOrDefaultAsync(m => m.ID == id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }

        // GET: Newsletters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Company,SignUpDate")] Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsletter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newsletter);
        }

        // GET: Newsletters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletters.SingleOrDefaultAsync(m => m.ID == id);
            if (newsletter == null)
            {
                return NotFound();
            }
            return View(newsletter);
        }

        // POST: Newsletters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Company,SignUpDate")] Newsletter newsletter)
        {
            if (id != newsletter.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsletter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsletterExists(newsletter.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(newsletter);
        }

        // GET: Newsletters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletters
                .SingleOrDefaultAsync(m => m.ID == id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }

        // POST: Newsletters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsletter = await _context.Newsletters.SingleOrDefaultAsync(m => m.ID == id);
            _context.Newsletters.Remove(newsletter);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NewsletterExists(int id)
        {
            return _context.Newsletters.Any(e => e.ID == id);
        }
    }
}
