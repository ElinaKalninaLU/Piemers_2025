using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geometry;

namespace Lekcija13.Controllers
{
    public class RectanglesController : Controller
    {
        private readonly GeometryContext _context;

        public RectanglesController(GeometryContext context)
        {
            _context = context;
        }

        // GET: Rectangles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rectangles.ToListAsync());
        }

        // GET: Rectangles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rectangle = await _context.Rectangles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rectangle == null)
            {
                return NotFound();
            }

            return View(rectangle);
        }

        // GET: Rectangles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rectangles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Height,Width,ID,Name,MyColor")] Rectangle rectangle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rectangle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rectangle);
        }

        // GET: Rectangles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rectangle = await _context.Rectangles.FindAsync(id);
            if (rectangle == null)
            {
                return NotFound();
            }
            return View(rectangle);
        }

        // POST: Rectangles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Height,Width,ID,Name,MyColor")] Rectangle rectangle)
        {
            if (id != rectangle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rectangle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RectangleExists(rectangle.ID))
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
            return View(rectangle);
        }

        // GET: Rectangles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rectangle = await _context.Rectangles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rectangle == null)
            {
                return NotFound();
            }

            return View(rectangle);
        }

        // POST: Rectangles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rectangle = await _context.Rectangles.FindAsync(id);
            if (rectangle != null)
            {
                _context.Rectangles.Remove(rectangle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RectangleExists(int id)
        {
            return _context.Rectangles.Any(e => e.ID == id);
        }
    }
}
