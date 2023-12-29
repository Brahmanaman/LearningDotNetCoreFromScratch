using LearningDotNetCoreFromScratch.Data;
using LearningDotNetCoreFromScratch.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDotNetCoreFromScratch.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Section of Courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(string sortOrder)
        {
            ViewData["TitleSort"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["CodeSort"] = string.IsNullOrEmpty(sortOrder) ? "Code_desc" : "";

            var courses = _context.Courses.ToList();
            switch (sortOrder)
            {
                case "title_desc":
                    courses = courses.OrderByDescending(s=>s.Title).ToList();
                    break;

                case "Code_desc":
                    courses = courses.OrderByDescending(s => s.Code).ToList();
                    break;

                default:
                    courses = courses.OrderBy(s => s.Title).ToList();
                    break;
            }
            //var courses = _context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
            return View(course);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
            return View(course);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
            return View(course);
        }


        /// <summary>
        /// Post Section Of Courses Model
        /// </summary>
        /// <returns></returns>

       
        [HttpPost]
        public IActionResult Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Edit(Course course)
        {
           _context.Courses.Update(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
