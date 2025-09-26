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
        void AddContentMcqsQuestions(ContentMcqsQuestionsModel mcqsQuestions);
        void UpdateContentMcqsQuestions(ContentMcqsQuestionsModel mcqsQuestions);
        void DeleteContentMcqsQuestions(int mcqsQuestionId);
        void RestoreContentMcqsQuestions(int mcqsQuestionId);
      Task < List<ContentMcqsQuestionsModel>> GetAllContentMcqsQuestions();
      Task<  ContentMcqsQuestionsModel> GetMcqsQuestionsById(int mcqsQuestionId);
       Task <List <ContentMcqsQuestionsModel>> GetContentWiseMcqsQuestion(int contentId);
       Task< List<ContentMcqsQuestionsModel>> GetTopicWiseInterviewQuestionsById(int topicId);
    }
}
