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
        List<InterviewQuestionsModel> GetAllInterviewQuestions();
        InterviewQuestionsModel GetInterviewQuestionById(int InterviewQuestionId);
        TopicWiseInterviewQuestionsModel GetTopicWiseInterviewQuestions(int topicId);
        InterviewQuestionsModel GetContentWiseInterViewQuestion(int contentId);

    }
}
