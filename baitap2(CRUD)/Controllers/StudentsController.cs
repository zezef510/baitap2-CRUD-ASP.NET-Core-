using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using baitap2_CRUD_.Models;

namespace baitap2_CRUD_.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MvcMovieContext _context;

        public StudentsController(MvcMovieContext context)
        {
            _context = context;
        }
      
        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Movie
                .FirstOrDefaultAsync(m => m.HocSinhID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        // GET: Students/Female
        public async Task<IActionResult> Female()
        {
            var femaleStudents = await _context.Movie.Where(s => s.GioiTinh == true).ToListAsync(); 
            return View("Female",femaleStudents);
        }

        // GET: Students/Male
        public async Task<IActionResult> Male()
        {
            var maleStudents = await _context.Movie.Where(s => s.GioiTinh == false).ToListAsync();
            return View("Male",maleStudents);
        }


        // GET: Students/ByBirthYear/2003
        public async Task<IActionResult> ByBirthYear()
        {
            var studentsByYear = await _context.Movie
                .Where(s => s.NgaySinh.Year == 2003 && s.NgaySinh >= new DateTime(2003, 1, 1) && s.NgaySinh < new DateTime(2003 + 1, 1, 1))
                .ToListAsync();
            return View("ByBirthYear", studentsByYear);
        }


        // GET: Students/BySalary/10000
        public async Task<IActionResult> BySalary()
        {
            var studentsBySalary = await _context.Movie.Where(s => s.Luong == 10000).ToListAsync();

            return View("BySalary",studentsBySalary);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HocSinhID,HoTen,GioiTinh,Tuoi,NgaySinh,Luong")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Movie.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HocSinhID,HoTen,GioiTinh,Tuoi,NgaySinh,Luong")] Student student)
        {
            if (id != student.HocSinhID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.HocSinhID))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Movie
                .FirstOrDefaultAsync(m => m.HocSinhID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Movie.Any(e => e.HocSinhID == id);
        }
    }
}
