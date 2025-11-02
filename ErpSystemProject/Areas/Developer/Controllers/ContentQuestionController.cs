using ErpSystem_Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemProject.Areas.Developer.Controllers
{
    public class ContentQuestionController : Controller
    {
        IMcqsQuestionsService mcqsQuestionsService;
        public ContentQuestionController(IMcqsQuestionsService mcqsQuestionsService)
        {
            this.mcqsQuestionsService = mcqsQuestionsService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
