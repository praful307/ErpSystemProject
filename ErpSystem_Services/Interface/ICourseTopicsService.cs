using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface ICourseTopicsService
    {
        void AddCourseTopic(CourseTopicsModel courseTopic);
        void UpdateCourseTopic(CourseTopicsModel courseTopic);
        void DeleteCourseTopic(int courseTopicId);
        void RestoreCourseTopic(int courseTopicId);
        List<CourseTopicsModel> GetCourseTopics();
        CourseTopicsModel GetCourseTopicById(int courseTopicId);
        CourseWiseTopicAndContentsModel GetTopicAndContentByCourseId(int courseId);
    }
}
