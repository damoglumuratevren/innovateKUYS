using innovateKUYS.Business;
using innovateKUYS.Models.ViewsModels.StudentVM;
using Microsoft.AspNetCore.Mvc;

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
            return View();
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
                ServiceResult result = _studentService.StudentCreate(studentViewModel);
                if (!result.IsError)               
                    return RedirectToAction(nameof(Index));

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error);

                }
            }
            return View(studentViewModel);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
