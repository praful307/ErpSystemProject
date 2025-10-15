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
    }
}
