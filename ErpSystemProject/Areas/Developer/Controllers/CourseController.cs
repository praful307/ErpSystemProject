using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemProject.Areas.Developer.Controllers
{

    public class CourseController : Controller
    {
      
        ICourseService courses;
        public CourseController(ICourseService courses)
        {
           this. courses = courses;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  JsonResult AddCourse([FromBody] CoursesModel cou)
        {
            courses.AddCourse(cou);
            return Json(cou);
        }
        public  JsonResult GetCourses()
        {
         var getall=  courses.GetAllCourses();
            return Json(getall);
        }
        public JsonResult GetCourseById(int id)
        {
            var getbyid= courses.GetCourseById(id);
            return Json(getbyid);
            
        }
        public string DeleteCourse(int id)
        {
            courses.DeleteCourse(id);
            return "Course Delete Successfully";
        }
    }
}
