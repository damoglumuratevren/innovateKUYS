using innovateKUYS.Business;
using innovateKUYS.Business.CourseStudentBS;
using innovateKUYS.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace innovateKUYS.Controllers
{
    public class CourseStudentController : Controller
    {

        private readonly CourseStudentService _courseStudentService;
        public CourseStudentController(CourseStudentService courseStudentService)
        {
            _courseStudentService = courseStudentService;
        }


        public IActionResult Index()
        {
            ServiceResult<List<CourseStudent>> result = _courseStudentService.List();

            return View(result.Data);
        }
    }
}
