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
        public void DeleteTopicContent(int contentId);
        void RestoreTopiContent(int contentId);
       List<TopicContentsModel> GetAllTopicContents();
        TopicContentsModel GetTopicContentById(int contentId);
        Task< List<ContentModel>> GetContentsByCourseId(int courseId);
        Task< List<ContentModel>> TopciWiseContents(int topicId);
    }
}
