using innovateKUYS.Business;
using innovateKUYS.Business.StudentBs;
using innovateKUYS.Models.Entities;
using innovateKUYS.Models.ViewsModels.StudentVM;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace innovateKUYS.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentService _studentService;
        public StudentController( StudentService studentService)
        {
          _studentService = studentService;   
        }
        public IActionResult Index()
        {
            ServiceResult<List<Student>> result = _studentService.List();

            return View(result.Data);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                ServiceResult<object> result = _studentService.StudentCreate(studentViewModel);
                if (!result.IsError)               
                    return RedirectToAction(nameof(Index));

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error);

                }
            }
            return View(studentViewModel);
        }

        public IActionResult Edit(int id)
        {
            ServiceResult<Student> result = _studentService.Find(id);
            if (result.Data == null)
            {
                return RedirectToAction(nameof(Index));

            }
            StudentEditViewModel model = new StudentEditViewModel
            {
                FirstName = result.Data.FirstName,
                LastName = result.Data.LastName,
                Email = result.Data.Email,
                StudentCode = result.Data.StudentCode,
                RegistrationTime = result.Data.RegistrationTime,
                PhoneNumber = result.Data.PhoneNumber,
                GraduationTime=result.Data.GraduationTime,
                IsGraduate=result.Data.IsGraduate,
                IsActive=result.Data.IsActive              

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id,StudentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                ServiceResult<Student> result = _studentService.Update(id, model);
                if(!result.IsError)
                    return RedirectToAction(nameof(Index));
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(String.Empty,err);
                }
            }
            return View(model); 
        }


        public IActionResult Delete(int id)
        {
            ServiceResult<Student> result = _studentService.Find(id);
            if (result.Data == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(result.Data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            ServiceResult<Student> result = _studentService.Find(id);
            if (result.Data == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(result.Data);
        }


        public IActionResult GetStudentDetail(int id)
        {
            ServiceResult<Student> rst = _studentService.Find(id);
            if (rst.Data == null)
            {
                return NotFound();
            }
            return PartialView("_StudentDetailPartial",rst.Data);
        }
    }
}
