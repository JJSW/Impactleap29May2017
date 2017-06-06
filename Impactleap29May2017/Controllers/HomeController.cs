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
    public class HomeController : Controller
    {
        private readonly ClientContext _context;

        public HomeController(ClientContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult OnDemand()
        {
            return View();
        }

        public ActionResult Advisory()
        {
            return View();
        }

        public IActionResult Clients()
        {
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clients([Bind("Name,Email,Company")] Newsletter newsletter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newsletter.SignUpDate = DateTime.Today;
                    _context.Add(newsletter);
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

            return View(newsletter);

        }

        public ActionResult Pricing()
        {
            return View();
        }

        public ActionResult People()
        {
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> People([Bind("Name,Email,Company")] Newsletter newsletter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newsletter.SignUpDate = DateTime.Today;
                    _context.Add(newsletter);
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

        public IActionResult About()
        {
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> About([Bind("Name,Email,Company")] Newsletter newsletter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newsletter.SignUpDate = DateTime.Today;
                    _context.Add(newsletter);
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

        public IActionResult Contact()
        {

            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact([Bind("Name,Email,Company")] Newsletter newsletter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newsletter.SignUpDate = DateTime.Today;
                    _context.Add(newsletter);
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

        public ActionResult Update()
        {
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Name,Email,Company")] Newsletter newsletter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newsletter.SignUpDate = DateTime.Today;
                    _context.Add(newsletter);
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
