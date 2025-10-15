using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface IProgramQuestionAnswersService
    {
        void AddProgramingAnswers(ProgramQuestionAnswersModel programQuestionAnswers);
        void UpdatProgramingAnswers(ProgramQuestionAnswersModel programQuestionAnswers);
        void DeleteProgramingAnswers(int programAnswerId);
        void RestoreProgramingAnswers(int programAnswerId);
       Task <List<ProgramQuestionAnswersModel>> GetAllProgramingAnswers();
      Task   < ProgramQuestionAnswersModel> GetProgramingAnswersById(int programAnswerId);
       Task <List< ProgramQuestionAnswersModel>> GetProgramingAnswersByProgramQuestionId(int programQuestionId);
    }
}
