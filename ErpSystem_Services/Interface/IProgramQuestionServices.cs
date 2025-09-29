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
        void AddContentProgramQuestion(TopicAndContentWiseProgramQuestionsModel programQuestion);
        void UpdateContentProgramQuestion(TopicAndContentWiseProgramQuestionsModel programQuestion);
        void DeleteContentProgramQuestion(int programQuestionId);
        void RestoreContentProgramQuestion(int programQuestionId);
       Task <List<TopicAndContentWiseProgramQuestionsModel>> GetAllContentProgramQuestions();
       Task <TopicAndContentWiseProgramQuestionsModel> GetContentProgramQuestionById(int programQuestionId);
      Task <List<TopicAndContentWiseProgramQuestionsModel>> GetProgramingQuestionsContentId(int contentId);
     Task < List <TopicAndContentWiseProgramQuestionsModel>> GetProgramingQuestionsByTopictId(int topicId);

    }
}