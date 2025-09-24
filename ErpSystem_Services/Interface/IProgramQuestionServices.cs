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
       Task <List<ContentProgramQuestionsModel>> GetAllContentProgramQuestions();
       Task <ContentProgramQuestionsModel> GetContentProgramQuestionById(int programQuestionId);
      Task <List< ContentProgramQuestionsModel>> GetProgramingQuestionsContentId(int contentId);
     Task < List <TopicWiseProgramQuestionsModel>> GetProgramingQuestionsByTopictId(int topicId);

    }
}