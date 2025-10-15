using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemProject.Areas.Developer.Controllers
{
    public class TopicController : Controller
    {
        ITopicService topicService;
        public TopicController(ITopicService topicService)
        {
            this.topicService = topicService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult AddTopic([FromBody] TopicsModel t)
        {
            topicService.AddTopic(t);
            return Json(t);
        }
        public JsonResult GetTopic()        
        {
            var tp = topicService.GetAllTopics();
            return Json(tp);
        }
        public JsonResult GetTopicByid(int id)
        {
            var tp = topicService.GetTopicById(id);
            return Json(tp);
        }
        public JsonResult updateTopic([FromBody]TopicsModel m)
        {
            topicService.UpdateTopic(m);
            return Json(m);
        }
        public string DeleteTopic(int id)
        {
            topicService.DeleteTopic(id);
            return "Topic Delete Successfully";
        }
    }
}
