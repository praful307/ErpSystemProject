using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface ITopicContentsService
    {
        void AddTopicContent(TopicContentsModel topicContent);
        void UdpdateTopicContent(TopicContentsModel topiContent);
        void DeleteTopicContent(int contentId);
        void RestoreTopiContent(int contentId);
        List<TopicContentsModel> GetAllTopicContent();
        TopicContentsModel GetTopicContentById(int contentId);
        CourseWiseContentModel GetContentByCourseId(int courseId);
    }
}
