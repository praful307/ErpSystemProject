using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface ICourseFeesService
    {
        void AddCourseFees(CourseFeesModel fees);
        void UdpateCourses(CourseFeesModel fees);
            void DeleteCourseFees(int feesId);
        void RestoreCourseFees(int feesId);
        List<CourseFeesModel> GetAllCoursesFees();
      CourseFeesModel GetCourseFeesById(int feesId);
       //Task<CourseFeesModel> GetCourseWiseFees(int courseId);
    }
}
