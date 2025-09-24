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
        void AddInterviewQuestion(InterviewQuestionsModel interviewQuestion);
        void UpdateInterviewQuestion(InterviewQuestionsModel interviewQuestion);
        void DeleteInterviewQuestion(int interviewQuestionId);
        void RestoreInterviewQuestion(int InterviewQuestionId);
       Task < List<InterviewQuestionsModel>> GetAllInterviewQuestions();
      Task < InterviewQuestionsModel> GetInterviewQuestionById(int InterviewQuestionId);
     Task <List< TopicWiseInterviewQuestionsModel>> GetTopicWiseInterviewQuestions(int topicId);
    Task < List< InterviewQuestionsModel>> GetContentWiseInterViewQuestion(int contentId);

    }
}
