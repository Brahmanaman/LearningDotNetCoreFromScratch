using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningDotNetCoreFromScratch.Data;
using LearningDotNetCoreFromScratch.Models;
using LearningDotNetCoreFromScratch.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace LearningDotNetCoreFromScratch.Controllers
{
    [Authorize(Roles= "Student, Admin, Administrator")]
    public class StudentController : Controller
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [Authorize(Roles ="Administrator")]
        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(x => x.StudentCourse).ThenInclude(y => y.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            var courses = _context.Courses.Select(x => new SelectListItem() 
            {
                Text = x.Title, 
                Value = x.Id.ToString(),
            }).ToList();

            CreateStudentViewModel model = new CreateStudentViewModel
            {
                Courses = courses
            };
            return View(model);
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(CreateStudentViewModel model)
        {
            var student = new Student()
            {
                Name = model.Name,
                Enrolled = model.Enrolled
            };

            //selected course
            var selectedCourse = model.Courses.Where(x => x.Selected).Select(y => y.Value).ToList();

            foreach(var item in selectedCourse)
            {
                student.StudentCourse.Add(new StudentCourse()
                {
                    CourseId = int.Parse(item),
                });
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(x => x.StudentCourse).Where(y => y.Id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound();
            }
            var selectedIds = student.StudentCourse.Select(x => x.CourseId).ToList();
            var items = _context.Courses.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString(),
                Selected = selectedIds.Contains(x.Id),
            }).ToList();

            CreateStudentViewModel model = new CreateStudentViewModel()
            {
                Name = student.Name,
                Enrolled = student.Enrolled,
                Courses = items,
            };
            
            return View(model);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreateStudentViewModel model)
        {
            var student = _context.Students.Find(model.Id);
            student.Name = model.Name;
            student.Enrolled = model.Enrolled;

            var studentByID = _context.Students.Include(x => x.StudentCourse).FirstOrDefault(y => y.Id == model.Id);

            var existingIds = studentByID.StudentCourse.Select(x => x.Id).ToList();

            var selectedIds = model.Courses.Where(x => x.Selected).Select(y => y.Value).Select(int.Parse).ToList();

            var toAdd = selectedIds.Except(existingIds);
            var toRemove = existingIds.Except(selectedIds);

            student.StudentCourse = student.StudentCourse.Where(x => !toRemove.Contains(x.CourseId)).ToList();


            foreach(var item in toAdd)
            {
                student.StudentCourse.Add(new StudentCourse()
                {
                    CourseId = item
                });
            }

            _context.Students.Update(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

            
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
