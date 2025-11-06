using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemProject.Areas.Developer.Controllers
{
    public class CourseFeesController : Controller
    {
        ICourseFeesService courseFeesService;
        public CourseFeesController(ICourseFeesService courseFeesService)
        {
            this.courseFeesService = courseFeesService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddCourseFee([FromBody] CourseFeesModel cf)
        {
            courseFeesService.AddCourseFees(cf);
            return Json(cf);
        }
        public  JsonResult GetCourseFees()
        {
            var cf = courseFeesService.GetAllCoursesFees();
            return Json(cf);
        }
        public IActionResult DisplayCourseFees()
        {
            return View();
        }
    }
}
