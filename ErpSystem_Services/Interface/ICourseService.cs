using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface ICourseService
    {
        void AddCourse(CoursesModel courses);
        void UpdateCourse(CoursesModel courses);
        void DeleteCourse(int courseId);
        void RestoreCourse(int courseId);
        List<CoursesModel> GetAllCourses();
        CoursesModel GetCourseById(int courseId);

    }
}
