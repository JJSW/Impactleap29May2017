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
    public class FreeReportsController : Controller
    {
        private readonly ClientContext _context;

        public FreeReportsController(ClientContext context)
        {
            _context = context;    
        }

        public ActionResult RequestReport()
        {
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestReport([Bind("Name,Email,Company")] FreeReport freeReport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    freeReport.SignUpDate = DateTime.Today;
                    _context.Add(freeReport);
                    await _context.SaveChangesAsync();
                    ViewBag.SuccessMessage = "Your details have been registered successfully!";
                    ModelState.Clear();
                    return View();
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View();

        }

        // GET: FreeReports
        public async Task<IActionResult> Index()
        {
            return View(await _context.FreeReports.ToListAsync());
        }

        // GET: FreeReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freeReport = await _context.FreeReports
                .SingleOrDefaultAsync(m => m.ID == id);
            if (freeReport == null)
            {
                return NotFound();
            }

            return View(freeReport);
        }

        // GET: FreeReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FreeReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Company,SignUpDate")] FreeReport freeReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freeReport);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(freeReport);
        }

        // GET: FreeReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freeReport = await _context.FreeReports.SingleOrDefaultAsync(m => m.ID == id);
            if (freeReport == null)
            {
                return NotFound();
            }
            return View(freeReport);
        }

        // POST: FreeReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Company,SignUpDate")] FreeReport freeReport)
        {
            if (id != freeReport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freeReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreeReportExists(freeReport.ID))
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
            return View(freeReport);
        }

        // GET: FreeReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freeReport = await _context.FreeReports
                .SingleOrDefaultAsync(m => m.ID == id);
            if (freeReport == null)
            {
                return NotFound();
            }

            return View(freeReport);
        }

        // POST: FreeReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freeReport = await _context.FreeReports.SingleOrDefaultAsync(m => m.ID == id);
            _context.FreeReports.Remove(freeReport);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FreeReportExists(int id)
        {
            return _context.FreeReports.Any(e => e.ID == id);
        }
    }
}
