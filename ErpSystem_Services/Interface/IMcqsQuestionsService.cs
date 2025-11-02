using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface IMcqsQuestionsService
    {
        void AddContentMcqsQuestions(TopicAndContentWiseMcqsQuestionsModel mcqsQuestions);
        void UpdateContentMcqsQuestions(TopicAndContentWiseMcqsQuestionsModel mcqsQuestions);
        void DeleteContentMcqsQuestions(int mcqsQuestionId);
        void RestoreContentMcqsQuestions(int mcqsQuestionId);
      Task < List<TopicAndContentWiseMcqsQuestionsModel>> GetAllContentMcqsQuestions();
      Task<TopicAndContentWiseMcqsQuestionsModel> GetMcqsQuestionsById(int mcqsQuestionId);
       Task <List <TopicAndContentWiseMcqsQuestionsModel>> GetContentWiseMcqsQuestion(int contentId);
       Task< List<TopicAndContentWiseMcqsQuestionsModel>> GetTopicWiseInterviewQuestionsById(int topicId);
    }
}
