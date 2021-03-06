﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPtask.Data;
using ASPtask.Models;
using System.Diagnostics;
using System;

namespace ASPtask.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsDB _context;
        public StudentsController(StudentsDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new ViewModel { AllStudents = GetStudents(), AllQuestions = GetQuestions(), AllUniversities = GetUniversities(), OneStudent = new Student { } });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null) return NotFound();
            return View(student);
        }
        public List<Student> GetStudents()
        {
            return _context.Students.ToList<Student>();
        }
        public List<Question> GetQuestions()
        {
            return _context.Questions.ToList<Question>();
        }
        public List<University> GetUniversities()
        {
            return _context.Universities.ToList<University>();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewStudentEntry(ViewModel viewmodel)
        {
            Dictionary<int, List<string>> answers = new Dictionary<int, List<string>>();
            var coll = Request.Form.ToList();
                
            foreach (var str in coll)
            {
                if (int.TryParse(str.Key, out int id))
                {
                    if (answers.ContainsKey(id)) answers[1].Add(str.Value);
                    else answers.Add(id, new List<string> { str.Value });
                }
            }
            viewmodel.OneStudent.Answers = answers;
            _context.Students.Add(viewmodel.OneStudent);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AddNewStudentEntry()
        {
            return View(new ViewModel { AllStudents=GetStudents(), AllQuestions=GetQuestions(), AllUniversities=GetUniversities(), OneStudent = new Student { } });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,EMail,Course,UniversityID,Answers")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int?id)
        {
            if (id == null) return NotFound();
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(new ViewModel { AllStudents = GetStudents(), AllUniversities = GetUniversities(), AllQuestions = GetQuestions(), OneStudent = student});
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ViewModel student)
        {
            Dictionary<int, List<string>> answers = new Dictionary<int, List<string>>();
            var coll = Request.Form.ToList();
            foreach (var str in coll)
            {
                if (int.TryParse(str.Key, out int key))
                {
                    if (answers.ContainsKey(key)) answers[key].Add(str.Value);
                    else answers.Add(key, new List<string> { str.Value });
                    Debug.WriteLine(str.Value);
                }
            }
            student.OneStudent.Answers = answers;
            try
            {
                _context.Update(student.OneStudent);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.OneStudent.StudentID)) return NotFound();
                else throw;
            }
            return RedirectToAction("Index", "Students");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null) return NotFound();
            return View(student);
        }

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
            return _context.Students.Any(e => e.StudentID == id);
        }
    }
}
