using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemProject.Areas.Developer.Controllers
{
    public class TopicContentController : Controller
    {
        ITopicContentsService topicContentService;
        public TopicContentController(ITopicContentsService topicContentService)
        {
            this.topicContentService = topicContentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult AddContent([FromBody]TopicContentsModel tc)
        
        {
            topicContentService.AddTopicContent(tc);
            return Json(tc);
        }
        public JsonResult GetTopicContents()
        {
            var st=topicContentService.GetAllTopicContents();
            return Json(st);
        }
        public JsonResult GetContnetById(int id)
        {
            var st = topicContentService.GetTopicContentById(id);
            return Json(st);
        }
        public JsonResult UpdateContnet([FromBody] TopicContentsModel tc)
        {
            topicContentService.UdpdateTopicContent(tc);
            return Json(tc);
        }
        public string DeleteContent(int id)
        {
            topicContentService.DeleteTopicContent(id);
            return "Contnet Delete Sccessfully";
        }


    }
}
