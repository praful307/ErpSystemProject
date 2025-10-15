using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface IInterviewQuestionAnswersService
    {
        void AddInterviewQuestionAnswer(InterviewQuestionAnswersModel interviewQuestionAnswer);
        void UpdateInterviewQuestionAnswer(InterviewQuestionAnswersModel interviewQuestionAnswer);
        void DeleteInterviewQuestionAnswer(int answerId);
        void RetoreInterviewQuestionAnswer(int answerId);
       Task <List<InterviewQuestionAnswersModel>> GetAllInterviewQuestionAnswers();
      Task <InterviewQuestionAnswersModel> GetInterviewQuestionAnswerById(int answerId);
      Task < List< InterviewQuestionAnswersModel>> GetInterviewAnswerByQuestionId(int interviewQuestionId);

    }
}
