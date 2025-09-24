using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface IProgramQuestionServices
    {
        void AddContentProgramQuestion(ContentProgramQuestionsModel programQuestion);
        void UpdateContentProgramQuestion(ContentProgramQuestionsModel programQuestion);
        void DeleteContentProgramQuestion(int programQuestionId);
        void RestoreContentProgramQuestion(int programQuestionId);
        List<ContentProgramQuestionsModel> GetAllContentProgramQuestions();
        ContentProgramQuestionsModel GetContentProgramQuestionById(int programQuestionId);
        ContentProgramQuestionsModel GetProgramingQuestionsContentId(int contentId);
        TopicWiseProgramQuestionsModel GetProgramingQuestionsTopictId(int topicId);

    }
}