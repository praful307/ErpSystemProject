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
        List<ContentMcqsQuestionsModel> GetAllContentMcqsQuestions();
        ContentMcqsQuestionsModel GetMcqsQuestionsById(int mcqsQuestionId);
        ContentMcqsQuestionsModel GetContentWiseMcqsQuestion(int contentId);
        TopicWiseInterviewQuestionsModel GetTopicWiseInterviewQuestionsById(int topicId);
    }
}
