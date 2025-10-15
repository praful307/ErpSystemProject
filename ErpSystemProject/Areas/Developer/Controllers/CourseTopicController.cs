using ErpSystem_Models;
using ErpSystem_Services.Interface;

using Microsoft.AspNetCore.Mvc;

namespace ErpSystemProject.Areas.Developer.Controllers
{
 
    public class CourseTopicController : Controller
    {
        ICourseTopicsService courseTopicsService;
        ITopicService topicService;
            public CourseTopicController(ICourseTopicsService courseTopicsService, ITopicService topicService)
        {
            this.courseTopicsService = courseTopicsService;
            this.topicService = topicService;
        }
        public IActionResult Index()
        {
            List<TopicModelCheckbox> lst = GetTopic();

            return View(lst);
        }
        public JsonResult GetCourseTopic()
        {
            var ct = courseTopicsService.GetCourseTopics();
            return Json(ct);
        }
        [HttpPost]
        public JsonResult AddCourseWiseTopic([FromBody]CourseTopicRequest model)
        {
            if (model == null || model.Topics == null || model.Topics.Count == 0)
            { 

                return Json("No topic selected");
            }
            foreach ( var topic in model.Topics )
            {
                CourseTopicsModel ct = new CourseTopicsModel()
                {
                    CourseId = model.CourseId,
                    TopicId=topic.TopicId
                };
                courseTopicsService.AddCourseTopic(ct);
            }
            return Json(new { success = true, message = "Topics added successfully!" });
        }


      public List <TopicModelCheckbox>GetTopic()
        {
            List<TopicsModel> lst = topicService.GetAllTopics();
            List<TopicModelCheckbox>topicmodel= new List<TopicModelCheckbox>();
            foreach(TopicsModel  t in lst)
            {
                TopicModelCheckbox ts = new TopicModelCheckbox()
                {
                    TopicId = t.TopicId,
                    TopicName=t.TopicName,
                    Iselected=false,
                };
                topicmodel.Add(ts);
            }
            return topicmodel;
        }

        public JsonResult GetCourseWiseTopic(int id)
        {
            var ct = courseTopicsService.GetTopicAndContentByCourseId(id);
            return Json(ct);
        }
    }

}
