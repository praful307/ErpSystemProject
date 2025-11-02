using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Implementation
{
    public class ProgramQuestionAnswersService : IProgramQuestionAnswersService
    {
        SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddProgramingAnswers(ProgramQuestionAnswersModel programQuestionAnswers)
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ProgramQuestionAnswers", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@ProgramQuestionId", programQuestionAnswers.ProgramQuestionId);              
                cmd.Parameters.AddWithValue("@ProgramAnswer", programQuestionAnswers.ProgramingAnswer);
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProgramingAnswers(int programAnswerId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ProgramQuestionAnswers", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@ProgramAnswerId", programAnswerId);
   
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public Task<List<ProgramQuestionAnswersModel>> GetAllProgramingAnswers()
        {
            con.Close();
            List<ProgramQuestionAnswersModel> lst = new List<ProgramQuestionAnswersModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchProgramQuestionAnswers", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProgramAnswerId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(new ProgramQuestionAnswersModel
                    {
                        ProgramAnswerId = Convert.ToInt32(dr["ProgramAnswerId"].ToString()),
                        ProgramingAnswer = dr["ProgramingAnswer"].ToString(),
                         ProgramQuestionId = Convert.ToInt32(dr["ProgramAnswerId"].ToString()),
                        Question = dr["Question"].ToString(),
               
                    });
                }

            }
            return Task.FromResult(lst);
        }

        public Task<ProgramQuestionAnswersModel> GetProgramingAnswersById(int programAnswerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProgramQuestionAnswersModel>> GetProgramingAnswersByProgramQuestionId(int programQuestionId)
        {
            con.Close();
            List<ProgramQuestionAnswersModel> lst = new List<ProgramQuestionAnswersModel>();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_FetchProgramQuestionAnswers", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProgramQuestionId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(new ProgramQuestionAnswersModel
                    {
                        ProgramAnswerId = Convert.ToInt32(dr["ProgramAnswerId"].ToString()),
                        ProgramingAnswer = dr["ProgramingAnswer"].ToString(),
                        ProgramQuestionId = Convert.ToInt32(dr["ProgramAnswerId"].ToString()),
                        Question = dr["Question"].ToString(),

                    });
                }

            }
            return Task.FromResult(lst);
        }

        public void RestoreProgramingAnswers(int programAnswerId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ProgramQuestionAnswers", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "restore");
                cmd.Parameters.AddWithValue("@ProgramAnswerId", programAnswerId);

                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public void UpdatProgramingAnswers(ProgramQuestionAnswersModel programQuestionAnswers)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ProgramQuestionAnswers", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                cmd.Parameters.AddWithValue("@ProgramQuestionId", programQuestionAnswers.ProgramQuestionId);
                cmd.Parameters.AddWithValue("@ProgramAnswer", programQuestionAnswers.ProgramingAnswer);
                int cnt = cmd.ExecuteNonQuery();
            }
        }
    }
}
