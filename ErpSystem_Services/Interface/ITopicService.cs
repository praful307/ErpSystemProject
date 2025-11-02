using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface ITopicService
    {
        void AddTopic(TopicsModel topic);
        void UpdateTopic(TopicsModel topic);
        void DeleteTopic(int topicId);
        void RestoreTopic(int topicId);
        List<TopicsModel> GetAllTopics();
        TopicsModel GetTopicById(int topicId);
      Task< List<ContentModel>> GetCourseWiseTopics(int courseId);
       

    }
}
