using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T1708E_Website.Models;

namespace T1708E_Website.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return new JsonResult(_context.Students.ToList());
        }

        public IActionResult LoadListSv()
        {
            return View(_context.Students.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
        public IActionResult DeleteData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return new JsonResult(student);
        }

        [Route("/Student/Load/")]
        [HttpPut("{id}")]
        public IActionResult Load(Student student)
        {
            var stu = _context.Students.Find(student.Id);
            if (stu == null)
            {
                return NotFound();
            }

            stu.Name = student.Name;
            stu.RollNumber = student.RollNumber;
            _context.Students.Update(stu);
            _context.SaveChanges();

            return View("Index");
        }

        [Route("/Student/Delete/")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Student student)
        {
            var del = _context.Students.Find(student.Id);
            if (del == null)
            {
                return NotFound();
            }

            _context.Students.Remove(del);
            _context.SaveChanges();
            return View("Index");
        }
    }
}