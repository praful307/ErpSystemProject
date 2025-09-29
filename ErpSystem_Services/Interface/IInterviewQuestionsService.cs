using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface IInterviewQuestionsService
    {
        void AddInterviewQuestion(TopicAndContentWiseInterviewQuestionsModel interviewQuestion);
        void UpdateInterviewQuestion(TopicAndContentWiseInterviewQuestionsModel interviewQuestion);
        void DeleteInterviewQuestion(int interviewQuestionId);
        void RestoreInterviewQuestion(int InterviewQuestionId);
       Task < List<TopicAndContentWiseInterviewQuestionsModel>> GetAllInterviewQuestions();
      Task <TopicAndContentWiseInterviewQuestionsModel> GetInterviewQuestionById(int InterviewQuestionId);
     Task <List< TopicAndContentWiseInterviewQuestionsModel>> GetTopicWiseInterviewQuestions(int topicId);
    Task < List<TopicAndContentWiseInterviewQuestionsModel>> GetContentWiseInterViewQuestion(int contentId);

    }
}
